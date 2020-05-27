using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DTOs
{
    public class MaterialDTO
    {
        public string Name { get; set; }
        public int MaterialCategoryId { get; set; }
        public int? FlyClassificationId { get; set; }
    }
}
