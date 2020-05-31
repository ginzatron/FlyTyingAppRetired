using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Interfaces
{
    public class ExternalLogInToken : IExternalLogInToken
    {
        public string Id_Token { get; set; }
    }
}
