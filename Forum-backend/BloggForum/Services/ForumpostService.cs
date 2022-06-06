using Forum.Db_Context;
using Forum.Entities;
using Forum.RequestModel;
using Forum.Helpers;
using AutoMapper;
using Forum.Auth;
using BCrypt.Net;
using Forum.Controllers;
using System.Linq;

namespace Forum.Services
{

    public interface IForumpostService
    {
        void CreatePost(CreatePostRequest model);
        IEnumerable<Forumpost> GetForumPosts();
        Forumpost GetPostFromId(int id);
        void UpdatePost(int id, UpdatePost model);
        void RemovePost(int id, DeletePostRequest model);
        //User GetFromId(int Id);
    }

    public class ForumpostService : IForumpostService
    {
        private DataContext _dataContext;
        private IMapper _mapper;
        private IJwtUtils _jwtUtils;
        



        public ForumpostService(DataContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _dataContext = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public void CreatePost(CreatePostRequest model)
        {
            var user = _dataContext.Users.Where(u => u.Username == model.User.Username).FirstOrDefault();
            //if (_dataContext.ForumPosts.Any(post => post.Title == model.Title))
            //{
            //    throw new CustomException("The title" + model.Title + "Is already taken!");
            //}

            _dataContext.Add(new Forumpost()
            {
                TimePosted = DateTime.Now,
                Title = model.Title,
                ImageUrl = "no image chosen",
                Content = model.Content,
                User = user
            }); 
            _dataContext.SaveChanges();
        }


        //public User GetFromId(int id)
        //{
        //    var userById = _dataContext.Users.Find(id);

        //    if (userById == null)
        //    {
        //        throw new KeyNotFoundException("User doesn't exist");
        //    }
        //    return userById;
        //}

        public IEnumerable<Forumpost> GetForumPosts()
        {
            return _dataContext.ForumPosts ;
        }
        public Forumpost GetPostFromId(int id)
        {
            var postById = _dataContext.ForumPosts.Find(id);

            return postById;
        }

        public void UpdatePost(int id, UpdatePost model)
        {
            var postUpdate = _dataContext.ForumPosts.Find(id);

            if (postUpdate != null)
            {
                if (postUpdate.Title != null)
                    postUpdate.Title = model.Title;

                if (postUpdate.Content != null)
                    postUpdate.Content = model.Content;

                _dataContext.SaveChanges();

            }
            else
            {

            }
        }

        public void RemovePost(int id, DeletePostRequest model)
        {
            var post = _dataContext.ForumPosts.Find(id);

            _dataContext.ForumPosts.Remove(post);

            _dataContext.SaveChanges();
        }

    }


}
