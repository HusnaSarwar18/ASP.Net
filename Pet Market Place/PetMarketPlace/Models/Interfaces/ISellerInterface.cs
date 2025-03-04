using PetMarketPlace.Models.Entities;

namespace PetMarketPlace.Models.Interfaces
{
    public interface ISellerInterface
    {
        (SellerEntity, int) Login(string username, string password);
        SellerEntity Signup(SellerEntity seller);
        bool UserNotExists(string username);
    }
}
