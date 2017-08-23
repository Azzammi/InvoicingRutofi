using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoicingRutofi.Model;
using invoicingRutofi.Properties;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccess
{
    public class GroupHargaItemDAO
    {
        #region Declaration
        private static string connectionString;
        #endregion

        #region Constructor
        public GroupHargaItemDAO()
        {
            connectionString = Settings.Default.ConnectionString;
        }
        #endregion

        #region Methods

        internal void CreateDatabaseRecord(GroupHargaItem newGroup)
        {
            string sql = "INSERT INTO priceGroup "
                + "(groupCode,groupKet, groupStat) "
                + "OUTPUT INSERTED.groupCode "
                + "VALUES (@groupCode, @groupKet, @groupStat)";

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
                command.Parameters.AddWithValue("@groupCode", newGroup.GroupCode);
                command.Parameters.AddWithValue("@groupKet", newGroup.Keterangan);
                command.Parameters.AddWithValue("@groupStat", newGroup.Stat);

                //execute the command
                string numRowsAffected = Convert.ToString(command.ExecuteScalar());

                //Close and dispose
                command.Dispose();
                connection.Close();
                connection.Dispose();

                //set return value
                newGroup.GroupCode = numRowsAffected;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        internal void UpdateDatabaseRecord(GroupHargaItem changedGroup)
        {
            string sql = "UPDATE priceGroup SET " +
                         "groupKet = @groupKet, " + 
                         "groupStat = @groupStat " + 
                         "WHERE groupCode = @groupCode" ;

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
                command.Parameters.AddWithValue("@groupCode", changedGroup.GroupCode);
                command.Parameters.AddWithValue("@groupKet", changedGroup.Keterangan);
                command.Parameters.AddWithValue("@groupStat", changedGroup.Stat);

                //execute the command
                string numRowsAffected = Convert.ToString(command.ExecuteScalar());

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

        internal void DeleteDatabaseRecord(string deleteGroup)
        {
            string sql = "DELETE FROM priceGroup WHERE groupCode = @groupCode";

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
                command.Parameters.AddWithValue("@groupCode", deleteGroup);
              
                //execute the command
                string numRowsAffected = Convert.ToString(command.ExecuteScalar());

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
