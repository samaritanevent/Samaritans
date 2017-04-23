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

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles")
                    .MapLeftKey("RoleId")
                    .MapRightKey("UserId"));

            modelBuilder.Entity<Attendee>()
	            .HasRequired(e => e.User)
                .WithMany(e => e.Attendances)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Attendee>()
				.HasRequired(e => e.Event)
				.WithMany(e => e.Participants)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Preferences)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId);


        }
    }

}