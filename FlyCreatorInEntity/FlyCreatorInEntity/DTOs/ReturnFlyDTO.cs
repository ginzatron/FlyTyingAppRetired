using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyCreator.DTOs
{
    public class ReturnFlyDTO
    {
        public int flyId { get; set; }
        public string flyName { get; set; }
        public int flyClassificationId { get; set; }
        public string flyClassification { get; set; }
        public IEnumerable<ReturnComponentDTO> components { get; set; }
    }
}
