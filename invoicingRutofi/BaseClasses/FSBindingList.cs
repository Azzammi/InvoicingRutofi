using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using FSCollections;

namespace FSCollections
{
    public class FSBindingList<T> : BindingList<T>
    {
        #region Copyright Notice

        /* Copyright © 2006, David C. Veeneman. You may use and modify this code,
         * so long as you include an an acknowledgement to David C. Veeneman, and
         * to the following articles:
         * 
         * This class is based on 'SearchableSortableBindingList.cs' by Michael Weinhardt,
         * published in MSDN, 'Custom Data Binding', Parts 1-3:
         * 
         * Part 1: http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnforms/html/winforms11162004.asp
         * Part 2: http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnforms/html/winforms02182005.asp
         * Part 3: http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnforms/html/winforms02152005.asp
         */

        #endregion

        #region Declarations

        #region Sorting Declarations

        private bool p_isSorted;
        private PropertyDescriptor p_sortProperty;
        private ListSortDirection p_sortDirection;


        #endregion

        #endregion

        #region Properties

        #region Sorting Properties

        protected override bool IsSortedCore
        {
            get { return p_isSorted; }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return p_sortDirection; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return p_sortProperty; }
        }

        #endregion

        #region Searching Properties

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        #endregion

        #endregion

        #region Methods

        #region Sorting Methods

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            // Get list to sort
            // Note: this.Items is a non-sortable ICollection<T>
            List<T> items = this.Items as List<T>;

            // Apply and set the sort, if items to sort
            if (items != null)
            {
                FSPropertyComparer<T> pc = new FSPropertyComparer<T>(property, direction);
                items.Sort(pc);
                p_isSorted = true;
            }
            else
            {
                p_isSorted = false;
            }

            p_sortProperty = property;
            p_sortDirection = direction;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            p_isSorted = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        public void Sort(PropertyDescriptor property, ListSortDirection direction)
        {
            this.ApplySortCore(property, direction);
        }

        #endregion

        #region Searching Methods

        /// <summary>
        /// Searches an FSBindingList for a particular item.
        /// </summary>
        /// <param name="property">The property to search.</param>
        /// <param name="key">The value to find.</param>
        /// <returns>The collection index of the found item.</returns>
        protected override int FindCore(PropertyDescriptor property, object key)
        {
            // Exit if no property specified
            if (property == null) return -1;

            // Get list to search
            List<T> items = this.Items as List<T>;

            //Get the type and convert it
            //if(key.GetType() == typeof(string))
            //{
            //    Convert.ToString(key);
            string Key = (string)key;
            Key = Key.Trim();
            Key = Key.ToLower();
            //}          

            // Traverse list for value
            foreach (T item in items)
            {
                // Test column search value
                string value = (string)property.GetValue(item);
                value = value.Trim();
                value = value.ToLower();

                // If value is the search value, return the index of the data item
                // Remove whitespace in search value, for accurate searching ---Luthfi
                if (Key == value) return IndexOf(item);

            }
            return -1;
        }

        public int Find(string param, string key)
        {
            //Check properties with the specified name
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            PropertyDescriptor prop = properties.Find(param, true);

            if (prop != null)
            {
                if (FindCore(prop, key) >= 0)
                {
                    return FindCore(prop, key);
                }
            }
            return 0;
        }
        #endregion

        #region Persistence Methods

        /* These methods are used to serialize a collection to a file, 
         * and to deserialize it from a file. They are intended for use 
         * with standalone files, rather than a database. */

        /* NOTE: BindingList<T> is not serializable, but List<T> is. 
         * So, we cast the list to (List<T>) for loads and saves. */

        /// <summary>
        /// Loads a collection from a serialized file.
        /// </summary>
        /// <param name="filename">The file path of the file to open.</param>
        public void Load(string filename)
        {
            this.ClearItems();

            if (File.Exists(filename))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    // Deserialize data list items
                    ((List<T>)this.Items).AddRange((IEnumerable<T>)formatter.Deserialize(stream));
                }
            }

            // Let bound controls know they should refresh their views
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        /// <summary>
        /// Saves a collection to a serialized file.
        /// </summary>
        /// <param name="filename">The file path of the file to save.</param>
        public void Save(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                // Serialize data list items
                formatter.Serialize(stream, (List<T>)this.Items);
            }
        }

        #endregion

        #endregion
    }
}
