using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAI_Projekt.Models.DbModels;
using TAI_Projekt.Repositories.IRepos;

namespace TAI_Projekt.Repositories.Repos
{
    public class RepoRole : IRepoRole
    {
        public Task<bool> Create(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
