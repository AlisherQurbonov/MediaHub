using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mediahub.Mapper;
using mediahub.Models;
using mediahub.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mediahub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _mc;

        public ImageController(IImageService imageservice)
        {
          _mc = imageservice;
        }

    [HttpPost]
    [Route("{images}")]
    public async Task<IActionResult> PostImagesAsync([FromForm]NewImage image,IEnumerable<IFormFile> files)
    {
       
        var extensions = new string[] { ".jpg", ".png", ".svg", ".mp4",".Image" };
        var fileSize = 5242880; // 5MB in bytes

        if(files.Count() < 1 || files.Count() > 5)
        {
            return BadRequest("Can upload 1~5 files at a time.");
        }

        // extension validation
        foreach(var file in files)
        {
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if(!extensions.Contains(fileExtension))
            {
                return BadRequest($"{fileExtension} format file not allowed!");
            }

            if(file.Length > fileSize)
            {
                return BadRequest($"Max file size 5MB!");
            }
        }
        var taskEntity = image.ToImageEntity();
        var insertResult = await _mc.CreateImagesAsync(taskEntity);


        if(insertResult.IsSuccess)
        {
            return Ok();
        }

        return BadRequest(insertResult.Exception.Message);

    }

        [HttpGet]
        public async Task<IActionResult> QueryTasks([FromQuery]NewQueryImage query)
        {
            var tasks = await _mc.GetImagesAsync(title: query.Title,altext: query.AltText,contentType: query.ContentType);

            return Ok(tasks.Select(i =>
        {
            return new 
            {
                ContentType = i.ContentType,
                Size = i.Data.Length,
                Id = i.Id
            };
        }));
    }
     }
 }

//    [HttpGet("{images")]
//     public async Task<IActionResult> GetImageAsync([FromQuery]NewQueryImage image)
//     {
        
//         var images = await _mc.GetImagesAsync(title: image.Title,altext: image.AltText,contentType: image.ContentType);

//         return Ok(images.Select(i =>
//         {
//             return new 
//             {
//                 ContentType = i.ContentType,
//                 Size = i.Data.Length,
//                 Id = i.Id
//             };
//         }));
//     }
