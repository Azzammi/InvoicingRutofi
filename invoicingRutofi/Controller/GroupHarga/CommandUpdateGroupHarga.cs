using System;
using System.Collections.Generic;
using System.Linq;
using invoicingRutofi.Model;
using System.Threading.Tasks;

namespace Controller
{
    class CommandUpdateGroupHarga : Command
    {
        

        #region Declarations
        GroupHargaItem m_Item;
        #endregion

        #region Constructor
        public CommandUpdateGroupHarga(GroupHargaItem groupItem)
        {
            m_Item = groupItem;
        }
        #endregion

        #region Method
        public override object Execute()
        {
            m_Item.UpdateRecord();
            return m_Item;
        }
        #endregion
    }
}

