using FlyCreator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class GoogleToken : IExternalLogInToken
    {
        public string Id_Token { get; set; }
    }
}
