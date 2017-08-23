using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using FSCollections;

namespace invoicingRutofi.Model
{
    public class GrouphargaList : FSBindingList<GroupHargaItem>
    {
        #region Constructor
        public GrouphargaList()
        {
            GroupHargaListDAO dao = new GroupHargaListDAO();
            dao.ListGroupHarga(this);
        }
        #endregion

        #region Methods

        #endregion
    }
}
