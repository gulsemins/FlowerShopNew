namespace FlowerShopNew.Data.Entities
{
	public class Category
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNr { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        public List<Product> Products { get; set; }
    }
}
