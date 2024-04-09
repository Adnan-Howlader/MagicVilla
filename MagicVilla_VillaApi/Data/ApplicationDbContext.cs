using MagicVilla_VillaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaApi.Data;

public class ApplicationDbContext:DbContext

{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        


    }
    DbSet<Villa> Villas { get; set; } 
    
    //add some instances to villa table
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Villa>().HasData(new Villa
        {
            Id = 1,
            Name = "Villa1",
            Details = "Villa1 Details",
            rate = 100,
            sqft = 1000,
            occupancy = true,
            imageurl = "",
            amenity = "Villa1 Amenities",
            CreatedDate = DateTime.Now,
            UpdateDate = DateTime.Now
        });
        modelBuilder.Entity<Villa>().HasData(new Villa
        {
            Id = 2,
            Name = "Villa2",
            Details = "Villa2 Details",
            rate = 200,
            sqft = 2000,
            occupancy = true,
            imageurl = "",
            amenity = "Villa2 Amenities",
            CreatedDate = DateTime.Now,
            UpdateDate = DateTime.Now
        });
        modelBuilder.Entity<Villa>().HasData(new Villa
        {
            Id = 3,
            Name = "Villa3",
            Details = "Villa3 Details",
            rate = 300,
            sqft = 3000,
            occupancy = true,
            imageurl = "",
            amenity = "Villa3 Amenities",
            CreatedDate = DateTime.Now,
            UpdateDate = DateTime.Now
        });
    }
    
}