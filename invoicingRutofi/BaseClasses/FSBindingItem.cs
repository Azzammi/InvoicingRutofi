using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCollections
{
    public abstract class FSBindingItem : IEditableObject
    { 
        #region Copyright Notice

        /* Copyright © 2006, David C. Veeneman. You may use and modify this code,
         * so long as you include an an acknowledgement to David C. Veeneman. */

        #endregion

        #region Declarations

        //Member Variables
        protected bool m_Editing = false;
        protected Hashtable m_OldValues;

        #endregion

        #region Constructor

        public FSBindingItem()
        {

        }

        #endregion

        #region IEditableObject Members

        public virtual void BeginEdit()
        {
            if (m_Editing == false)
            {
                m_Editing = true;
                m_OldValues = new Hashtable();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this);
                foreach (PropertyDescriptor property in properties)
                {
                    m_OldValues.Add(property, property.GetValue(this));
                }
            }
        }

        public virtual void CancelEdit()
        {
            if (m_Editing == true)
            {
                if (m_Editing == true)
                {

                    //Undo edit changes
                    PropertyDescriptor property = null;
                    foreach (DictionaryEntry entry in m_OldValues)
                    {
                        property = (PropertyDescriptor)entry.Key;
                        property.SetValue(this, entry.Value);
                    }

                    //Clean Up
                    m_OldValues = null;
                    m_Editing = false;
                }
            }
        }

        public virtual void EndEdit()
        {
            if (m_Editing == true)
            {
                //Clean up
                m_OldValues = null;
                m_Editing = false;
            }
        }

        #endregion
    }
}
