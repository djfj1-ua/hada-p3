using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace library
{
    public class CADCategory
    {
        public string constring { get; set; }

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        // Devuelve la categoría en la base de datos
        public bool Read(ENCategory en)
        {
            bool retValue = true;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("select * from categories where id = " + en.id + ");", c);
                SqlDataReader dr = com.ExecuteReader();

                // falta ver qué hacer con la fila leída
                dr.Read();
                dr.Close();
                retValue = true;
            }
            catch
            {
                retValue = false;
            }
            finally
            {
                c.Close();
            }

            return retValue;
        }

        // Devuelve todas las categorías de la base de datos
        public List<ENCategory> readAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("select * from categories;", c);
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    categories.Add(new ENCategory((int)dr["id"], dr["name"].ToString()));
                }

                dr.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            finally
            {
                c.Close();
            }

            return categories;
        }
    }
}
