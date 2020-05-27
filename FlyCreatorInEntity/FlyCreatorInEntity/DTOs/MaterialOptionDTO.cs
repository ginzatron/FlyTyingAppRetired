using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DTOs
{
    public class MaterialOptionDTO
    {
        public string Discriminator { get; set; }
        public string Value { get; set; }
    }
}
