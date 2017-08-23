using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;

namespace Controller
{
    class CommandCreateItem : Command
    {
        #region Declarations
        itemMaster m_Item;
        #endregion

        #region Constuctor
        public CommandCreateItem(itemMaster newItem)
        {
            m_Item = newItem;
        }
        #endregion

        #region Method
        public override object Execute()
        {
            m_Item.CreateDatabaseRecord();
            return m_Item;   
        }
        #endregion
    }
}
