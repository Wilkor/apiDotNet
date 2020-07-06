using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using newprojet.Data;
using newprojet.models;


namespace newprojet
{

  [ApiController]
  [Route("v1/Products")]
  public class ProductController : ControllerBase
  {
    [HttpGet]
    [Route("")]
   public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
   {
     var  products = await context.Products.Include(x => x.Category).ToListAsync();

     return products;

   }

    [HttpGet]
    [Route("{id:int}")]
   public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
   {
     var  product = await context.Products.Include(x => x.Category)
     .AsNoTracking()
     .FirstOrDefaultAsync(x => x.id == id);

     return product;

   }
    [HttpGet]
    [Route("categories/{id:int}")]
   public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] DataContext context, int id)
   {
     var  products = await context.Products.Include(x => x.Category)
      .AsNoTracking()
      .Where(x => x.CategoryId == id )
     .ToListAsync();

     return products;

   }


    [HttpPost]
    [Route("")]
   public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody]Product model)
   {
     if(ModelState.IsValid)
     {
       context.Products.Add(model);
       await context.SaveChangesAsync();
       return model;

     } else {
       return BadRequest(ModelState);
     }
      
   }

  }



}