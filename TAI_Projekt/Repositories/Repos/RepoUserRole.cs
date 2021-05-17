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
    public class RepoUserRole : IRepoUserRole
    {

        private readonly ApplicationDbContext _context;

        public RepoUserRole(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(UserRole entity)
        {
            await _context.UserRoles.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(UserRole entity)
        {
            _context.UserRoles.Remove(entity);
            return await SaveAsync();
        }

        public async Task<ICollection<UserRole>> GetAllAsync()
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            return userRoles;
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(q => q.Id == id);
            return userRole;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(UserRole entity)
        {
            _context.UserRoles.Update(entity);
            return await SaveAsync();
        }
    }
}
