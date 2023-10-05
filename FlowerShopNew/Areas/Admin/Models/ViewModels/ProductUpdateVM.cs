using FlowerShopNew.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShopNew.Areas.Admin.Models.ViewModels
{
	public class ProductUpdateVM
	{
		public int Id { get; set; }
		public string ProductCode { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public string? Description { get; set; }
		public int CategoryId { get; set; }
		public IFormFile? File { get; set; }
	}
}
