using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using invoicingRutofi.Model;
using Controller;

namespace invoicingRutofi
{
    public partial class FrmGroupHarga : Form
    {
        #region Declarations

        //Member Variable
        AppController m_AppController;
        GrouphargaList m_List;        

        bool isNewRecord = false;
        #endregion
        public FrmGroupHarga()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize Controller
            m_AppController = new AppController();

            /* Note that the DataProvider class is static, so it doesn't
             * get instantiated. */

            //Get Group Harga List
            CommandGetGroupHarga getGroupHarga = new CommandGetGroupHarga();
            m_List = (GrouphargaList)m_AppController.ExecuteCommand(getGroupHarga);

            //Bind to datasource
            bindingSource1.DataSource = m_List;
        }

        private void bindingSource1_AddingNew(object sender, AddingNewEventArgs e)
        {
   
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Set the new record status to true
            isNewRecord = true;

           // GroupHargaItem newItem = new GroupHargaItem();
            bindingSource1.AddNew();

            grouphargaListDataGridView.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* This event will be called several times during form initialization.
            * We don't want to do anything with it until the runtime authors
            * list has been passed in. */

            // Exit if no project list
            if (m_List == null) return;

            if(isNewRecord == true)
            {
                //Set the bindingList to current item bindingSource
                GroupHargaItem m_Item = (GroupHargaItem)bindingSource1.Current;

                // Create a new project
                CommandCreateGroupHarga createGroup = new CommandCreateGroupHarga(m_Item);
                GroupHargaItem newGroup = (GroupHargaItem)m_AppController.ExecuteCommand(createGroup);
            }
            else if(isNewRecord == false)
            {
                //Set the binfingList to current item BindingSource
                GroupHargaItem m_Item = (GroupHargaItem)bindingSource1.Current;

                //Update the record
                CommandUpdateGroupHarga updateGroup = new CommandUpdateGroupHarga(m_Item);
                GroupHargaItem groupToUpdate = (GroupHargaItem)m_AppController.ExecuteCommand(updateGroup);
            }

            isNewRecord = false;
            /* Since the BindingSource is managing the collection, we pass the new 
             * author to the BindingSource, using the NewObject property of the 
             * event args. The BindingSource will add the new author to the 
             * AuthorList for us. */

            //bindingSource1.Add(newGroup);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bindingSource1.Position = 0;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {           
            // Exit if no project list
            if (m_List == null) return;
          
            //Set the binfingList to current item BindingSource
            GroupHargaItem m_Item = (GroupHargaItem)bindingSource1.Current;

            CommandDeleteGroupHarga deleteGroup = new CommandDeleteGroupHarga(m_List, m_Item);
            m_AppController.ExecuteCommand(deleteGroup);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit if no project list
            if (m_List == null) return;

            //Set the binfingList to current item BindingSource
            GroupHargaItem m_Item = (GroupHargaItem)bindingSource1.Current;

            // Confirm Delete
            string invoiceNumber = String.Format("{0}", m_Item.GroupCode);
            string message = String.Format("Delete Invoice '{0}' and all of its item?", invoiceNumber);
            DialogResult result = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Delete author
            if (result == DialogResult.Yes)
            {
                CommandDeleteGroupHarga deleteGroup = new CommandDeleteGroupHarga(m_List,m_Item);
                m_AppController.ExecuteCommand(deleteGroup);
            }
        }

        private void bindingSource1_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {

        }

        private void FrmGroupHarga_FormClosing(object sender, FormClosingEventArgs e)
        {
                        
        }
    }
}
