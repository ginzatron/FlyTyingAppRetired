using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class Component : BaseEntity
    {
        public Fly Fly { get; set; }
        public Material Material { get; set; }
        public MaterialOption MaterialOption { get; set; }
        public Section Section { get; set; }
    }
}
