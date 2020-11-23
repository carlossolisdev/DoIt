using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Servicios
{
    public class UsersService
    {

        public async Task CreateUser(User user)
        {
            using (var context = new DoItEntities())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }

        public User GetUserById(int id)
        {
            User userToReturn;
            using (var context = new DoItEntities())
            {
                userToReturn = context.Users.FirstOrDefault(x => x.UserId == id);
            }
            return userToReturn;
        }

        public async Task UpdateUser(User user)
        {
            using (var context = new DoItEntities())
            {
                var userToUpdate = context.Users.FirstOrDefault(x => x.UserId == user.UserId);
                userToUpdate = user;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var context = new DoItEntities())
            {
                var userToDelete = context.Users.FirstOrDefault(x => x.UserId == id);
                context.Users.Remove(userToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}