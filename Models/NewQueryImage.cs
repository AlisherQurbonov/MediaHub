using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace mediahub.Models
{
    public class NewQueryImage
    {
    [FromQuery]   
     public string Title { get; set; }
     
    [FromQuery] 
    [MinLength(1)]
    [MaxLength(5242880)]
    public byte[] Byte { get; set; }
    
     [FromQuery]
    public string ContentType { get; set; }
    
     [FromQuery]
    public string AltText { get; set; }
    }
}