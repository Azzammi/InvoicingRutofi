using System;
using System.Collections.Generic;
using System.Linq;
using invoicingRutofi.Model;
using System.Threading.Tasks;

namespace Controller
{
    class CommandDeleteGroupHarga : Command
    {
        #region Declaration
        GrouphargaList m_groupList;
        GroupHargaItem m_Item;
        #endregion

        #region Constructor
        public CommandDeleteGroupHarga(GrouphargaList listItem, GroupHargaItem deleteItem)
        {
            m_groupList = listItem;
            m_Item = deleteItem;
        }
        #endregion
        #region Method
        public override object Execute()
        {
            m_Item.DeleteRecord();
            m_groupList.Remove(m_Item);
            return null;
        }
        #endregion
    }
}
