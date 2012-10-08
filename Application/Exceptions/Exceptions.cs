using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    
    public class AccountNotFoundException : Exception {
        public AccountNotFoundException(string message) : base(message) {}
    }

    public class InvalidParametersException : Exception {
        public InvalidParametersException(string message) : base(message) {}
    }

}
