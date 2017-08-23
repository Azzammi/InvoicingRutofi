using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;
using System.Data;

namespace DataAccess
{
    public class ItemMasterListDAO
    {
        #region Constructor
        public ItemMasterListDAO()
        {

        }
        #endregion

        #region Method
        public void ShowList(itemMasterList list)
        {
            string sql = "SELECT [ITEMCODE],[ITEMNAME],[ITEMSORT],[ITEMPRICE],[ITEMSATUAN] FROM [standArtInvoicingDB].[dbo].[ITEM]";

            DataSet dataSet = DataProvider.GetDataSet(sql);

            //Create variable for dataset table
            DataTable itemTabel = dataSet.Tables[0];

            itemMaster nextItem = null;

            foreach(DataRow parentRow in itemTabel.Rows)
            {
                nextItem = new itemMaster();

                nextItem.Code = parentRow["ITEMCODE"].ToString();
                nextItem.Name = parentRow["ITEMNAME"].ToString();
                nextItem.Sort = parentRow["ITEMSORT"].ToString();
                nextItem.Price = Convert.ToDecimal(parentRow["ITEMPRICE"]);
                nextItem.Satuan = parentRow["ITEMSATUAN"].ToString();

                list.Add(nextItem);
            }
            dataSet.Dispose();
        }
        #endregion
    }
}
