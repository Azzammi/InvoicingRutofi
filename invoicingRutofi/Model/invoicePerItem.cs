using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoicingRutofi.Model
{
    public class invoicePerItem
    {
        #region Declarations
        private InvoiceDetail p_Details;
        private string invoiceNumber;
        private DateTime invoiceTgl;
        private string slsmCode;
        private string slsmName;
        private string mataUang;
        private string poNumber;
        private string outletCode;
        private int termsOfPayment;
        private string fakturPajakNumber;
        private string kwitansiNumber;
        private DateTime expiredDate;
        private decimal subTotal, ppn, totalBersih;
        #endregion

        #region Constructor
        public invoicePerItem() { }

        //For adding new record
        /// <summary>
        /// Insert new invoice number
        /// </summary>
        /// <param name="invNumber">String based parameter</param>
        public invoicePerItem(string invNumber)
        {

        }
        #endregion

        #region Properties
        public InvoiceDetail Details
        {
            get { return p_Details; }
            set { p_Details = value; }
        }
        public string Number
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }
        public DateTime Tanggal
        {
            get { return invoiceTgl; }
            set { invoiceTgl = value; }
        }
        public string SlsmName
        {
            get { return slsmName; }
            set { slsmName = value; }
        }
        public string SlsmCode
        {
            get { return slsmCode; }
            set { slsmCode = value; }
        }
        public string Kurs
        {
            get { return mataUang; }
            set { mataUang = value; }
        }
        public string PONumber
        {
            get { return poNumber; }
            set { poNumber = value; }
        }
        public string OutletCode
        {
            get { return outletCode; }
            set { outletCode = value; }
        }
        public int TOP
        {
            get { return termsOfPayment; }
            set { termsOfPayment = value; }
        }
        public string FakturPajakNumber
        {
            get { return fakturPajakNumber; }
            set { fakturPajakNumber = value; }
        }
        public string KwitansiNumber
        {
            get { return kwitansiNumber; }
            set { kwitansiNumber = value; }
        }
        public DateTime ExpiredDate
        {
            get { return expiredDate; }
            set { expiredDate = value; }
        }
        public decimal SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }
        public decimal PPN
        {
            get { return ppn; }
            set { ppn = value; }
        }
        public decimal TotalBersih
        {
            get { return totalBersih; }
            set { totalBersih = value; }
        }
        #endregion

        #region Methods

        #endregion
    }
}
