using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace invoicingRutofi.Model
{
   public class GroupHargaItem
    {
        #region Declarations
        private string groupCode;
        private string keterangan;
        private bool stat;
        #endregion

        #region Constructor
        public GroupHargaItem() { }

        //For adding new record
        public GroupHargaItem(bool CreateDatabaseRecord)
        {
            if(CreateDatabaseRecord == true)
            {
                GroupHargaItemDAO dao = new GroupHargaItemDAO();
                dao.CreateDatabaseRecord(this);
            }
        }
        #endregion

        #region Properties
        public string GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }
        public string Keterangan
        {
            get { return keterangan; }
            set { keterangan = value; }
        }
        public bool Stat
        {
            get { return stat; }
            set { stat = value; }
        }
        #endregion

        #region Methods
        internal void CreateRecord()
        {
            GroupHargaItemDAO dao = new GroupHargaItemDAO();
            dao.CreateDatabaseRecord(this);
        }       

        internal void UpdateRecord()
        {
            GroupHargaItemDAO dao = new GroupHargaItemDAO();
            dao.UpdateDatabaseRecord(this);
        }
        
        internal void DeleteRecord()
        {
            GroupHargaItemDAO dao = new GroupHargaItemDAO();
            dao.DeleteDatabaseRecord(this.groupCode);
        }

        #endregion
    }
}
