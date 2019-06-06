using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.DTO
{
    class Account
    {
        private string username;
        private string displayName;
        private string password;
        private string type;

        public string Username { get => username; set => username = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Password { get => password; set => password = value; }
        public string Type { get => type; set => type = value; }

        public Account(string username, string displayname, string password, string type)
        {
            this.Username = username;
            this.DisplayName = displayname;
            this.Password = password;
            this.Type = type;

        }
    }
}
