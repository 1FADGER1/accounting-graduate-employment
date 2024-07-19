using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace WebApplication2.Data
{
    public class WebApplication2Context : DbContext
    {
        public WebApplication2Context (DbContextOptions<WebApplication2Context> options)
            : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<form_education>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<gender>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<typeemployment>();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasPostgresEnum<form_education>();
            builder.HasPostgresEnum<gender>();
            builder.HasPostgresEnum<typeemployment>();
        }

        public DbSet<WebApplication2.Models.Student> Student { get; set; } = default!;

        public DbSet<WebApplication2.Models.Workplace>? Workplace { get; set; }
        public DbSet<WebApplication2.Models.Address>? Address { get; set; }

        public DbSet<WebApplication2.Models.Specialty>? Specialty { get; set; }

        public DbSet<WebApplication2.Models.EmploymentStatus>? EmploymentStatus { get; set; }
    }
}
