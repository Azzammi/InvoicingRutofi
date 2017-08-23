using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using invoicingRutofi.Model;

namespace Controller
{
    class CommandGetItem : Command
    {
        #region Method
        public override object Execute()
        {
            itemMasterList list = new itemMasterList();
            return list;
        }
        #endregion

    }
}
