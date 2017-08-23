using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class GroupHargaListDAO
    {
        #region Declarations

        #endregion

        #region Constructor
        public GroupHargaListDAO()
        {

        }
        #endregion

        #region Method
        public void ListGroupHarga(GrouphargaList list)
        {
            string sql = "SELECT [GROUPCODE],[groupKET],[GROUPSTAT] FROM [standArtInvoicingDB].[dbo].[priceGroup]";
            
            DataSet dataSet = DataProvider.GetDataSet(sql);

            //Create variable for DataSet table
            DataTable groupPriceTabel = dataSet.Tables[0];

            GroupHargaItem nextGroup = null;

            foreach (DataRow parentRow in groupPriceTabel.Rows)
            {
                nextGroup = new GroupHargaItem();

                nextGroup.GroupCode = parentRow["GROUPCODE"].ToString();
                nextGroup.Keterangan = parentRow["GROUPKET"].ToString();
                nextGroup.Stat = Convert.ToBoolean(parentRow["GROUPSTAT"]);

                list.Add(nextGroup);
            }

            dataSet.Dispose();
        }
        #endregion
    }
}
