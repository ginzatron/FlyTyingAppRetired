using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MaterialCategory MaterialCategory { get; set; }
        public FlyClassification FlyClassification { get; set; }
        public IEnumerable<MaterialOption> MaterialOptions { get; set; }
    }
}
