using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Forum.Auth;
using Forum.Services;
using Forum.RequestModel;
using Forum.Entities;

namespace Forum.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]

    public class ForumpostController : ControllerBase
    {

        public IForumpostService _forumPostService;
        


        public ForumpostController(IForumpostService forumPostService)
        {
            _forumPostService = forumPostService;
            
        }
        [HttpPost("createPost")]
        public IActionResult CreatePost(CreatePostRequest model)
        {
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
            return Ok(postById);
        }

        [HttpPatch("updatePost")]
        public IActionResult UpdatePost(int id,UpdatePost model)
        {
            _forumPostService.UpdatePost(id, model);
            return Ok(new { message = "Update done!" });
        }

        [HttpDelete("deletePost")]
        public IActionResult DeleteUser(int id)
        {
            _forumPostService.RemovePost(id);
            return Ok(new { message = "Post deleted" });
        }


    }
}