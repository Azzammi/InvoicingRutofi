using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;
using System.Data;

namespace DataAccess
{
    class InvoiceListDAO
    {
        #region Declarationss

        #endregion

        #region Constructor
        public InvoiceListDAO()
        {

        }
        #endregion

        #region Method
        public void LoadInvoice(InvoiceList invoiceList)
        {
            //Build query to get Invoice's and their roti
            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append(String.Format("SELECT [invoiceNo],[invoiceTgl],[slsmCode],[slsmName],[kurs],[nomorPO] ,[outletCode] ,[termsOfPayment],[nomorFakturPajak],[nomorKwitansi],[expiredDate],[subTotal],[ppn],[totalBersih] FROM [standArtInvoicingDB].[dbo].[Invoice]"));
            sqlQuery.Append(string.Format("SELECT [invoiceNo],[itemCode],[itemName],[itemPrice],[itemQty] FROM[standArtInvoicingDB].[dbo].[InvoiceDetail]"));

            //Get a data set from the query
            DataSet dataSet = DataProvider.GetDataSet(sqlQuery.ToString());

            //Create Variables for data set tables
            DataTable invoiceTable = dataSet.Tables[0];
            DataTable detailTable = dataSet.Tables[1];

            //Create a data relation from invoice (parent table) to detail Invoice
            DataColumn parentColumn = invoiceTable.Columns["invoiceNo"];
            DataColumn childColumn = detailTable.Columns["invoiceNo"];
            DataRelation invoiceToDetail = new DataRelation("invoiceToDetail", parentColumn, childColumn, false);
            dataSet.Relations.Add(invoiceToDetail);

            //Load InvoiceList from the data set
            invoicePerItem nextInvoice = null;
            InvoiceDetail nextRoti = null;
            foreach (DataRow parentRow in invoiceTable.Rows)
            {
                ////Create a new invoice
                //bool createDatabaseRecord = false;
                //nextInvoice = new invoicePerItem(createDatabaseRecord);

                ////Fill in invoice properties
                //nextInvoice.InvoiceID = Convert.ToInt32(parentRow["invoiceID"]);
                //nextInvoice.Nomor = parentRow["noInvoice"].ToString();
                //nextInvoice.PeriodeBulan = Convert.ToDateTime(parentRow["periodeBulan"]);
                //nextInvoice.SlsmCode = parentRow["slsmCode"].ToString();
                //nextInvoice.SlsmName = parentRow["slsmName"].ToString();
                ////nextInvoice.SubTotal = Convert.ToDecimal(parentRow["subTotal"]);
                //nextInvoice.PPN = Convert.ToInt32(parentRow["ppn"]);
                ////nextInvoice.Total = Convert.ToDecimal(parentRow["total"]);
                //nextInvoice.IssuedData = Convert.ToDateTime(parentRow["issuedDate"]);

                ////Get Invoice Item
                //DataRow[] childRows = parentRow.GetChildRows(invoiceToDetail);

                ////Create invoiceItem object foe each of the invoice
                //foreach (DataRow childRow in childRows)
                //{
                //    //Create a new item
                //    nextRoti = new rotiItem();

                //    //Fill in roti's properties
                //    nextRoti.ID = Convert.ToInt32(childRow["rotiID"]);
                //    nextRoti.Code = childRow["itemCode"].ToString();
                //    nextRoti.Name = childRow["itemName"].ToString();
                //    nextRoti.Qty = Convert.ToInt32(childRow["itemQty"]);
                //    nextRoti.Price = Convert.ToDecimal(childRow["itemPrice"]);

                //    //Add roti to invoice
                //    nextInvoice.Items.Add(nextRoti);
                //}

                ////Add the invoice to the invoice List
                //invoiceList.Add(nextInvoice);
            }

            //Dispose of the dataset
            dataSet.Dispose();
        }

        #endregion
    }
}

