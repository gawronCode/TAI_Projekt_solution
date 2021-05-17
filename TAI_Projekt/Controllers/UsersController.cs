using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TAI_Projekt.Models.DbModels;
using TAI_Projekt.Repositories.IRepos;


namespace TAI_Projekt.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly IRepoUser _repoUser;
        private readonly IRepoRole _repoRole;
        private readonly IRepoUserRole _repoUserRole;

        public UsersController(IRepoUser repoUser, IRepoRole repoRole, IRepoUserRole repoUserRole)
        {
            _repoUser = repoUser;
            _repoRole = repoRole;
            _repoUserRole = repoUserRole;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _repoUser.GetAllAsync();
            return Ok(users);
        }


        [HttpPost]
        public async Task<ActionResult> Add(User user)
        {
            await _repoUser.CreateAsync(user);
            return Ok();
        }


    }
}
