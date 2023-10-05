using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShopNew.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; } 
        public Category Category { get; set; }

        [NotMapped] //veri tabanına yansımayacak
		public IFormFile File { get; set; }




	}
}
