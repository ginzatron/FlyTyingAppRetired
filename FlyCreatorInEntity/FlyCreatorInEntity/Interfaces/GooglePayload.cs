using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Interfaces
{
    public class GooglePayload : IPayload
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Issuer { get; set; }
    }
}
