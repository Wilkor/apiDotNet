using Microsoft.EntityFrameworkCore;
using newprojet.models;


namespace newprojet.Data 
{
  public class  DataContext : DbContext
  {
    public  DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get;set;}

  }
}