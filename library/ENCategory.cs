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
        //restricciones de variables (get,set)
        public ENCategory()
        {
            this.id = 0;
            this.Name = "";
        }

        public ENCategory(int id, string name)
        {
            this.id = id;
            this.Name = name;
        }
    }
}
