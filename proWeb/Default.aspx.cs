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
            CADCategory cat = new CADCategory();
            List<ENCategory> listacad = new List<ENCategory>();
            listacad = cat.readAll();

            foreach(ENCategory categoria in listacad)
            {
                ListItem item = new ListItem();
                item.Text = categoria.Name;
                item.Value = categoria.id.ToString();
                categoriasBD.Items.Add(item);
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
                prod.Amount = Convert.ToInt32(amountTextBox.Text);
                prod.Category = categoriasBD.SelectedIndex + 1;
                prod.Price = Convert.ToInt32(priceTextBox.Text);

                DateTime fecha;

                string formatoFecha = "dd/MM/yyyy"; // Define el formato deseado
                if (DateTime.TryParseExact(dateTextBox.Text, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    prod.CreationDate = fecha;
                }
                else
                {
                    throw new FormatException("Formato de fecha y hora no válido. Debe ser dd/mm/aaaa hh:mm:ss");
                }

                prod.Create();
                salidaLabel.Text = "Se ha creado el producto correctamente.";
            }
            catch (FormatException ex)
            {
                // Manejar la excepción de formato de fecha
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones no previstas
                Console.WriteLine("Se produjo una excepción: " + ex.Message);
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

                DateTime fecha;

                string formatoFecha = "dd/MM/yyyy"; // Define el formato deseado
                if (DateTime.TryParseExact(dateTextBox.Text, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    prod.CreationDate = fecha;
                }
                else
                {
                    throw new FormatException("Formato de fecha y hora no válido. Debe ser dd/mm/aaaa hh:mm:ss");
                }

                if (prod.Update())
                {
                    salidaLabel.Text = "Se ha actualizado el producto correctamente.";
                }
                else
                {
                    salidaLabel.Text = "No hay ningun producto con ese código.";
                }
                
            }
            catch (FormatException ex)
            {
                // Manejar la excepción de formato de fecha
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones no previstas
                Console.WriteLine("Se produjo una excepción: " + ex.Message);
            }
            LimpiarTextBox();
        }

        protected void deleteText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            prod.Code = codeTextBox.Text;
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
            LimpiarTextBox();
        }

        protected void readFirstText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            prod.Code = codeTextBox.Text;
            if (prod.ReadFirst())
            {
                mostrarProducto.Text = imprimirProducto(prod);
                salidaLabel.Text = "<br/>Se ha leido el producto correctamente.";
            }
            else
            {
                salidaLabel.Text = "No se ha podido leer el producto.";
            }
            LimpiarTextBox();
        }

        protected void readNextText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            prod.Code = codeTextBox.Text;
            if (prod.ReadNext())
            {
                mostrarProducto.Text = imprimirProducto(prod);
                salidaLabel.Text = "<br/>Se ha leido el producto correctamente.";
            }
            else
            {
                salidaLabel.Text = "No se ha podido leer el producto.";
            }
            LimpiarTextBox();
        }

        protected void readPrevText(object sender, EventArgs e)
        {
            mostrarProducto.Text = "";
            ENProduct prod = new ENProduct();
            prod.Code = codeTextBox.Text;
            if (prod.ReadPrev())
            {
                mostrarProducto.Text = imprimirProducto(prod);
                salidaLabel.Text = "<br/>Se ha leido el producto correctamente.";
            }
            else
            {
                salidaLabel.Text = "No se ha podido leer el producto.";
            }
            LimpiarTextBox();
        }
    }
}