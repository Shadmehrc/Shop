using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Laptop
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int InStock { get; set; }
        public int TotalSold { get; set; }
        public int TotalViewed { get; set; }
        public int StorageSize { get; set; }
        public string GraphicModel { get; set; }
        public string CpuModel { get; set; }
        public int Ram { get; set; }
    }
}
