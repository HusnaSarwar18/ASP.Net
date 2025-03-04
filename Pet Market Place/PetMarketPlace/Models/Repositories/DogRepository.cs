using Dapper;
using Microsoft.Data.SqlClient;
using PetMarketPlace.Models.Entities;
using PetMarketPlace.Models.Interfaces;

namespace PetMarketPlace.Models.Repositories
{
    public class DogRepository : IDogInterface
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void AddDog(DogEntity dog, int sellerId)
        {
            string query = @"INSERT INTO Dog (DogBreed, DogAge, DogColor, DogPrice, DogPicturePath, SellerId) 
                             VALUES (@DogBreed, @DogAge, @DogColor, @DogPrice, @DogPicturePath, @SellerId)";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, new { dog.DogBreed, dog.DogAge, dog.DogColor, dog.DogPrice, dog.DogPicturePath, SellerId = sellerId });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
            }
        }

        public bool UpdateDog(DogEntity dog)
        {
            if (!DogExists(dog.DogId)) return false;

            string query = @"UPDATE Dog 
                             SET DogBreed = @DogBreed, DogAge = @DogAge, DogColor = @DogColor, DogPrice = @DogPrice, DogPicturePath = @DogPicturePath 
                             WHERE DogId = @DogId";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute(query, new { dog.DogBreed, dog.DogAge, dog.DogColor, dog.DogPrice, dog.DogPicturePath, dog.DogId });
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
                return false;
            }
        }

        public bool DeleteDog(int dogId)
        {
            if (!DogExists(dogId)) return false;

            string query = "DELETE FROM Dog WHERE DogId = @DogId";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    int rowsAffected = connection.Execute(query, new { DogId = dogId });
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
                return false;
            }
        }

        private bool DogExists(int dogId)
        {
            string query = "SELECT COUNT(1) FROM Dog WHERE DogId = @DogId";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return connection.ExecuteScalar<int>(query, new { DogId = dogId }) > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error Occurred: " + ex.Message);
                return false;
            }
        }
    }
}
