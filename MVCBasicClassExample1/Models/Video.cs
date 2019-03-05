using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasicClassExample1.Models
{
    public class Video
    {
        public int Id { get; set; }
        [Required, MinLength(5)]
        public string Title { get; set; }
        [Display(Name = "Film Genre")]
        public string Genre { get; set; }
        

    }
}
