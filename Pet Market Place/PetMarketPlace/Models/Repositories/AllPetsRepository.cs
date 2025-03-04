using Dapper;
using Microsoft.Data.SqlClient;
using PetMarketPlace.Models.Entities;
using PetMarketPlace.Models.Interfaces;

namespace PetMarketPlace.Models.Repositories
{
    public class AllPetsRepository : IAllPetsInterface
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public List<CatEntity> RetrieveCats()
        {
            string query = "SELECT * FROM Cat";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<CatEntity>(query).ToList();
            }
        }

        public List<DogEntity> RetrieveDogs()
        {
            string query = "SELECT * FROM Dog";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<DogEntity>(query).ToList();
            }
        }

        public List<DogEntity> SearchDogsUsingId(int sellerId)
        {
            string query = "SELECT * FROM Dog WHERE SellerId = @SellerId";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<DogEntity>(query, new { SellerId = sellerId }).ToList();
            }
        }

        public List<CatEntity> SearchCatsUsingId(int sellerId)
        {
            string query = "SELECT * FROM Cat WHERE SellerId = @SellerId";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<CatEntity>(query, new { SellerId = sellerId }).ToList();
            }
        }

        public CatEntity GetCatById(int catId)
        {
            string query = "SELECT * FROM Cat WHERE CatId = @CatId";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingleOrDefault<CatEntity>(query, new { CatId = catId });
            }
        }

        public DogEntity GetDogById(int dogId)
        {
            string query = "SELECT * FROM Dog WHERE DogId = @DogId";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QuerySingleOrDefault<DogEntity>(query, new { DogId = dogId });
            }
        }
    }
}
