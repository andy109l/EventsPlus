using System;
using System.Collections.Generic;
using System.Text;
using EventsPlus.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventsPlus.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Event { get; set; }
        public DbSet<GuestAttendee> GuestAttendee { get; set; }
        public DbSet<GuestRegEvent> GuestRegEvent { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<PosCitCou> PosCitCou { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRegEvent> UserRegEvent { get; set; }
        public DbSet<VenueAddress> VenueAddress { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany(a => a.Events)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.GuestAttendees)
                .WithOne(a => a.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.VenueAddress)
                .WithMany(a => a.Events)
                .OnDelete(DeleteBehavior.Cascade);

        }
    } 
}
