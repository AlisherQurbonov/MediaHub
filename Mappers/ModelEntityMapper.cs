
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace mediahub.Mapper
{
    public static class ModelEntityMappers
   {
       public static Entities.Image ToImageEntity(this Models.NewImage image)
        
            =>   new Entities.Image()
            {
                Title= image.Title,
                Data = toByte(image.Data),
                AltText = image.AltText,
                ContentType = image.ContentType is null ? string.Empty : string.Join(',', image.ContentType)
            };
        

             private static byte[] toByte(IFormFile image)
        {
              var memoryStream = new MemoryStream();
              image.CopyToAsync(memoryStream);
             var result = memoryStream.ToArray();
             return result;
        }
   }

}