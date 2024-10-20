using System.Linq;
using DataLayer;
using Model;

namespace BusinessLogic
{
    public class UserValidationServices
    {
        private readonly ProductRepository productRepository = new ProductRepository();

        public bool CheckIfUserExists(string username, string password) 
        {
            var user = productRepository.GetUsers().FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }
}
 