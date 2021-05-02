using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HM_RECORD.Model
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string PhoneNo { get; set; }
    }
}
