using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using FSCollections;

namespace invoicingRutofi.Model
{
    public class itemMasterList : FSBindingList<itemMaster>
    {
        #region Cosntructor
        public itemMasterList()
        {
            ItemMasterListDAO dao = new ItemMasterListDAO();
            dao.ShowList(this);
        }
        #endregion

        #region Method

        #endregion
    }
}
