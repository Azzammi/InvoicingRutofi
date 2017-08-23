using System;
using invoicingRutofi.Model;
using invoicingRutofi.Properties;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccess
{
    class itemMasterDAO
    {
        #region Declaration
        private static string connectionString;
        #endregion

        #region Constuctor
        public itemMasterDAO()
        {
            connectionString = Settings.Default.ConnectionString;
        }
        #endregion

        #region Methods
        internal void CreateDatabaseRecord(itemMaster newItem)
        {
            string sql = "INSERT INTO ITEM " +
                "(ITEMCODE, ITEMNAME, ITEMSORT, ITEMPRICE, ITEMSATUAN) "
               + "OUTPUT INSERTED.ITEMCODE "
               + "VALUES (@code, @name, @sort, @price, @satuan)";
            AddorUpdateRecord(sql,newItem);
        }

        internal void UpdateDatabaseRecord(itemMaster changedItem)
        {
        //    if (string.IsNullOrEmpty(changedItem.Code))
        //    {
        //        MessageBox.Show("TRUE");
        //    }
        //    else
        //    {
        //        MessageBox.Show("FALSE");
        //    }
            string sql = "UPDATE ITEM SET " +
                        "itemName = @name, " +
                        "itemSort = @sort, " +
                        "itemPrice = @price, " +
                        "itemSatuan = @satuan " +
                        "WHERE itemCode = @code ";
            AddorUpdateRecord(sql, changedItem);
        }

        internal void DeleteDatabaseRecord(string itemCode)
        {
            string sql = "Delete From Item Where itemCode = @code";
            try
            {
                //Create and open a connection
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                //create and configure a command
                SqlCommand command = new SqlCommand(sql, connection);

                //Adding value through parameter
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@code", itemCode);           

                //execute the command
                command.ExecuteNonQuery();

                //Close and dispose
                command.Dispose();
                connection.Close();
                connection.Dispose();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Add or update the Item record
        /// </summary>
        /// <param name="sql">
        /// The query string which will br run against, Make sure the parameter name is correct,
        /// Param = @code,@name, @sort, @price, @satuan
        /// </param>
        /// <param name="ItemMaster">The itemMaster object that will be passed</param>
        internal void AddorUpdateRecord(string sql, itemMaster ItemMaster)
        {
            try
            {
                //Create and open a connection
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                //create and configure a command
                SqlCommand command = new SqlCommand(sql, connection);

                //Adding value through parameter
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@code", ItemMaster.Code);
                command.Parameters.AddWithValue("@name", ItemMaster.Name);
                command.Parameters.AddWithValue("@sort", ItemMaster.Sort);
                command.Parameters.AddWithValue("@price", ItemMaster.Price);
                command.Parameters.AddWithValue("@satuan", ItemMaster.Satuan);

                //execute the command
                command.ExecuteNonQuery();

                //Close and dispose
                command.Dispose();
                connection.Close();
                connection.Dispose();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}
