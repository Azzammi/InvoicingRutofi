using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;

namespace Controller
{
    public class CommandGetGroupHarga : Command
    {
        #region Declarations

        #endregion

        #region Method
        public override object Execute()
        {
            GrouphargaList list = new GrouphargaList();
            return list;
        }
        #endregion
    }
}
