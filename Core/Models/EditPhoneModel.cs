using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Models
{
    public class EditPhoneModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int InStock { get; set; }
        public int TotalSold { get; set; } = 0;
        public int Storage { get; set; }
        public string GraphicModel { get; set; }
        public string LcdModel { get; set; }
        public int Price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
