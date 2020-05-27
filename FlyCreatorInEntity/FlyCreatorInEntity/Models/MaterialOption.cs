using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class MaterialOption
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Discriminator { get; set; }
        public string Value { get; set; }
    }
}
