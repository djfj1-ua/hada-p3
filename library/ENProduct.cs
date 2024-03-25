using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code { get; set; }
        private string _name { get; set; }
        private int _amount { get; set; }
        private float _price { get; set; }
        private int _category { get; set; }
        private DateTime _creationDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public int Category { get; set; }
        public DateTime CreationDate { get; set; }

        public ENProduct()
        {
            this.Code = "0";
            this.Name = "";
            this.Amount = 0;
            this.Price = 0;
            this.Category = 0;
            this.CreationDate = DateTime.MinValue;
        }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this.Code = code;
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Category = category;
            this.CreationDate = creationDate;
        }

        // LLama a la función de CADProduct para crear el producto en la base de datos
        public bool Create()
        {
            CADProduct p = new CADProduct();

            if (p.Create(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // LLama a la función de CADProduct para actualizar el producto en la base de datos
        public bool Update()
        {
            CADProduct p = new CADProduct();

            if (p.Update(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // LLama a la función de CADProduct para borrar el producto en la base de datos
        public bool Delete()
        {
            CADProduct p = new CADProduct();

            if (p.Delete(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // LLama a la función de CADProduct para leer el producto actual en la base de datos
        public bool Read()
        {
            CADProduct p = new CADProduct();

            if (p.Read(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // LLama a la función de CADProduct para leer el primer producto en la base de datos
        public bool ReadFirst()
        {
            CADProduct p = new CADProduct();

            if (p.ReadFirst(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // LLama a la función de CADProduct para leer el producto siguiente en la base de datos
        public bool ReadNext()
        {
            CADProduct p = new CADProduct();

            if (p.ReadNext(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // LLama a la función de CADProduct para leer el producto anterior en la base de datos
        public bool ReadPrev()
        {
            CADProduct p = new CADProduct();

            if (p.ReadPrev(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
