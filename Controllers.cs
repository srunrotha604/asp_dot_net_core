using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api_service.Controllers
{
    public class FormUser
    {
        string? Name { get; set; }
        public IFormFile Image { get; set; }
    };
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            var product = new
            {
                Id = 1,
                Name = "Laptop",
                Price = 1500
            };

            return Ok(product);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserDetail(int id)
        {
            return Ok($"User get from id: {id}");
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] JsonElement user)
        {
            return Ok($"Created user {user}");
        }
        [HttpPost("submit")]
        public IActionResult PostForm([FromForm] FormUser model)
        {
            string name = Request.Form["Name"];
            var file = Request.Form.Files["Image"];

            var objectData = new
            {
                username = name,
                imageUser = file?.FileName
            };

            Console.WriteLine(objectData);

            return Ok(objectData);
        }
        [HttpGet("search")]
        public IActionResult GetPostQuery([FromQuery] string category, [FromQuery] string? maxPrice)
        {
            return Ok($"Category {category} and max price is {maxPrice}");
        }
    }
}
