using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiProductorTweet.Models
{
    public class Data
    {
        [Key]
        public string NameUser { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string message { get; set; }
    }
}
