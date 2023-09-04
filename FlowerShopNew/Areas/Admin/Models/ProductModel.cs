using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShopNew.Areas.Admin.Models
{
	public class ProductModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Lütfen Boş Geçmeyiniz...")]
		public string ProductCode { get; set; }

		[Required(ErrorMessage = "Lütfen Boş Geçmeyiniz...")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen Boş Geçmeyiniz...")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Lütfen Boş Geçmeyiniz...")]
		public string Description { get; set; }

	

		
		
	}
}
