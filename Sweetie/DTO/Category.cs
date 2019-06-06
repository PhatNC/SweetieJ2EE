using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DTO
{
    class Category
    {

        private int id;
        private string name;
        private string descript;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Descript { get => descript; set => descript = value; }

        public Category(int id, string name, string descript)
        {
            this.Id = id;
            this.Name= name;
            this.Descript = descript;
        }

    }
}
