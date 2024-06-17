using AccountManagementData;
using AccountManagementModels;

namespace AccountManagementServices
{
    public class UserTransactionServices
    {
        UserValidationServices validationServices = new UserValidationServices();
        UserData userData = new UserData();

        public bool CreateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.AddUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool DeleteUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }
    }
}
