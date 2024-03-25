using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            // Acceder a la cadena de conexión desde la configuración
            constring  = ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString;
        }

        public bool Create(ENProduct en)
        {
            SqlConnection c = new SqlConnection(constring);
            c.Open();
            //SqlCommand com = new SqlCommand("");
            // Implementa la lógica para crear un producto
            return true;
        }

        // Otros métodos para manipular productos pueden ir aquí
    }
}
