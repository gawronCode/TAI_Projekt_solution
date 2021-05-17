using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TAI_Projekt.Models.DbModels;
using TAI_Projekt.Repositories.IRepos;

namespace TAI_Projekt.Repositories.Repos
{
    public class RepoUser : IRepoUser
    {
        public Task<bool> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
