using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSCollections;

namespace invoicingRutofi.Model
{
    public class InvoiceDetail : FSBindingItem
    {
        #region Declarations
        private string invoiceNumber;
        private string itemCode;
        private string itemName;
        private decimal itemPrice;
        private int itemQty;
        #endregion

        #region Constructor
        public InvoiceDetail() { }

        /// <summary>
        /// Insert new invoice Item
        /// </summary>
        /// <param name="invoiceNumber">String based parameter</param>
        public InvoiceDetail(string invoiceNumber)
        {

        }
        #endregion

        #region Properties
        public string InvoiceNumber
        {
            get { return invoiceNumber; }
            set { invoiceNumber = value; }
        }
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }
        public string ItemName
        {
            get { return ItemName; }
            set { itemName = value; }
        }
        public decimal ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }
        public int ItemQty
        {
            get { return itemQty; }
            set { itemQty = value; }
        }
        #endregion

        #region Methods

        #endregion
    }
}
