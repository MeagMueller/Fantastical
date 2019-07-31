using System;
using System.Collections.Generic;
using System.Text;
using Fantastical.Models;
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
        public DbSet<Note> Note { get; set; }
        // public DbSet<Comment> Comment { get; set; }
        // public DbSet<Favorite> Favorite { get; set; }
        //public DbSet<Creature> Creature { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            //base.OnModelCreating(builder);

            //ApplicationUser user = new ApplicationUser
            //{
                //FirstName = "Admin",
                //LastName = "Admin",
                //UserName = "admin@admin.com",
                //NormalizedUserName = "ADMIN@ADMIN.COM",
                //Email = "admin@admin.com",
                //NormalizedEmail = "ADMIN@ADMIN.COM",

            //}
        //}
    }
}
