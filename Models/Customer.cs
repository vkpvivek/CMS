using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class Customer
    {
        [Key]
        public int cusId { get; set; }
        public string cusName { get; set; }
        public string cusAdd { get; set; }
        public string cusGender { get; set; }
        public int cusAge { get; set; }
        public string cusImage { get; set; }

        
        public bool IsActive { get; set; }
        [NotMapped]
        public IFormFile cusImageFile { get; set; }
        public Location Location  { get; set; }

    }
}
