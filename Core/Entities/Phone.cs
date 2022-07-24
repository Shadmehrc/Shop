using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
   public class Phone
    {
        [Display(Description = "آیدی محصول")]
        public int Id { get; set; }


        [Display(Description = "مدل محصول")]
        [Required]
        public string Model{ get; set; }


        [Display(Description = "برند تولید کننده ")]
        [Required]
        public string Brand{ get; set; }


        [Required]
        [Display(Description = "تعداد موجودی")]
        public int InStock { get; set; }


        [Required]
        [Display(Description = "تعداد فروخته شده")]
        public int TotalSold { get; set; } = 0;


        [Display(Description = "دفعات مشاهده شده")]
        public int TotalViewed { get; set; } = 0;

        [Required]
        [Display(Description = "مقدار حافظه محصول")]
        public int Storage { get; set; }

        [Required]
        [Display(Description = "مدل گرافیک محصول")]
        public string GraphicModel { get; set; }

        [Required]
        [Display(Description = "نوع صفحه نمایش")]
        public string LcdModel { get; set; }

        [Required]
        [Display(Description = "قیمت به تومان")]
        public int Price { get; set; }

        public byte[] Photo { get; set; }

        public bool IsRemoved { get; set; } = false;
    }
}
