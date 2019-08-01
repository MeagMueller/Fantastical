using System;
using System.Collections.Generic;
using System.Text;
using Fantastical.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fantastical.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Creature> Creature { get; set; }
        // public DbSet<Comment> Comment { get; set; }
        // public DbSet<Favorite> Favorite { get; set; }
        //public DbSet<Creature> Creature { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            builder.Entity<ApplicationUser>().HasData(user);

            

            builder.Entity<Creature>().HasData(
                new Creature()
                    {
                        Id = 1,
                        Name = "Anansi",
                        Lore = "In West African lore, Anansi is a trickster character who often takes the shape of a spider and is considered the spirit of all knowledge of stories. Tales of Anansi were part of an exclusively oral tradition, which was fitting as he himself was seen as synonymous with skill and wisdom in speech.",
                        Region = "West Africa, Jamaica, United States",
                        ImagePath = "Anansi.jpg",
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                    },

                new Creature()
                    {
                        Id = 2,
                        Name = "Huginn and Muninn",
                        Lore = "Huginn and Muninn (Old Norse for 'thought' and 'memory' or 'mind', respectively) are a pair of ravens that fly all over Midgard (the world) in order to gather information and bring it to the god Odin. Scholars have linked the god's relation to Huginn and Muninn to the shamanic practice of going on a trance-like journey.",
                        Region = "Scandinavia",
                        ImagePath = "HuginnandMuninn.jpg",
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                    }
                );
            }
        }
    }

