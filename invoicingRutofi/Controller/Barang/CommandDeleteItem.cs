using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;

namespace Controller
{
    class CommandDeleteItem : Command
    {
        #region Declarations
        itemMasterList m_List;
        itemMaster m_Item;
        #endregion

        #region Constuctor
        public CommandDeleteItem(itemMasterList list, itemMaster deleteItem)
        {
            m_List = list;
            m_Item = deleteItem;
        }

        #endregion

        #region Method
        public override object Execute()
        {
            m_Item.DeleteDatabaseRecord();
            m_List.Remove(m_Item);
            return null;
        }
        #endregion
    }
}
