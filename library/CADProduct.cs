using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace library
{
    public class CADProduct
    {
        static string cadena = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        SqlConnection c = new SqlConnection(cadena);
    }

    public bool Create(ENProduct en)
    {
        
        return true;
    }
}
