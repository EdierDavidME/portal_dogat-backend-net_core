using System.Data;

namespace Dogat_backend_net_core.Utilities.Data
{
    public class Parser
    {
        public static T GetDataValue<T>(IDataReader objDataReader, string columnName) where T: IConvertible
        {
            int intOrdinal = objDataReader.GetOrdinal(columnName);

            if(!objDataReader.IsDBNull(intOrdinal))
                return (T)Convert.ChangeType(objDataReader.GetValue(intOrdinal), typeof(T));
            else
                return default(T);
        }

        public static object GetDataValue(IDataReader objDataReader, string columnName, Type type)
        {
            int intOrdinal = objDataReader.GetOrdinal(columnName);

            if (!objDataReader.IsDBNull(intOrdinal))
                return Convert.ChangeType(objDataReader.GetValue(intOrdinal), type);
            else
                return default(object);
        }
    }
}
