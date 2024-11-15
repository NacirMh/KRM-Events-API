using KRM_Events_API.Model;
using KRM_Events_API.Models;
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

        public DbSet<Category> Categories { get; set; }
        public DbSet<ClientAnnouncer> CLientAnnouncers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CouponCode> CouponCodes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventRequest> EventRequests { get; set; }

        public DbSet<Favorite> Favorites { get; set; }  

        public DbSet<Hashtag> Hashtags { get; set; }

        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

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
            builder.Entity<Client>().ToTable("Clients");
            builder.Entity<Announcer>().ToTable("Announcers");
            builder.Entity<Admin>().ToTable("Admins");

            builder.Entity<EventHashtag>().HasKey(x => new { x.HashtagId, x.EventId });

            builder.Entity<EventHashtag>()
                .HasOne(x => x.Event)
                .WithMany(x => x.EventHashtags)
                .HasForeignKey(x => x.EventId);

            builder.Entity<EventHashtag>()
                .HasOne(eh => eh.Hashtag)
                .WithMany(h => h.EventHashtags)
                .HasForeignKey(eh => eh.HashtagId);


            builder.Entity<Favorite>().HasKey(f => new { f.EventId, f.ClientId });

            builder.Entity<Favorite>()
                .HasOne(f => f.Event)
                .WithMany(e => e.favorites)
                .HasForeignKey(f => f.EventId);

            builder.Entity<Favorite>()
               .HasOne(f => f.Client)
               .WithMany(c => c.favorites)
               .HasForeignKey(f => f.ClientId);

            builder.Entity<Opinion>()
                .HasOne(o => o.Event)
                .WithMany(e => e.Opinions)
                .HasForeignKey(o => o.EventId);

            builder.Entity<Opinion>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Opinions)
                .HasForeignKey(o => o.ClientId);

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
