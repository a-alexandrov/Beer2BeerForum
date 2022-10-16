using Beer2Beer.DTO;
using Beer2Beer.Models;

namespace Beer2Beer.Tests.TestHelper
{
    public class TestHelper
    {
        public static User User
        {
            get
            {
                return new User
                {
                     ID = 1
                    ,IsBlocked = false
                    ,IsAdmin = false
                    ,FirstName = "TestFirstName"
                    ,LastName = "TestLastName"
                    ,Email = "TestMail@test.com"
                    ,Username = "TestUser"
                    ,PasswordHash = "TestPassword"
                    ,AvatarImage = null
                    ,PhoneNumber = "8888888888888888"
                };
            }
        }

        public static UserUpdateDto UserUpdateDto
        {
            get 
            {
                return new UserUpdateDto
                {
                     ID = 1
                    ,FirstName = "NewTestName"
                    ,LastName = "NewTestName"
                    ,PasswordHash = "NewTestPassword"
                };
            }
        }
    }
}
