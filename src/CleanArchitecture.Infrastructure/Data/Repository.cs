using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public Entity GetById<Entity>(int id) where Entity : BaseEntity
        {
            return _context.Set<Entity>().SingleOrDefault(e => e.Id == id);
        }

        public List<Entity> List<Entity>() where Entity : BaseEntity
        {
            return _context.Set<Entity>().ToList();
        }

        public Entity Add<Entity>(Entity entity) where Entity : BaseEntity
        {
            _context.Set<Entity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete<Entity>(Entity entity) where Entity : BaseEntity
        {
            _context.Set<Entity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update<Entity>(Entity entity) where Entity : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
