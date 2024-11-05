using KRM_Events_API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KRM_Events_API.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name = "Client",
                    NormalizedName = "CLIENT"
                },
                new IdentityRole()
                {
                    Name = "Announcer",
                    NormalizedName = "ANNOUNCER"
                },

            };

            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<Favorite>().HasKey(f => new { f.EventId, f.ClientId });

            builder.Entity<Favorite>()
                .HasOne(f => f.Event)
                .WithMany(e => e.favorites)
                .HasForeignKey(f => f.EventId);

            builder.Entity<Favorite>()
               .HasOne(f => f.Client)
               .WithMany(c => c.favorites)
               .HasForeignKey(f => f.ClientId);

            builder.Entity<Opinion>().HasKey(o => new { o.EventId, o.ClientId });

            builder.Entity<Opinion>()
                .HasOne(o => o.Event)
                .WithMany(e => e.Opinions)
                .HasForeignKey(o => o.EventId);

            builder.Entity<Opinion>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Opinions)
                .HasForeignKey(o => o.ClientId);

            builder.Entity<Ticket>().HasKey(t => new { t.EventId , t.ClientId});
            builder.Entity<Ticket>()
                .HasOne(o => o.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(o => o.EventId);
            builder.Entity<Ticket>()
               .HasOne(o => o.Client)
               .WithMany(c => c.Tickets)
               .HasForeignKey(o => o.ClientId);

            builder.Entity<ClientAnnouncer>().HasKey(x => new { x.AnnouncerId, x.ClientId });

            builder.Entity<ClientAnnouncer>()
                .HasOne(af=>af.Announcer)
                .WithMany(a=>a.ClientAnnouncers)
                .HasForeignKey(af=>af.AnnouncerId);

            builder.Entity<ClientAnnouncer>()
                .HasOne(af => af.Client)
                .WithMany(c => c.ClientAnnouncers)
                .HasForeignKey(af => af.ClientId);

        }


    }
}
