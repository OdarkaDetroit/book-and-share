using WebApp.Models;
using WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersBookshellController : ControllerBase
    {
        private readonly UsersBookshellService _bookshells;

        public UsersBookshellController(UsersBookshellService UsersBookshellService)
        {
            _bookshells = UsersBookshellService;
        }


        [HttpGet]
        public ActionResult<List<UsersBookshell>> Get() =>
            _bookshells.Get();


        [HttpGet("{id:length(24)}", Name = "GetBookshell")]
        public ActionResult<UsersBookshell> Get(string id)
        {
            var bookshell = _bookshells.Get(id);

            if (bookshell == null)
            {
                return NotFound();
            }

            return bookshell;
        }


        [HttpPost]
        public ActionResult<UsersBookshell> Create(UsersBookshell bookshell)
        {
            _bookshells.Create(bookshell);

            return CreatedAtRoute("GetBook", new { id = bookshell.Id.ToString() }, bookshell);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UsersBookshell bookshellIn)
        {
            var bookshell = _bookshells.Get(id);

            if (bookshell == null)
            {
                return NotFound();
            }

            _bookshells.Update(id, bookshellIn);

            return NoContent();
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var bookshell = _bookshells.Get(id);

            if (bookshell == null)
            {
                return NotFound();
            }

            _bookshells.Remove(bookshell.Id);

            return NoContent();
        }
    }
}