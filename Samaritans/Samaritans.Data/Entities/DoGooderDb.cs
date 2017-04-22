using System.Data.Entity;

namespace Samaritans.Data.Entities
{
    public class DoGooderDb : DbContext
    {
        public DoGooderDb()
            : base("name=DoGooderDb")
        {
        }


        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

        public virtual DbSet<Attendence> Attendence { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Availabilities)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Preferences)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Attendence>()
                .HasMany(e => e.Availabilities)
                .WithMany(e => e.Attendences)
                .Map(m => m.ToTable("AttendenceAvailabilities").MapLeftKey("AttendenceId").MapRightKey("AvailabilityId"));

            modelBuilder.Entity<Rating>()
                .HasRequired(e => e.Attendence)
                .WithRequiredDependent(e => e.Rating);

        }
    }

}