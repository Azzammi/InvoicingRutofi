using invoicingRutofi.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess
{
    public static class DataProvider
    {
        #region Declaration

        //Member Variables
        private static string m_ConnectionString = String.Empty;
        //private static SqlDataReader sqlDataReader;
        #endregion

        #region Constructor

        static DataProvider()
        {
            m_ConnectionString = Settings.Default.ConnectionString;
        }

        #endregion

        #region methods

        /// <Summary>
        /// Insert, update, or delete a record in the database.
        /// </Summary>
        /// <param name="sqlQuery">The sql query to run against the database</param>
        /// <returns>The number of rows affected by the oparation</returns>

        public static int ExecuteNonQuery(string sqlQuery)
        {
            try
            {
                //Create and open a connection
                SqlConnection connection = new SqlConnection(m_ConnectionString);
                connection.Open();

                //create and configure a command
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                //execute the command
                int numRowsAffected = command.ExecuteNonQuery();

                //Close and dispose
                command.Dispose();
                connection.Close();
                connection.Dispose();

                //set return value
                return numRowsAffected;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return 0;
            }
           
        }

        /// <summary>
        /// Get string return value
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public static string ExecuteScalar(string sql)
        {
            try
            {
                // Create and open a connection
                SqlConnection connection = new SqlConnection(m_ConnectionString);
                connection.Open();

                // Create and configure a command
                SqlCommand command = new SqlCommand(sql, connection);

                // Execute the command
                string result = Convert.ToString(command.ExecuteScalar());

                // Close and dispose
                command.Dispose();
                connection.Close();
                connection.Dispose();

                // Set return value
                return result;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return "0";
            }
           
        }

        /// <summary>
        /// Retrieve a data set.
        /// </summary>
        /// <param name="sqlQuery">The SQL Select query to run against the database. </param>
        /// <returns>A populated data set.</returns>
        /// <remarks>This method uses a connection string passed in as an argument
        /// to the constructor for this class.</remarks>
        public static DataSet GetDataSet(string sqlQuery)
        {
            // Create dataset
            DataSet dataSet = new DataSet();

            // Populate dataset
            using (SqlConnection connection = new SqlConnection(m_ConnectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = sqlQuery;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
            }

            // return dataset
            return dataSet;
        }

        /// <summary>
        /// Retrieve a SQL Reader
        /// </summary>
        /// <param name="sql">The SQL Select Query to run against the database. </param>
        /// <returns>A Populated SQL Data Reader</returns>
        /// <remarks>Not yet perfected</remarks>
        public static SqlDataReader GetReader(string sql)
        {
            //Create DataReader
            SqlDataReader sqlDataReader;

            SqlConnection koneksi = new SqlConnection(m_ConnectionString);           
            koneksi.Open();

            SqlCommand command = new SqlCommand(sql, koneksi);
            sqlDataReader = command.ExecuteReader();                     

            return sqlDataReader;
        }

        /// <summary>
        /// Autonumber function
        /// </summary>
        /// <param name="namaTabel">Table name from which the data will read</param>
        /// <param name="namaField">Field name from which the data will read</param>
        /// <returns>Autonumber result (string) </returns>
        public static string GenerateNumber(string namaTabel, string namaField)
        {
            try
            {
                //Create a co
                SqlConnection koneksi = new SqlConnection(m_ConnectionString);
                koneksi.Open();

                string number;
                using (SqlCommand Perintah = new SqlCommand("SELECT " + namaField + " FROM [standArtInvoicingDB].[dbo].[" + namaTabel + "] ORDER BY " + namaField + " DESC", koneksi))
                {
                    SqlDataReader RaDa = Perintah.ExecuteReader();
                    RaDa.Read();
                    if (RaDa.HasRows)
                    {
                        number = RaDa.GetString(0);
                        number = number.Substring(number.Length - 5, 5);
                        int num = int.Parse(number) + 1;

                        RaDa.Close();
                        koneksi.Close();
                        koneksi.Dispose();

                        return num.ToString();
                    }
                    else
                    {
                        RaDa.Close();
                        koneksi.Close();
                        koneksi.Dispose();

                        return "100001";
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "00000";
            }
        }

        #endregion
    }
}
