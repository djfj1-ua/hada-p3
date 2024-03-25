using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        public int id { get; set; }
        public string Name { get; set; }

        public ENCategory()
        {
            id = 0;
            Name = "";
        }

        public ENCategory(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }

        // LLama a la función de CADCategory para leer la categoría actual en la base de datos
        public bool Read()
        {
            CADCategory c = new CADCategory();

            if (c.Read(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // LLama a la función de CADProduct para leer todas las categorías en la base de datos
        public List<ENCategory> ReadAll()
        {
            CADCategory c = new CADCategory();

            return c.ReadAll(this);
        }
    }
}
