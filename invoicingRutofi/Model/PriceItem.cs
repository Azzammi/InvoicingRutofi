using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoicingRutofi.Model
{
    public class PriceItem
    {
        #region Declarations
        //Member Variables
        private string priceItem;
        private string priceGroup;
        private decimal priceCurrent;
        private DateTime priceCurrentDate;
        private decimal priceBefore;
        private DateTime priceBeforeDate;
        #endregion

        #region Constructor
        public PriceItem() { }

        //For adding new record
        public PriceItem(string itemCode) { }
        #endregion

        #region Properties
        public string ItemCode
        {
            get { return priceItem; }
            set { priceItem = value; }
        }
        public string Group
        {
            get { return priceGroup; }
            set { priceGroup = value; }

        }
        public decimal PriceCurrent
        {
            get { return priceCurrent; }
            set { priceCurrent = value; }
        }
        public DateTime PriceCurrentDate
        {
            get { return priceCurrentDate; }
            set { priceCurrentDate = value; }
        }
        public decimal PriceBefore
        {
            get { return priceBefore; }
            set { priceBefore = value; }
        }
        public DateTime PriceBeforeDate
        {
            get { return priceBeforeDate; }
            set { priceBeforeDate = value; }
        }
        #endregion

        #region Methods

        #endregion
    }
}

