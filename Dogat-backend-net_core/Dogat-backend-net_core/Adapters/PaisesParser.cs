using Dogat_backend_net_core.Models;
using Dogat_backend_net_core.Utilities.Data;
using System.Data;

namespace Dogat_backend_net_core.Adapters
{
    public class PaisesParser : Parser
    {
        public static Paises Parse(ref Paises paises, IDataReader reader)
        {
            paises.Id = GetDataValue<int>(reader, "Id");
            paises.Nombre = GetDataValue<string>(reader, "Nombre");

            return paises;
        }
    }
}
