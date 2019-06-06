using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DTO
{
    class BillInfo
    {
        private int id;
        private int idBill;
        private int idProduct;
        private int quantity;

        public BillInfo(int id, int idBill, int idProduct, int quantity)
        {
            this.Id = id;
            this.IdBill = idBill;
            this.IdProduct = idProduct;
            this.Quantity = quantity;

        }

        public int Id { get => id; set => id = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int IdProduct { get => idProduct; set => idProduct = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
