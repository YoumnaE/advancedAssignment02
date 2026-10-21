namespace advancedAssignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region products list

            List<Product> catalog = new()
            {
                new Product {Id=1, Name="Laptop", Category="Electronics", Price=1200,Stock=10 },
                new Product {Id=2, Name="Phone", Category="Electronics", Price=800,Stock=25 },
                new Product {Id=3, Name="T-shirt", Category="Clothing", Price=30,Stock=100 },
                new Product {Id=4, Name="Jeans", Category="Clothing", Price=60,Stock=50 },
                new Product {Id=5, Name="Chocolate", Category="Food", Price=5,Stock=200 },
                new Product {Id=6, Name="Coffee Beans", Category="Food", Price=15,Stock=80 },
                new Product {Id=7, Name="C# Book", Category="Books", Price=45,Stock=30 },
                new Product {Id=8, Name="Novel", Category="Books", Price=20,Stock=60 },
                new Product {Id=9, Name="Headphones", Category="Electronics", Price=150,Stock=40 },
                new Product {Id=10, Name="Jacket", Category="Clothing", Price=120,Stock=15 }
            };

            #endregion
            
            List<Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            List<Product> cheapProducts = SearchProducts(catalog, p => p.Price < 50);
            List<Product> inStock = SearchProducts(catalog, p => p.Stock > 0);
            List<Product> clothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

            PrintProducts("Electronics", electronics);
            PrintProducts("Products under $50", cheapProducts);
            PrintProducts("In Stock", inStock);
            PrintProducts("Clothing under $100", clothing);

            Console.Read();
        }
        static List<Product> SearchProducts(
        List<Product> products,
        Func<Product, bool> filter)
        {
            return products.Where(filter).ToList();
        }

        static void PrintProducts(string title, List<Product> products)
        {
            Console.WriteLine($"\n{title}:");

            foreach (Product p in products)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} - Stock: {p.Stock}");
            }
        }
    }
}
