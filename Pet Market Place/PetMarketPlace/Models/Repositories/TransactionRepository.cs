using Dapper;
using Microsoft.Data.SqlClient;
using PetMarketPlace.Models.Entities;
using PetMarketPlace.Models.Interfaces;

namespace PetMarketPlace.Models.Repositories
{
    public class TransactionRepository : ITransectionInterfaces
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public bool BuyPet(TransactionsEntity transactions)
        {
            // SQL query to insert a new transaction
            string query = "INSERT INTO Transactions (SellerId, BuyerId, PetType, PetId, PhoneNumber, Address, PaymentAmount, TransactionDate) VALUES (@SellerId, @BuyerId, @PetType, @PetId, @PhoneNumber, @Address, @PaymentAmount, @TransactionDate)";

            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    con.Execute(query, transactions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
                return false;
            }
            return true;
        }

        public void AddToCart(int petId, string section)
        {
            var petsEntity = new AllPetsEntity();
            if (section == "Cat")
            {
                var cat = new CatEntity { CatId = petId };
                petsEntity.Cats.Add(cat);
            }
            else if (section == "Dog")
            {
                var dog = new DogEntity { DogId = petId };
                petsEntity.Dogs.Add(dog);
            }
        }
    }
}
