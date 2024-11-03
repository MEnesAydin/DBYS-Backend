using DerslikBilgiSistemi.Entity;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;

namespace Repositories.EFCore;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) :
        base(options)
    {
        
    }
    public DbSet<ClassRoom> ClassRooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CoursePosition> CoursePositions { get; set; }
    public DbSet<CourseProgram> CoursePrograms { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Rank> Ranks { get; set; }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    
}