using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
   public class ShowPhoneModel
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int InStock { get; set; }
        public int TotalSold { get; set; }
        public int TotalViewed { get; set; }
        public int Storage { get; set; }
        public string GraphicModel { get; set; }
        public string LcdModel { get; set; }
        public int Price { get; set; }
    }
}
