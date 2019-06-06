using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DTO
{
    class Bill
    {
        private int id;
        private string dateCheckIn;
        private string dateCheckOut;
        private int status;
        private int total;

        public int Id { get => id; set => id = value; }
        public string DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public string DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Total { get => total; set => total = value; }

        public Bill(int id, string dateCheckIn, string dateCheckOut, int status, int total)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Total = total;
        }
    }
}
