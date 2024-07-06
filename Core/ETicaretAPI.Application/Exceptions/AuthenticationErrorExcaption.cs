using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Exceptions
{
    public class AuthenticationErrorExcaption : Exception
    {
        public AuthenticationErrorExcaption():base("Kimlik doğrulama hatası")
        {
        }

        public AuthenticationErrorExcaption(string? message) : base(message)
        {
        }

        public AuthenticationErrorExcaption(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
