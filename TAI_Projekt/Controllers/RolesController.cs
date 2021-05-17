using Microsoft.AspNetCore.Mvc;
using TAI_Projekt.Repositories.IRepos;


namespace TAI_Projekt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRepoUser _repoUser;
        private readonly IRepoRole _repoRole;
        private readonly IRepoUserRole _repoUserRole;

        public RolesController(IRepoUser repoUser, IRepoRole repoRole, IRepoUserRole repoUserRole)
        {
            _repoUser = repoUser;
            _repoRole = repoRole;
            _repoUserRole = repoUserRole;
        }


        [HttpGet]
        public string Get()
        {
            return "It's working - ROLE";
        }
    }
}

