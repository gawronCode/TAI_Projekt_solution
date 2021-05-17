using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAI_Projekt.Models.DbModels
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
