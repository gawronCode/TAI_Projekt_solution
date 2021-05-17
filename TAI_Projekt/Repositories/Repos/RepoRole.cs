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
    public class RepoRole : IRepoRole
    {

        private readonly ApplicationDbContext _context;

        public RepoRole(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Role entity)
        {
            await _context.Roles.AddAsync(entity);
            return await SaveAsync();

        }

        public async Task<bool> DeleteAsync(Role entity)
        {
            _context.Roles.Remove(entity);
            return await SaveAsync();
        }

        public async Task<ICollection<Role>> GetAllAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(q => q.Id == id);
            return role;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(Role entity)
        {
            _context.Roles.Update(entity);
            return await SaveAsync();
        }
    }
}
