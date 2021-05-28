using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TAI_Projekt.Models.DbModels;
using TAI_Projekt.Models.DtoModels;
using TAI_Projekt.Repositories.IRepos;


namespace TAI_Projekt.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IRepoUser _repoUser;
        private readonly IRepoRole _repoRole;

        public UsersController(IRepoUser repoUser, IRepoRole repoRole)
        {
            _repoUser = repoUser;
            _repoRole = repoRole;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoUser>>> GetAll()
        {
            var users = await _repoUser.GetAllAsync();
            if (users.Count == 0) return Ok(new List<DtoUser>());

            var dtoUsers = new List<DtoUser>();
            foreach (var user in users)
            {
                dtoUsers.Add(new DtoUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    SecondName = user.SecondName,
                    Age = user.Age,
                    Email = user.Email,
                    Phone = user.Phone,
                    RoleId = user.RoleId,
                    RoleName = user.RoleId == null ? null : (await _repoRole.GetByIdAsync((int) user.RoleId)).Name,
                    RoleAssignDate = user.RoleAssignDate
                });
            }

            return Ok(dtoUsers);
        }


        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<ActionResult<DtoUser>> GetById(int id)
        {
            var user = await _repoUser.GetByIdAsync(id);
            if (user == null) return NotFound("No data in database");

            var dtoUser = new DtoUser
            {
                Id = user.Id,
                Name = user.Name,
                SecondName = user.SecondName,
                Age = user.Age,
                Email = user.Email,
                Phone = user.Phone,
                RoleId = user.RoleId,
                RoleName = user.RoleId == null ? null : (await _repoRole.GetByIdAsync((int) user.RoleId)).Name,
                RoleAssignDate = user.RoleAssignDate
            };

            return Ok(dtoUser);
        }


        [HttpPost]
        public async Task<ActionResult> Add(DtoUser dtoUser)
        {

            if (string.IsNullOrEmpty(dtoUser.Name)) return UnprocessableEntity("Invalid data");
            if (string.IsNullOrEmpty(dtoUser.SecondName)) return UnprocessableEntity("Invalid data");
            if (string.IsNullOrEmpty(dtoUser.Email)) return UnprocessableEntity("Invalid data");
            if (string.IsNullOrEmpty(dtoUser.Phone)) return UnprocessableEntity("Invalid data");
            if (dtoUser.Age == 0 || dtoUser.Age == null) return UnprocessableEntity("Invalid data");


            var user = new User
            {
                Age = dtoUser.Age ?? default,
                CreationDate = DateTime.Now,
                Email = dtoUser.Email,
                Name = dtoUser.Name,
                Phone = dtoUser.Phone,
                SecondName = dtoUser.SecondName,
                RoleId = dtoUser.RoleId,
                RoleAssignDate = dtoUser.RoleId == null ? null : DateTime.Now
            };
            
            await _repoUser.CreateAsync(user);
            return CreatedAtRoute("GetUserById", new {user.Id}, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _repoUser.GetByIdAsync(id);
            if (user == null) return NotFound("No data in database");
            await _repoUser.DeleteAsync(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(DtoUser dtoUser, int id)
        {
            var user = await _repoUser.GetByIdAsync(id);
            if (user == null) return NotFound("No data in database");

            user.Name ??= dtoUser.Name;
            user.SecondName ??= dtoUser.SecondName;
            user.Age = dtoUser.Age ?? user.Age;
            user.Email ??= dtoUser.Email;
            user.Phone ??= dtoUser.Phone;

            await _repoUser.UpdateAsync(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(DtoUser dtoUser, int id)
        {
            var user = await _repoUser.GetByIdAsync(id);
            if (user == null) return NotFound("No data in database");

            if (dtoUser.RoleId != null)
            {
                user.RoleAssignDate = dtoUser.RoleId != user.RoleId ? DateTime.Now : user.RoleAssignDate;
            }
            else
            {
                user.RoleAssignDate = null;
            }
            user.RoleId = dtoUser.RoleId;

            await _repoUser.UpdateAsync(user);
            return Ok();
        }


    }
}
