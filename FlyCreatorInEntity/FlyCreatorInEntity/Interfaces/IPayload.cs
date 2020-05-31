using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Interfaces
{
    public interface IPayload
    {
        string Email { get; set; }
        string Subject { get; set; }
        string Issuer { get; set; }
    }
}
