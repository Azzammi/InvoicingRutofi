using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;

namespace Controller
{
    class CommandUpdateItem : Command
    {
        #region Declarations
        itemMaster m_Item;
        #endregion

        #region Constructor
        public CommandUpdateItem(itemMaster changeItem)
        {
            m_Item = changeItem;
        }
        #endregion

        #region Method
        public override object Execute()
        {
            m_Item.UpdateDatabaseRecord();
            return m_Item;
        }
        #endregion
    }
}
