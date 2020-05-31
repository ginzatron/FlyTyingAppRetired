using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Interfaces
{
    public interface ITokenValidator
    {
        bool ValidateToken(IPayload payload);
        IPayload GeneratePayload(IExternalLogInToken token);
    }
}
