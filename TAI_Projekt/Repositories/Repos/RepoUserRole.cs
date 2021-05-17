using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAI_Projekt.Models.DbModels;
using TAI_Projekt.Repositories.IRepos;

namespace TAI_Projekt.Repositories.Repos
{
    public class RepoUserRole : IRepoUserRole
    {
        public Task<bool> Create(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<UserRole>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
