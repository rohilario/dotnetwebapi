using Moq;
using dotnetwebapi.Controllers;
using dotnetwebapi.Models;
using dotnetwebapi.Services;
using Xunit;

namespace TestUser
{
    public class TestUserController
    {
        private readonly Mock<IUserService> userService;
        public TestUserController()
        {
            userService = new Mock<IUserService>();
        }
        [Fact]
        public void GetUserList_UserList()
        {
            //arrangeeee
            var userList = GetUserList_UserList;
            userService.Setup(x => x.GetUserList() ) 
                        .Returns(userList);
            var userController = new UserController(userService.Object);
            //act
            var userResult = userController.GetUserList();
            //assert
            Assert.NotNull(userResult);
            Assert.Equal(GetUsersData().Count(), userResult.Count());
            Assert.Equal(GetUsersData().ToString(), userResult.ToString());
            Assert.True(userList.Equals(userResult));
        }
        [Fact]
        public void GetUserByID_User()
        {
            //arrange
            var userList = GetUsersData();
            userService.Setup(x => x.GetUserById(2))
                .Returns(userList[1]);
            var userController = new UserController(userService.Object);
            //act
            var usertResult = userController.GetUserById(2);
            //assert
            Assert.NotNull(usertResult);
            Assert.Equal(userList[1].UserId, usertResult.UserId);
            Assert.True(userList[1].UserId == usertResult.UserId);
        }
        [Theory]
        [InlineData("Hilario")]
        public void CheckUserExistOrNotByUserName_User(string userName)
        {
            //arrange
            var userList = GetUsersData();
            userService.Setup(x => x.GetUserList())
                .Returns(userList);
            var userController = new UserController(userService.Object);
            //act
            var userResult = userController.GetUserList();
            var expectedUserName = userResult.ToList()[0].UserName;
            //assert
            Assert.Equal(userName, expectedUserName);
        }

        [Fact]
        public void AddUser_User()
        {
            //arrange
            var userList = GetUsersData();
            userService.Setup(x => x.AddUser(userList[2]))
                .Returns(userList[2]);
            var userController = new UserController(userService.Object);
            //act
            var userResult = userController.AddUser(userList[2]);
            //assert
            Assert.NotNull(userResult);
            Assert.Equal(userList[2].UserId, userResult.UserId);
            Assert.True(userList[2].UserId == userResult.UserId);
        }

        private List<User> GetUsersData()
        {
            List<User> usersData = new List<User>
        {
            new User
            {
                UserId = 1,
                UserName = "Hilario",
                UserCpf = "05684690386",
            },
             new User
            {
                UserId = 2,
                UserName = "Caio Squadra",
                UserCpf = "11111111111",
            },
             new User
            {
                UserId = 3,
                UserName = "Squadra",
                UserCpf = "22222222222",
            },
        };
            return usersData;
        }
    }
}