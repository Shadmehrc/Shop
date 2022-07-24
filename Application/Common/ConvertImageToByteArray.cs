using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Common
{
   public class ConvertImageToByteArray
    {
        public async Task<byte[]> Get(IFormFile file)
        {
            await using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var fileBytes = ms.ToArray();
           // var s = Convert.ToBase64String(fileBytes);
            return fileBytes;
        }
    }
}
