using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mediahub.Entities
{
    public class Image
    {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(5242880)]
    public byte[] Data { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string ContentType { get; set; }
    
    [MaxLength(255)]
    public string AltText { get; set; }
      
    //   [Obsolete("Used only for entity binding.", true)]
    //   public Image() { }

    //     public Image( string title,byte[] data, string contentType="", string altText="")
    //     {
    //         Id = Guid.NewGuid();
    //         Title = title;
    //         Data = data;
    //         ContentType = contentType;
    //         AltText = altText;
    //     }
    }
}