using Dogat_backend_net_core.Models;
using Dogat_backend_net_core.Utilities.Conection;

namespace Dogat_backend_net_core.Adapters
{
    public class PublicacionesAdapter: IPublicacionesAdapter
    {

        public List<Paises> GetPaises()
        {
            List <Paises> listPaises = new List <Paises>();

            string strQuery = "SELECT *From Paises";

            ConectionManager objConnection = new ConectionManager();

            using (var objDataReader = objConnection.GetDataReader(strQuery))
            {
                while (objDataReader.Read())
                {
                    Paises pais = new Paises();
                    PaisesParser.Parse(ref pais, objDataReader);
                    listPaises.Add(pais);
                }
            }
            return listPaises;
        }
    }
}
