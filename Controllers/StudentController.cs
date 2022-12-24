using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using TPAY.Data;

namespace TPAY.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
[EnableCors("EnableCors")]
[Produces("application/json")]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    private readonly ILogger<StudentController> _logger;


    public StudentController(ApplicationDbContext db, ILogger<StudentController> logger)
    {
        _db = db;
        _logger = logger;
            
    }

         
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [Produces("application/json")]
    public IActionResult GetStudent([FromQuery]  string Email)
    {
             
            
        var studentRequest = new RestClient($"https://srms.ttuportal.com/api/student/email/{Email}");
           
  t      var studentData = new RestRequest(Method.GET);
        studentData.AddHeader("Content-type", "application/json");
        var requestRun= studentRequest.Execute(studentData);
         
        Console.WriteLine(requestRun.Content);
        return Ok(requestRun.Content);
    }
}