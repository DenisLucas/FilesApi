using System;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.Infrastructure
{
    
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options): base(options)
        {

        }
        public DbSet<Files> File { get; set; }
    }
}
