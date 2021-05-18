using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAI_Projekt.Models.DtoModels
{
    public class DtoUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
