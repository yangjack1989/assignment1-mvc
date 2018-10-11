namespace Assignemnt1_project.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class nbaModel : DbContext
    {
        public nbaModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<team> teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<player>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<player>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<player>()
                .Property(e => e.salary)
                .HasPrecision(10, 0);

            modelBuilder.Entity<player>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<player>()
                .Property(e => e.points_per_game)
                .HasPrecision(4, 1);

            modelBuilder.Entity<player>()
                .Property(e => e.rebonds_per_game)
                .HasPrecision(4, 1);

            modelBuilder.Entity<player>()
                .Property(e => e.injury)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .Property(e => e.team_name)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .Property(e => e.conference)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .Property(e => e.owner)
                .IsUnicode(false);
        }
    }
}
