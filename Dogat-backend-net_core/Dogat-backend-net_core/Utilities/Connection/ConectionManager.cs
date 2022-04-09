using System.Data;
using System.Data.SqlClient;

namespace Dogat_backend_net_core.Utilities.Conection
{
    public class ConectionManager
    {
        private SqlConnection _connection;

        public bool Open()
        {
            string ConnectionString = "";

            _connection = new SqlConnection(ConnectionString);

            try
            {
                _connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool ExecuteTransaction(string strQuery)
        {
            if(string.IsNullOrEmpty(strQuery))
                return false;

            if(_connection == null || _connection.State == ConnectionState.Closed)
            {
                if (!Open())
                    return false;
            }

            try
            {
                SqlCommand command = new SqlCommand(strQuery, _connection);
            
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }

        public IDataReader GetDataReader(string strQuery)
        {
            if (string.IsNullOrEmpty(strQuery))
                return null;

            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                if (!Open())
                    return null;
            }

            try
            {
                SqlCommand command = new SqlCommand(strQuery, _connection);

                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50000;

                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public DataTable GetDataTable(string strQuery)
        {
            if (string.IsNullOrEmpty(strQuery))
                return null;

            if (_connection == null || _connection.State == ConnectionState.Closed)
            {
                if (!Open())
                    return null;
            }

            try
            {
                DataTable dt = new DataTable();
                SqlDataReader reader;
                SqlCommand command = new SqlCommand(strQuery, _connection);

                command.CommandType = CommandType.Text;
                command.CommandTimeout = 50000;

                reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();

                return dt;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    }
}
