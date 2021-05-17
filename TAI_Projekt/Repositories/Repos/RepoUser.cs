using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAI_Projekt.Data;
using TAI_Projekt.Models.DbModels;
using TAI_Projekt.Repositories.IRepos;

namespace TAI_Projekt.Repositories.Repos
{
    public class RepoUser : IRepoUser
    {

        private readonly ApplicationDbContext _context;

        public RepoUser(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(User entity)
        {
            _context.Users.Remove(entity);
            return await SaveAsync();
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(q => q.Id == id);
            return user;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            return await SaveAsync();
        }
    }
}
