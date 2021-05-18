using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TAI_Projekt.Models.DbModels;
using TAI_Projekt.Repositories.IRepos;


namespace TAI_Projekt.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private readonly IRepoUser _repoUser;
        private readonly IRepoRole _repoRole;

        public RolesController(IRepoUser repoUser, IRepoRole repoRole)
        {
            _repoUser = repoUser;
            _repoRole = repoRole;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var roles = await _repoRole.GetAllAsync();
            return Ok(roles);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var role = await _repoRole.GetByIdAsync(id);
            return Ok(role);
        }


        [HttpPost]
        public async Task<ActionResult> Add(Role role)
        {
            await _repoRole.CreateAsync(role);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _repoRole.GetByIdAsync(id);
            await _repoRole.DeleteAsync(role);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(Role role, int id)
        {
            var roleToUpdate = await _repoRole.GetByIdAsync(id);
            roleToUpdate.Name = role.Name;
            await _repoRole.UpdateAsync(roleToUpdate);
            return Ok(roleToUpdate);
        }
    }
}

