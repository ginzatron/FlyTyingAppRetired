using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class Component
    {
        public int Id { get; set; }
        public int FlyId { get; set; }
        public Material Material { get; set; }
        public MaterialOption MaterialOption { get; set; }
        public Section Section { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
