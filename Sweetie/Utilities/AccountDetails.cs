using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweetie.Utilities
{
    public sealed class AccountDetails
    {
        private static readonly Lazy<AccountDetails>
            lazy =
            new Lazy<AccountDetails>
                (() => new AccountDetails());

        public static AccountDetails Instance { get { return lazy.Value; } }

        private String _token;

        public String Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;
            }
        }



        private AccountDetails()
        {
        }
    }
}
