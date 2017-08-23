using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using invoicingRutofi.Model;
using System.Windows.Forms;

namespace invoicingRutofi.View
{
    public partial class FrmBarang : Form
    {
        #region Declarations
        AppController m_AppController;
        itemMasterList m_ItemList;
        bool isNewRecord = false;
        bool isAddRow = false;
        #endregion

        public FrmBarang()
        {
            InitializeComponent();
        }


        private void FrmBarang_Load(object sender, EventArgs e)
        {
            //Initialize Controller
            m_AppController = new AppController();

            /* Note that the DataProvider class is static, so it doesn't
             * get instantiated. */

            //Get Group Harga List
            CommandGetItem getItem = new CommandGetItem();
            m_ItemList = (itemMasterList)m_AppController.ExecuteCommand(getItem);

            //Bind to datasource
            itemMasterBindingSource.DataSource = m_ItemList;
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void itemMasterDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void itemMasterBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
           
        }

        private void itemMasterBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
          
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            itemMasterBindingSource.AddNew();

            isNewRecord = true;

            itemMasterDataGridView.Focus();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (m_ItemList == null) return;

            itemMaster m_item = (itemMaster)itemMasterBindingSource.Current;

            if (isNewRecord)
            {               
                CommandCreateItem createItem = new CommandCreateItem(m_item);
                itemMaster newItem = (itemMaster)m_AppController.ExecuteCommand(createItem);
            }
            else if (!isNewRecord)
            {               
                CommandUpdateItem updateItem = new CommandUpdateItem(m_item);
                itemMaster changeItem = (itemMaster)m_AppController.ExecuteCommand(updateItem);
            }

            isNewRecord = false;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (m_ItemList == null) return;

            itemMaster m_item = (itemMaster)itemMasterBindingSource.Current;

            CommandDeleteItem deleteitem = new CommandDeleteItem(m_ItemList, m_item);
            itemMaster itemDelete = (itemMaster)m_AppController.ExecuteCommand(deleteitem);
        }

        private void itemMasterDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            addBtn.PerformClick();           
        }

        private void itemMasterBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            /* This event will be called several times during form initialization.
           * We don't want to do anything with it until the runtime authors
           * list has been passed in. */

            // Exit if no project list
            if (m_ItemList == null) return;

            // Get the item affected
            int index = e.NewIndex;
            itemMaster changedItem = null;
            if ((index > -1) && (index < m_ItemList.Count))
            {
                changedItem = m_ItemList[index];
            }
            
            // Get the type of change that occured
            ListChangedType changeType = e.ListChangedType;

            /* We only need to respond to two types of changes here; updates
             * and moves. Adds are handled by bindingSourceProjects_AddingNew(),
             * and deletes are handled by menuItemAuthorsDelete_Click(). */

            // Dispatch a change handler

            switch (changeType)
            {
                case ListChangedType.ItemChanged:
                    CommandUpdateItem updateAuthor = new CommandUpdateItem(changedItem);
                    m_AppController.ExecuteCommand(updateAuthor);
                    break;

                case ListChangedType.ItemMoved:
                    // Not supported in this app
                    break;
            }
        }
        
    }
}
