using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace mediahub.Models
{
    public class NewImage
    {
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    
    [Required]
    [MaxLength(20)]
    public string ContentType { get; set; }
    
    [MaxLength(255)]
    public string AltText { get; set; }

     [Required]
     [Display(Name="File")]
    public IFormFile Data { get; set; }
      
    }
}