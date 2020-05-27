using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DTOs
{
    public class ReturnComponentDTO
    {
        public int componentId { get; set; }
        public int materialId { get; set; }
        public string materialName { get; set; }
        public int materialCategoryId { get; set; }
        public string materialCategory { get; set; }
        public int materialOptionId { get; set; }
        public string materialOption { get; set; }
        public int sectionId { get; set; }
        public string section { get; set; }
    }
}
