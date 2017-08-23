using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoicingRutofi.Model
{
    public class itemMaster
    {
        #region Declarations
        private string itemCode;
        private string itemName;
        private string itemSort;
        private decimal itemPrice;
        private string itemSatuan;
        #endregion

        #region Constructor
        public itemMaster() { }

        //If adding new record
        public itemMaster(string ItemCode)
        {

        }
        #endregion

        #region Properties
        public string Code
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        public string Name
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public string Sort
        {
            get { return itemSort; }
            set { itemSort = value; }
        }

        public decimal Price
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }
        public string Satuan
        {
            get { return itemSatuan; }
            set { itemSatuan = value; }
        }
        #endregion

        #region Methods
        internal void CreateDatabaseRecord()
        {
            itemMasterDAO dao = new itemMasterDAO();
            dao.CreateDatabaseRecord(this);
        }

        internal void UpdateDatabaseRecord()
        {
            itemMasterDAO dao = new itemMasterDAO();
            dao.UpdateDatabaseRecord(this);
        }

        internal void DeleteDatabaseRecord()
        {
            itemMasterDAO dao = new itemMasterDAO();
            dao.DeleteDatabaseRecord(this.Code);
        }
        #endregion
    }
}
