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
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _repoUser.GetAllAsync();
            return Ok(users);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _repoUser.GetByIdAsync(id);
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult> Add(DtoUser dtoUser)
        {

            
            await _repoUser.CreateAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var user = await _repoUser.GetByIdAsync(id);
            await _repoUser.DeleteAsync(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(User user, int id)
        {
            var userToUpdate = await _repoUser.GetByIdAsync(id);
            userToUpdate.Age = user.Age;
            userToUpdate.Email = user.Email;
            userToUpdate.Name = user.Name;
            userToUpdate.SecondName = user.SecondName;
            userToUpdate.Phone = user.Phone;
            await _repoUser.UpdateAsync(userToUpdate);
            return Ok(userToUpdate);
        }



    }
}
