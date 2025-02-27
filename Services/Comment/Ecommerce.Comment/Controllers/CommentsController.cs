using Ecommerce.Comment.Context;
using Ecommerce.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommerce.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var comments = _context.UserComment.ToList();
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] UserComment userComment)
        {
            if (userComment == null)
                return BadRequest("Geçersiz yorum verisi!");

            _context.UserComment.Add(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla eklendi!");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateComment(UserComment userComment)
        {
           _context.UserComment.Update(userComment);
            await _context.SaveChangesAsync();
            return Ok("Yorum guncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var comment = _context.UserComment.Find(id);
            _context.UserComment.Remove(comment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla silindi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _context.UserComment.Find(id);
            if (comment == null)
                return NotFound("Yorum bulunamadı!");

            return Ok(comment);
        }

        [HttpGet("CommentListByProductId")]

        public IActionResult CommentListByProducId(string id)
        {
           // var value = _context.UserComment.Find(id); find integer icin kullnilioyrum bu yuzden bu metot calismaz
           var values = _context.UserComment.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }

    }
}
             