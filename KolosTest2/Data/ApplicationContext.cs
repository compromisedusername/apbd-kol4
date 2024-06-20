using KolosTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace KolosTest2.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext(){}
    public ApplicationContext(DbContextOptions options) : base(options){}

    
    public DbSet<Backpack> Backpacks { get; set; } 
    public DbSet<Character> Characters  { get; set; } 
    public DbSet<CharacterTitle> CharacterTitles   { get; set; } 
    public DbSet<Item> Items   { get; set; } 
    public DbSet<Title> Titles   { get; set; } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Item1",
                Weight = 1,
            },
            new Item
            {
                Id = 2,
                Name = "Item2",
                Weight = 2,
            },
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
                new Character
                {
                    Id = 1,
                    FirstName = "Fname1",
                    LastName = "Lname1",
                    CurrentWeight = 1,
                    MaxWeight = 3,
                },
                new Character
                {
                    Id = 2,
                    FirstName = "Fname2",
                    LastName = "Lname2",
                    CurrentWeight = 3,
                    MaxWeight = 5,
                },

        });
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
                new Title
                {
                    Id = 1,
                    Name = "Title1",
                },
                new Title
                {
                    Id = 2,
                    Name = "Title2",
                },

        });
        
      
          modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
                new Backpack
                {
                    CharacterId = 1,
                    ItemId = 1,
                    Amount = 1,
                },
                new Backpack
                {
                    CharacterId = 1,
                    ItemId = 2,
                    Amount = 1,
                },
                new Backpack
                {
                    CharacterId = 2,
                    ItemId = 1,
                    Amount = 1,
                },  new Backpack
                {
                    CharacterId = 2,
                    ItemId = 2,
                    Amount = 1,
                },

        });
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
                new CharacterTitle
                {
                    TitleId = 1,
                    CharactedId = 1,
                    AcquiredAt = DateTime.Now.AddDays(2)
                },
                new CharacterTitle
                {
                    TitleId = 2,
                    CharactedId = 2,
                    AcquiredAt = DateTime.Now.AddDays(2)
                },
        });

    }
    
}