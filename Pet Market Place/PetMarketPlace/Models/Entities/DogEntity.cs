using System.ComponentModel.DataAnnotations;

namespace PetMarketPlace.Models.Entities
{
    public class DogEntity
    {
        public int DogId { get; set; }

        [Required]
        public string DogBreed { get; set; }

        [Required, Range(0, 30)]
        public int DogAge { get; set; }

        [Required]
        public string DogColor { get; set; }

        [Required, Range(0, 100000)]
        public decimal DogPrice { get; set; }

        public string DogPicturePath { get; set; }
        public int SellerId { get; set; }
    }


}
