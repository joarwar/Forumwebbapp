using Forum.Db_Context;
using Forum.Entities;
using Forum.RequestModel;
using Forum.Helpers;
using AutoMapper;
using Forum.Auth;
using BCrypt.Net;
using Forum.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Services
{
    public interface IUserService
    {

        User GetFromName(UserByNameRequest userModel);
        User GetFromId(int Id);
        User GetUserById(int Id);
        void CreateNewUser(CreateUserRequest userModel);
        UserAuthResponse UserAuth(UserAuthRequest request);
        void RemoveUser(int id);
        void UpdateUser(int id, UpdateUser userModel);
        IEnumerable<User> GetUsers();
    }



    public class UserService : IUserService
    {

        private DataContext _dataContext;
        private IMapper _mapper;
        private IJwtUtils _jwtUtils;


        public UserService(DataContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _dataContext = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public IEnumerable<User> GetUsers()
        {
   
            return _dataContext.Users;
        }
        public User GetUserById(int id)
        {
            var foundUser = _dataContext.Users.Find(id);
            return foundUser;
        }

        public User GetFromId(int id)
        {
            var userById = _dataContext.Users.Find(id);


            return userById;
        }

        public User GetFromName([FromQuery] UserByNameRequest userModel)
        {
            var userId = _dataContext.Users.FirstOrDefault(user => user.Username == userModel.Username);
            return (User)userId;
        }


        public void CreateNewUser(CreateUserRequest userModel)
        {

            if (_dataContext.Users.Any(user => user.Username == userModel.Username))
            {
                throw new CustomException("User " + userModel.Username + " already exists!");
            }

            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);

            _dataContext.Add(new User()
            {
                Username = userModel.Username,
                Password = userModel.Password,
            });

            _dataContext.SaveChanges();

        }

        public UserAuthResponse UserAuth(UserAuthRequest request)
        {

            var authUser = _dataContext.Users.SingleOrDefault(u => u.Username == request.Username);


            if (!BCrypt.Net.BCrypt.Verify(request.Password, authUser.Password))
                throw new CustomException("Wrong username or password!"); ;

            //if (!BCrypt.Net.BCrypt.Verify(request.Password, authUser.Password))
            //{
            //    throw new CustomException("Wrong username or password!");
            //}

            //sucess v
            var response = _mapper.Map<UserAuthResponse>(authUser);

            response.Token = _jwtUtils.GenerateToken(authUser);

            return response;




        }

        public void UpdateUser(int id, UpdateUser userModel)
        {
            var userUpdate = _dataContext.Users.Find(id);

            if (_dataContext.Users.Any(userUpdate => userUpdate.Username == userModel.Username))
            {
                throw new CustomException("Username already exists!");
            }

            if (userUpdate.Username != null)
                userUpdate.Username = userModel.Username;


            if (userUpdate.Password != null)
                userUpdate.Password = userModel.Password;

            userUpdate.Password = BCrypt.Net.BCrypt.HashPassword(userUpdate.Password);

            _dataContext.SaveChanges();
  

        }
        public void RemoveUser(int id)
        {
            var user = _dataContext.Users.Find(id);
            _dataContext.Users.Remove(user);
            _dataContext.SaveChanges();
        }

    }
}
