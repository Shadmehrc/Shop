using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Common
{
   public class ConvertImageToByteArray
   {
       //private readonly ILogger<ConvertImageToByteArray> _logger;

       //public ConvertImageToByteArray(ILogger<ConvertImageToByteArray> logger)
       //{
       //    _logger = logger;
       //}

       public async Task<byte[]> Get(IFormFile file)
        {

            try
            {
                
                await using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                // var s = Convert.ToBase64String(fileBytes);
                return fileBytes;
            }
            catch (Exception e)
            {
                //_logger.LogError(e,e.Message);
                throw;
            }
        }
    }
}
