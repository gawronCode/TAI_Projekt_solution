using System;
using System.Collections;
using System.Collections.Generic;
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
            if (users.Count == 0) return NotFound("No data in database");

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
                    RoleName = user.RoleId == null ? null : (await _repoRole.GetByIdAsync((int)user.RoleId)).Name,

                });
            }

            return Ok(dtoUsers);
        }

        
        [HttpGet("{id}")]
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
            };

            return Ok(dtoUser);
        }


        [HttpPost]
        public async Task<ActionResult> Add(DtoUser dtoUser)
        {
            var user = new User
            {
                Age = dtoUser.Age ?? default,
                CreationDate = DateTime.Now,
                Email = dtoUser.Email,
                Name = dtoUser.Name,
                Phone = dtoUser.Phone,
                SecondName = dtoUser.SecondName,
                RoleId = dtoUser.RoleId
            };
            
            await _repoUser.CreateAsync(user);
            return Ok();
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

            user.Name = dtoUser.Name ?? user.Name;
            user.SecondName = dtoUser.SecondName ?? user.Name;
            user.Age = dtoUser.Age ?? user.Age;
            user.Email = dtoUser.Email ?? user.Email;
            user.Phone = dtoUser.Phone ?? user.Phone;
            user.RoleId = dtoUser.RoleId ?? user.RoleId;

            await _repoUser.UpdateAsync(user);
            return Ok();
        }



    }
}
