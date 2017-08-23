using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;


namespace FSCollections
{
    class FSPropertyComparer<T> : IComparer<T>
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

        // Member variables
        private PropertyDescriptor m_Property;
        private ListSortDirection m_Direction;

        #endregion

        #region Constructor

        public FSPropertyComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            m_Property = property;
            m_Direction = direction;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        private int CompareAscending(object xValue, object yValue)
        {
            int result;

            // If values implement IComparer
            if (xValue is IComparable)
            {
                result = ((IComparable)xValue).CompareTo(yValue);
            }
            // If values don't implement IComparer but are equivalent
            else if (xValue.Equals(yValue))
            {
                result = 0;
            }
            // Values don't implement IComparer and are not equivalent, so compare as string values
            else result = xValue.ToString().CompareTo(yValue.ToString());

            // Return result
            return result;
        }

        private int CompareDescending(object xValue, object yValue)
        {
            // Return result adjusted for ascending or descending sort order ie
            // multiplied by 1 for ascending or -1 for descending
            return CompareAscending(xValue, yValue) * -1;
        }

        private object GetPropertyValue(T value, string property)
        {
            // Get property
            PropertyInfo propertyInfo = value.GetType().GetProperty(property);

            // Return value
            return propertyInfo.GetValue(value, null);
        }

        #endregion

        #region IComparer<T>

        public int Compare(T xWord, T yWord)
        {
            // Get property values
            object xValue = GetPropertyValue(xWord, m_Property.Name);
            object yValue = GetPropertyValue(yWord, m_Property.Name);

            // Determine sort order
            if (m_Direction == ListSortDirection.Ascending)
            {
                return CompareAscending(xValue, yValue);
            }
            else
            {
                return CompareDescending(xValue, yValue);
            }
        }

        public bool Equals(T xWord, T yWord)
        {
            return xWord.Equals(yWord);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
