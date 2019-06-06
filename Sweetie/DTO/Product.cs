using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DTO
{
    class Product
    {

        private int id;
        private string name;
        private int idCategory;
        private int price;
        private string descript;
        private int remain;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Descript { get => descript; set => descript = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int Price { get => price; set => price = value; }
        public int Remain { get => remain; set => remain = value; }

        public Product() { }

        public Product(int id, string name, int idCategory, int price, string descript, int remain)
        {
            this.Id = id;
            this.Name = name;
            this.Descript = descript;
            this.IdCategory = idCategory;
            this.Price = price;
            this.Remain = remain;
        }

    }
}
