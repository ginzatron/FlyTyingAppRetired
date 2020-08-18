using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class MaterialOption
    {
        public Guid Id { get; set; }
        public Material ParentMaterial { get; set; }
        public string Discriminator { get; set; }
        public string Value { get; set; }
    }
}
