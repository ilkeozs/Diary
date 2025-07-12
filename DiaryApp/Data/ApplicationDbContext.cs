using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<DiaryEntry> DiaryEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var seedDate = new DateTime(2025, 7, 12);

        modelBuilder.Entity<DiaryEntry>().HasData(
            new DiaryEntry
            {
                Id = 1,
                Title = "First Diary Entry",
                Content = "This is the content of the first diary entry. This is a test entry to see if the data is being saved correctly.",
                CreatedAt = seedDate
            },
            new DiaryEntry
            {
                Id = 2,
                Title = "Second Diary Entry",
                Content = "This is the content of the second diary entry. This is a test entry to see if the data is being saved correctly.",
                CreatedAt = seedDate.AddDays(1)
            },
            new DiaryEntry
            {
                Id = 3,
                Title = "Third Diary Entry",
                Content = "This is the content of the third diary entry. This is a test entry to see if the data is being saved correctly.",
                CreatedAt = seedDate.AddDays(2)
            }
            );
    }
}