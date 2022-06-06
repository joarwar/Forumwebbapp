using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Forum.Auth;
using Forum.Services;
using Forum.RequestModel;
using Forum.Entities;
using Forum.Db_Context;

namespace Forum.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]

    public class ForumpostController : ControllerBase
    {

        public IForumpostService _forumPostService;
        private DataContext _dataContext;


        public ForumpostController(IForumpostService forumPostService, DataContext context)
        {
            _forumPostService = forumPostService;
            _dataContext = context;

        }
        [HttpPost("createPost")]
        public IActionResult CreatePost(CreatePostRequest model)
        {
            if (_dataContext.ForumPosts.Any(post => post.Title == model.Title))
            {
                return BadRequest("Title already taken!");
            }
            _forumPostService.CreatePost(model);

            return Ok(new { message = "Post Done!" });

        }

        [AllowAnonymous]
        [HttpGet("getPost")]
        public IActionResult GetForumPosts( )
        {
            
            var allPosts = _forumPostService.GetForumPosts();
            
            return Ok(allPosts);
        }

        [AllowAnonymous]
        [HttpGet("getPostFromId")]
        public IActionResult GetPostFromId(int id)
        {
            var postById = _forumPostService.GetPostFromId(id);
            if (postById == null)
            {
                return BadRequest("Post id doesn't exist.");
            }
            return Ok(postById);
        }


        [HttpPatch("updatePost")]
        public IActionResult UpdatePost(int id,UpdatePost model)
        {
            var postUpdate = _dataContext.ForumPosts.Find(id);

            if (postUpdate == null)
            {
                return BadRequest("Post not found");

            }

            if (_dataContext.ForumPosts.Any(postUpdate => postUpdate.Title != model.Title))
            {
                _forumPostService.UpdatePost(id, model);
                return Ok(new { message = "Update done!" });
            }

            if (id == null)
            {
                return BadRequest("Post not found");
            }

            return BadRequest("Title already taken!");
        }

        [HttpDelete("deletePost")]
        public IActionResult RemovePost(int id, DeletePostRequest model)
        {
            var idPost = _forumPostService.GetPostFromId(id);
            if (_dataContext.ForumPosts.Any(idPost => idPost.Id == model.Id))
            {
                _forumPostService.RemovePost(id, model);
                return Ok(new { message = "Post deleted" });

            }
            if ( id == null)
            {
                return BadRequest("Post not found");
            }

            return BadRequest("Post not found");
        }


    }
}