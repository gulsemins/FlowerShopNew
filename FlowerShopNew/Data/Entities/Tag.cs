using System.Reflection.Metadata.Ecma335;

namespace FlowerShopNew.Data.Entities
{
	public class Tag
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int OrderNr { get; set; } = 0;
		public bool IsActive { get; set; } = true;

		public List<Product> Products { get; set; }
    }
}
