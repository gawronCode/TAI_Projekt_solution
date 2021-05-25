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
    public class RolesController : ControllerBase
    {

        private readonly IRepoRole _repoRole;

        public RolesController(IRepoRole repoRole)
        {
            _repoRole = repoRole;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoRole>>> GetAll()
        {
            var roles = await _repoRole.GetAllAsync();
            if(roles.Count == 0) return NotFound("No data in database");

            var dtoRoles = roles.Select(role => 
                new DtoRole {Description = role.Description, Name = role.Name, Id = role.Id}).ToList();

            return Ok(dtoRoles);

        }

        [HttpGet("{id}", Name = "GetRoleByID")]
        public async Task<ActionResult<DtoRole>> GetById(int id)
        {
            var role = await _repoRole.GetByIdAsync(id);
            if(role == null) return NotFound("No data in database");
            return Ok(new DtoRole
            {
                Description = role.Description,
                Name = role.Name,
                Id = role.Id
            });
        }


        [HttpPost]
        public async Task<ActionResult> Add(DtoRole dtoRole)
        {
            var role = new Role
            {
                Description = dtoRole.Description,
                Name = dtoRole.Name
            };

            await _repoRole.CreateAsync(role);
            return CreatedAtRoute("GetRoleByID", new {role.Id}, role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _repoRole.GetByIdAsync(id);
            if (role == null) return NotFound("No data in database");
            await _repoRole.DeleteAsync(role);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(DtoRole dtoRole, int id)
        {
            var roleToUpdate = await _repoRole.GetByIdAsync(id);
            if (roleToUpdate == null) return NotFound("No data in database");
            roleToUpdate.Name ??= dtoRole.Name;
            roleToUpdate.Description ??= dtoRole.Description;
            await _repoRole.UpdateAsync(roleToUpdate);
            return NoContent();
        }
    }
}

