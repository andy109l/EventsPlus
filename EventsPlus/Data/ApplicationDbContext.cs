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
            modelBuilder.Entity<PosCitCou>()
                .HasMany(p => p.Organizer)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PosCitCou>()
                .HasMany(p => p.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PosCitCou>()
                .HasMany(p => p.VenueAddress)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PosCitCou>()
                .HasMany(p => p.GuestAttendee)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Organizer)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.VenueAddress)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.UserRegEvent)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.GuestRegEvent)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRegEvent)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GuestAttendee>()
                .HasMany(g => g.GuestRegEvent)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    } 
}
