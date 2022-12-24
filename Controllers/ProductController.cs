using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TPAY.Data;
using TPAY.Models;

namespace TPAY.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
[EnableCors("EnableCors")]
[Produces("application/json")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    // private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ApplicationDbContext db, ILogger<ProductController> logger)
    {
        _db = db;

        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IQueryable<Product>> SaveProducts([FromBody] Product product)
    {
        try
        {
            _db.Product.Add(product);
            _db.SaveChanges();

            return new CreatedResult($"/product/{product.Id}", product);
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Unable to save product");

            return ValidationProblem(e.Message);
        }
    }

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public ActionResult<IQueryable<Product>> GetProducts()
    {
        var result = _db.Product as IQueryable<Product>;
        return Ok(result.Where(p => p.Status == true).OrderBy(p => p.Name));
    }
         
       
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> DeleteProduct([FromRoute] 
        Guid productId)
    {
        var productDb = _db.Product
            .FirstOrDefault(p => p.Id==productId);
 
        if (productDb == null) return NotFound();
 
        _db.Product.Remove(productDb);
        _db.SaveChanges();
 
        return NoContent();
    }
        
    [HttpGet("{productId:Guid}")]
       
    [ProducesResponseType(StatusCodes.Status200OK)]
        
    public ActionResult Find(Guid productId)
    {
        var productDb = _db.Product
            .FirstOrDefault(p => p.Id==productId);
 
        if (productDb == null) return NotFound();
 
             
 
        return  Ok(productDb.Name);
    }
        
   
         
}