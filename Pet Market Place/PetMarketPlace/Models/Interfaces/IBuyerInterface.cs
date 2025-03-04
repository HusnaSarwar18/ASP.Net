using PetMarketPlace.Models.Entities;

namespace PetMarketPlace.Models.Interfaces
{
    public interface IBuyerInterface
    {
        BuyerEntity Login(string username, string password);
        BuyerEntity Signup(BuyerEntity buyer);
        bool UserExists(string username);
        public bool ValidatePhoneNumber(string phoneNumber);
    }
}
