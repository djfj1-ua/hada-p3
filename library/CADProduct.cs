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
            bool retValue = false;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Products VALUES (@Name, @Code, @Amount, @Price, @Category, @CreationDate)", c);
                com.Parameters.AddWithValue("@Name", en.Name);
                com.Parameters.AddWithValue("@Code", en.Code);
                com.Parameters.AddWithValue("@Amount", en.Amount);
                com.Parameters.AddWithValue("@Price", en.Price);
                com.Parameters.AddWithValue("@Category", en.Category);
                com.Parameters.AddWithValue("@CreationDate", en.CreationDate);
                SqlDataReader dr = com.ExecuteReader();
                retValue = true;
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Excepcion con mensaje: " + ex.Message);
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
            bool retValue = false;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("UPDATE Products SET Name = @Name, Amount = @Amount, Price = @Price, Category = @Category, CreationDate = @CreationDate WHERE Code = @CodeParam", c);

                // Agregar parámetros al SqlCommand
                com.Parameters.AddWithValue("@Name", en.Name);
                com.Parameters.AddWithValue("@Amount", en.Amount);
                com.Parameters.AddWithValue("@Price", en.Price);
                com.Parameters.AddWithValue("@Category", en.Category);
                com.Parameters.AddWithValue("@CreationDate", en.CreationDate);
                com.Parameters.AddWithValue("@CodeParam", en.Code); // Parámetro para la cláusula WHERE
                int rowsAffected = com.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    retValue = true;
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
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
            bool retValue = true;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                
                if (!Read(en))
                {
                    retValue = false;
                }
                else
                {
                    SqlCommand com = new SqlCommand("DELETE FROM Products WHERE Code = @Code", c);
                    com.Parameters.AddWithValue("@Code", en.Code);
                    SqlDataReader dr = com.ExecuteReader();
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("No se ha podido borrar el producto: {0}", ex.Message);
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
            bool retValue = false;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Products WHERE code = @Code", c);
                com.Parameters.AddWithValue("@Code", en.Code);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.Read())
                {
                    en.Name = dr["Name"].ToString();
                    en.Amount = (int)dr["Amount"];
                    en.Category = (int)dr["Category"];
                    en.Price = Convert.ToSingle(dr["Price"]);
                    en.CreationDate = (DateTime)dr["CreationDate"];

                    retValue = true;
                }
                else
                {
                    retValue = false; // No se encontró ningún producto con ese código
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
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
            bool retValue = true;

            SqlConnection c = new SqlConnection(constring);
            try
            {
                c.Open();

                SqlCommand com = new SqlCommand("SELECT * FROM Products WHERE ID = (SELECT MIN(ID) FROM Products);", c);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                en.Code = dr["Code"].ToString();
                en.Name = dr["Name"].ToString();
                en.Amount = (int)dr["Amount"];
                en.Category = (int)dr["Category"];
                en.Price = Convert.ToSingle(dr["Price"]);
                en.CreationDate = (DateTime)dr["CreationDate"];
                dr.Close();

                retValue = Read(en);
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
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
                c.Open();
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE ID > (SELECT ID FROM Products WHERE Code = @ProductCode) ORDER BY ID ASC;", c);
                com.Parameters.AddWithValue("@ProductCode", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();

                en.Code = dr["Code"].ToString();

                retValue = Read(en);

                dr.Close();
                retValue = true;
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error: {0}.", ex.Message);
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
                c.Open();
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE ID < (SELECT ID FROM Products WHERE Code = @ProductCode) ORDER BY ID DESC;", c);
                com.Parameters.AddWithValue("@ProductCode", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                //Corregir excepcion de si no hay siguiente producto
                en.Code = dr["Code"].ToString();

                retValue = Read(en);

                dr.Close();
                retValue = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: {0}.", ex.Message);
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
