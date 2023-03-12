using PlatformService.Models;

namespace PlatformService.Repositories
{
    public class UsersRepository : IUserReporsitory
    {
        public void CreateUser(string firstName, string secondName)
        {
            throw new NotImplementedException();
        }

        public List<Account> GetAccountsBelongingToUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userId)
        {
            throw new NotImplementedException();
        }
    }


}
