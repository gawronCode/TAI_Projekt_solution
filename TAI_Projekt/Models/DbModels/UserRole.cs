using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TAI_Projekt.Models.DbModels
{
    public class UserRole
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime? CreationDate { get; set; }

    }
}
