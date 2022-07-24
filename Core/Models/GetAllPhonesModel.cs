using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Models
{
   public  class GetAllPhonesModel
    {
        public int PageNumber { get; set; }
        public int ItemPerPage { get; set; }
    }
}
