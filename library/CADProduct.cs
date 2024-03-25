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
        public string constring;

        public CADProduct()
        {
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        // Crea el producto en la base de datos
        public bool Create(ENProduct en)
        {
            bool retValue;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("insert into product values (" + en.Code + ", " + en.Name + ", " + en.Amount + ", " + en.Price + ", " + en.Category + ", " + en.CreationDate +");", c);
                com.ExecuteNonQuery();
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

        // Actualiza el producto en la base de datos
        public bool Update(ENProduct en)
        {
            bool retValue;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("update product set (" + en.Code + ", " + en.Name + ", " + en.Amount + ", " + en.Price + ", " + en.Category + ", " + en.CreationDate + ") where code = " + en.Code + ";", c);
                com.ExecuteNonQuery();
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

        // Crea el producto en la base de datos
        public bool Delete(ENProduct en)
        {
            bool retValue;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("delete from product where code = " + en.Code + ";", c);
                com.ExecuteNonQuery();
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

        // Devuelve el producto en la base de datos
        public bool Read(ENProduct en)
        {
            bool retValue;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("select * from producto where code = " + en.Code +  ");", c);
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

        // Devuelve el primer producto en la base de datos
        public bool ReadFirst(ENProduct en)
        {
            bool retValue;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("select * from producto where code = 1;", c);
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

        // Devuelve el producto siguiente en la base de datos
        public bool ReadNext(ENProduct en)
        {
            bool retValue;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                // Pasar a otra cadena el código del producto siguiente (+1 en la BBDD)
                int auxCode;
                int.TryParse(en.Code, out auxCode);
                auxCode++;
                string nextProduct = auxCode.ToString();

                c.Open();
                SqlCommand com = new SqlCommand("select * from producto where code = " + nextProduct + ");", c);
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

        // Devuelve el producto anterior en la base de datos
        public bool ReadPrev(ENProduct en)
        {
            bool retValue;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                // Pasar a otra cadena el código del producto anterior (-1 en la BBDD)
                int auxCode;
                int.TryParse(en.Code, out auxCode);
                auxCode--;
                string nextProduct = auxCode.ToString();

                c.Open();
                SqlCommand com = new SqlCommand("select * from producto where code = " + nextProduct + ");", c);
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
    }
}
