using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationary_shop
{
    class Merchandise
    {
        public Merchandise(string kategory, string name, double price)
        {
            this.kategory = kategory;
            this.name = name;
            this.price = price;
        }

        public string Kategory
        {
            get { return kategory; }
            set { kategory = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private string kategory;
        private string name;
        private double price;
    }
}
