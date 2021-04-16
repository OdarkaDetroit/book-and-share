using WebApp.Models;
using WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersLikesController : ControllerBase
    {
        private readonly UserslikesLikesService _likesService;

        public UsersLikesController(UserslikesLikesService UserslikesLikesService)
        {
            _likesService = UserslikesLikesService;
        }


        [HttpGet]
        public ActionResult<List<UsersBooksLikes>> Get() =>
            _likesService.Get();


        [HttpGet("{id:length(24)}", Name = "Getlike")]
        public ActionResult<UsersBooksLikes> Get(string id)
        {
            var like = _likesService.Get(id);

            if (like == null)
            {
                return NotFound();
            }

            return like;
        }


        [HttpPost]
        public ActionResult<UsersBooksLikes> Create(like like)
        {
            _likesService.Create(like);

            return CreatedAtRoute("Getlike", new { id = like.Id.ToString() }, like);
        }


        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, like likeIn)
        {
            var like = _likesService.Get(id);

            if (like == null)
            {
                return NotFound();
            }

            _likesService.Update(id, likeIn);

            return NoContent();
        }


        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var like = _likesService.Get(id);

            if (like == null)
            {
                return NotFound();
            }

            _likesService.Remove(like.Id);

            return NoContent();
        }
    }
}