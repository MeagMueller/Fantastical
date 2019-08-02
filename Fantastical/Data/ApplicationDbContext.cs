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

            ApplicationUser admin = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin@Admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "Admin@Admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHash.HashPassword(admin, "Admin8*");
            builder.Entity<ApplicationUser>().HasData(admin);


            ApplicationUser user = new ApplicationUser
            {
                FirstName = "This",
                LastName = "Guy",
                UserName = "ThisGuy@ThisGuy.com",
                NormalizedUserName = "THISGUY@THISGUY.COM",
                Email = "ThisGuy@ThisGuy.com",
                NormalizedEmail = "THISGUY@THISGUY.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "5r423999-f4g5-93i4-2rtt-255re563256",
                Id = "12345678-wega-werw-jyjt-kepsfienqp"
            };
            var passwordHash1 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash1.HashPassword(user, "DragonsAreCool");
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
                    },

                    new Creature()
                    {
                        Id = 3,
                        Name = "Mothman",
                        Lore = "Mothman is a Cryptid out of West Virginia in the United States. He was first spotted in November 1966 by five men digging a grave in a cemetery near Clendenin, and was described as a man-like figure flying low over their heads. Several days later, he was seen again, this time by two couples who reported a large, gray, flying man with ten-foot wings whose eyes glowed red and who followed their car for some time. A little over a year later in December 1967, the Silver Bridge, which spanned the Ohio river between Point Pleasant, West Virginia, and Gallipolis, Ohio, collapsed and Mothman was connected to the tragedy. Today, Mothman is one of the more well known Cryptids, thanks to books, movies, a statue and a museum dedicated to him in Point Pleasant.There is even a festival held in September every year by the museum and people flock to see speakers, cosplay, and fun activities for kids.",
                        Region = "West Virginia",
                        ImagePath = "Mothman.jpg",
                        UserId = "12345678-wega-werw-jyjt-kepsfienqp"
                    },

                    new Creature()
                    {
                        Id = 4,
                        Name = "Unicorn",
                        Lore = "The Unicorn is a legendary creature, often described as a white horse-like animal with a long spiral horn and cloven hooves. The first known depictions are found in the areas of the Indus Valley Civilization, and are mentioned with some frequency in the annals of Greek history. Interestingly, they are mentioned in accounts of natural history rather than mythology because they were believed by the Greeks to have truly existed in faraway lands. In the Middle Ages and Renaissance, it was said that the unicorn could only be tamed by a virgin, and was emblematic of chaste love and faithful marriage.The horns were said to be made of a substance called alicorn, and it was believed they held magical, medicinal properties.",
                        Region = "Europe",
                        ImagePath = "Unicorn.jpg",
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                    },

                    new Creature()
                    {
                        Id = 5,
                        Name = "Wyvern",
                        Lore = "A Wyvern is a legendary, bipedal dragon with a tail often ending in a diamond or arrow shaped tip. The creature frequently appears in heraldry and literature, video games, and modern fantasy. There is very little differentiation between Wyverns and Dragons, the key difference being the number of legs.",
                        Region = "Europe",
                        ImagePath = "Wyvern.jpg",
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                    },

                    new Creature()
                    {
                        Id = 6,
                        Name = "Sphinx",
                        Lore = "A Sphinx is a mystical creature with the head of a human and the body of a lion and, sometimes, the wings of a bird. In Greek mythology, those who could not answer the Sphinx's riddles were eaten. In Egyptian, the Sphinx was regarded more as a benevolent creature, but both were often viewed as guardians of temples.",
                        Region = "Persia, Greece, and Egypt",
                        ImagePath = "Sphinx.jpg",
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                    },

                    new Creature()
                    {
                        Id = 7,
                        Name = "Kraken",
                        Lore = "A Kraken is a giant cephalopod-like sea-monster in Scandinavian folklore, said to haunt the coasts of Greenland and Norway in order to terrorize unwary sailors.",
                        Region = "Scandinavia",
                        ImagePath = "Kraken.jpg",
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                    },

                    new Creature()
                    {
                        Id = 8,
                        Name = "Black Dog",
                        Lore = "A Black Dog is a spectral entity found primarily in the folklore of the British Isles. It is a nocturnal apparition often described as a ghost or hellhound, and was said to be an enormous dog with glowing eyes. Its appearance was frequently regarded as a portent of death, and is associated with crossroads, places of execution, and ancient pathways. It is difficult to discern where exactly the tales of the Black Dog began, but throughout European mythology, dogs have been associated with death.",
                        Region = "British Isles",
                        ImagePath = "BlackDog.jpg",
                        UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                    },

                    new Creature()
                    {
                        Id = 9,
                        Name = "Thunderbird",
                        Lore = "The Thunderbird is a legendary creature in certain North American Indigenous Peoples' culture and history. It is a being of power and strength, and is most frequently depicted in the art, songs, and oral history of the Pacific Northwest Coast cultures, but also can be found in others. In mythology, the Thunderbird controls the upper world while the underworld is controlled by the Underwater Panther or Great Horned Serpent. In other mythologies, the Thunderbirds reside on a great floating mountain and control the rain and hail and are regarded as warriors, and are the enemies of the Great Horned Snakes.",
                        Region = "Pacific Northwest Coast",
                        ImagePath = "Thunderbird.jpg",
                        UserId = "12345678-wega-werw-jyjt-kepsfienqp"
                    }

                );
            }
        }
    }

