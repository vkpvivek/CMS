using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class Location
    {
        [Key]
        public int locId { get; set; }
        public String locName { get; set; }

    }
}
