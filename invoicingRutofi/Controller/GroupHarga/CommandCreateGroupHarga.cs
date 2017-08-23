using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;

namespace Controller
{
    class CommandCreateGroupHarga : Command
    {
        #region Declarations
        GroupHargaItem m_Item;
        #endregion

        #region Construction
        public CommandCreateGroupHarga(GroupHargaItem groupItem)
        {
            m_Item = groupItem;
        }
        #endregion

        #region Method
        public override object Execute()
        {
            //GroupHargaItem newItem = new GroupHargaItem(true);
            //return newItem;
            m_Item.CreateRecord();
            return m_Item;
        }
        #endregion
    }
}
