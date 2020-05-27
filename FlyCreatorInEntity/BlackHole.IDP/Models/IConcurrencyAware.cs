using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackHole.IDP.Models
{
    public interface IConcurrencyAware
    {
        string ConcurrencyStamp { get; set; }
    }
}
