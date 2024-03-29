using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CADCategory cat = new CADCategory();
                List<ENCategory> listacad = new List<ENCategory>();
                listacad = cat.readAll();

                foreach (ENCategory categoria in listacad)
                {
                    ListItem item = new ListItem();
                    item.Text = categoria.Name;
                    item.Value = categoria.id.ToString();
                    categoriasBD.Items.Add(item);
                }
            }
        }

        protected void LimpiarTextBox()
        {
            // Limpiar el contenido de los TextBox
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            amountTextBox.Text = "";
            priceTextBox.Text = "";
            dateTextBox.Text = "";
        }

        protected string categoria(int cat)
        {

            Dictionary<int, string> categoryMap = new Dictionary<int, string>()
            {
                { 1, "Computing" },
                { 2, "Telephony" },
                { 3, "Gaming" },
                { 4, "Home Appliances" }
            };

            return categoryMap.ContainsKey(cat) ? categoryMap[cat] : "";
        }

        protected string imprimirProducto(ENProduct prod)
        {
            return "Code: " + prod.Code + "<br/>Name: " + prod.Name
                    + "<br/>Amount: " + prod.Amount + "<br/>Category: " + categoria(prod.Category)
                    + "<br/>Price: " + prod.Price + "<br/>Creation Date: " + prod.CreationDate;
        }

        protected void createText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            try
            {
                ENProduct prod = new ENProduct();
                prod.Code = codeTextBox.Text;
                prod.Name = nameTextBox.Text;
                prod.Amount = int.Parse(amountTextBox.Text);
                prod.Category = categoriasBD.SelectedIndex + 1;
                prod.Price = float.Parse(priceTextBox.Text);
                prod.CreationDate = DateTime.Parse(dateTextBox.Text);

                prod.Create();
                salidaLabel.Text = "Se ha creado el producto correctamente.";
            }
            catch (ArgumentException ex)
            {
                // Manejar la excepción de las variables.
                salidaLabel.Text = "Argumento fuera de rango.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            catch (FormatException ex)
            {
                // Manejar la excepción de los Parse.
                salidaLabel.Text = "Error al introducir los datos.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones no previstas
                salidaLabel.Text = "No se realizo la acción correctamente.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            LimpiarTextBox();
        }

        protected void updateText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            try
            {
                ENProduct prod = new ENProduct();
                prod.Code = codeTextBox.Text;
                prod.Name = nameTextBox.Text;
                prod.Amount = Convert.ToInt32(amountTextBox.Text);
                prod.Category = categoriasBD.SelectedIndex + 1;
                prod.Price = Convert.ToInt32(priceTextBox.Text);
                prod.CreationDate = DateTime.Parse(dateTextBox.Text);

                if (prod.Update())
                {
                    salidaLabel.Text = "Se ha actualizado el producto correctamente.";
                }
                else
                {
                    salidaLabel.Text = "No hay ningun producto con ese código.";
                }
                
            }
            catch (ArgumentException ex)
            {
                // Manejar la excepción de las variables
                salidaLabel.Text = "Argumento fuera de rango.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            catch (FormatException ex)
            {
                // Manejar la excepción de las variables
                salidaLabel.Text = "Error al introducir los datos.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones no previstas
                salidaLabel.Text = "No se realizo la acción correctamente.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            LimpiarTextBox();
        }

        protected void deleteText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            try
            {
                prod.Code = codeTextBox.Text;
            }
            catch (ArgumentException ex)
            {
                salidaLabel.Text = "Argumento fuera de rango.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }

            if (prod.Delete())
            {
                salidaLabel.Text = "Se ha eliminado el producto correctamente.";
            }
            else
            {
                salidaLabel.Text = "No existe producto con ese código.";
            }
            
            LimpiarTextBox();
        }

        protected void readText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            try
            {
                prod.Code = codeTextBox.Text;

                if (prod.Read())
                {
                    mostrarProducto.Text = imprimirProducto(prod);
                    salidaLabel.Text = "<br/>Se ha leido el producto correctamente.";
                }
                else
                {
                    salidaLabel.Text = "No se ha podido leer el producto.";
                }
            }
            catch (ArgumentException ex)
            {
                salidaLabel.Text = "Argumento fuera de rango.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }

            LimpiarTextBox();
        }

        protected void readFirstText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();

            if (prod.ReadFirst())
            {
                mostrarProducto.Text = imprimirProducto(prod);
                salidaLabel.Text = "<br/>Se ha leido el producto correctamente.";
            }
            else
            {
                salidaLabel.Text = "No existe ningun producto en la base de datos.";
            }
            LimpiarTextBox();
        }

        protected void readNextText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            try
            {

                if (codeTextBox.Text == "" || codeTextBox.Text == null)
                {
                    throw new Exception("No se ha especificado ningun codigo de producto.");
                }
                else
                {
                    prod.Code = codeTextBox.Text;
                }

                if (prod.ReadNext())
                {
                    mostrarProducto.Text = imprimirProducto(prod);
                    salidaLabel.Text = "<br/>Se ha leido el producto correctamente.";
                }
                else
                {
                    salidaLabel.Text = "El producto seleccionado es el último de la base de datos.";
                }
            }
            catch (ArgumentException ex)
            {
                salidaLabel.Text = "Argumento fuera de rango.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            catch (Exception ex)
            {
                salidaLabel.Text = "Se debe elegir un código de producto.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            LimpiarTextBox();
        }

        protected void readPrevText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            try
            {
                
                if(codeTextBox.Text == "" || codeTextBox.Text == null)
                {
                    throw new Exception("No se ha especificado ningun codigo de producto.");
                }
                else
                {
                    prod.Code = codeTextBox.Text;
                }

                if (prod.ReadPrev())
                {
                    mostrarProducto.Text = imprimirProducto(prod);
                    salidaLabel.Text = "<br/>Se ha leido el producto correctamente.";
                }
                else
                {
                    salidaLabel.Text = "El producto seleccionado es el primero de la base de datos.";
                }
            }
            catch (ArgumentException ex)
            {
                salidaLabel.Text = "Argumento fuera de rango.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }
            catch (Exception ex)
            {
                salidaLabel.Text = "Se debe elegir un código de producto.";
                Console.WriteLine("Product operation has failed.Error: {0}" + ex.Message);
            }

            LimpiarTextBox();
        }
    }
}