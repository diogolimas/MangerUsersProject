using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context{
    public class ManagerContext : DbContext{
        public ManagerContext()
        {}

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {}

        public virtual DbSet<User> Users { get; set; }


     /*    protected override void OnConfiguring(DbContextOptionsBuilder optionsnuilder)
        {
            optionsnuilder.UseSqlServer(@"Server=localhost;Database=ManagerUserAPI;User Id=SA;Password=Sql@server;");
        } */

            protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}