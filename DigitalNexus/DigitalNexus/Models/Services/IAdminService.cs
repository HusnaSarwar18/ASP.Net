using DigitalNexus.Models.Entities;

namespace DigitalNexus.Models.Services
{
    public interface IAdminService
    {
        void AddBuyer(Buyer buyer);
        void AddSeller(Seller seller);
        List<Buyer> GetAllBuyers();
        List<Seller> GetAllSellers();
    }
}
