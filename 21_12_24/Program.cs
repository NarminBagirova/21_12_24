namespace _21_12_24
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());
                Console.WriteLine("1. All Products - Display all products");
                Console.WriteLine("2. Get Product - Get a product by ID");
                Console.WriteLine("3. Create Product - Create and add a new product");
                Console.WriteLine("4. Delete Product - Delete a product by ID");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var allProducts = productService.GetAll();
                        Console.WriteLine("\nAll Products:");
                        if (allProducts.Count == 0)
                        {
                            Console.WriteLine("No products available.");
                        }
                        else
                        {
                            foreach (var pr in allProducts)
                            {
                                Console.WriteLine($"ID: {pr.Id}, Name: {pr.Name}, Cost Price: {pr.CostPrice}, Sale Price: {pr.SalePrice}");
                            }
                        }
                        break;

                    case "2":
                        Console.Write("Enter Product ID to search: ");
                        int getId = int.Parse(Console.ReadLine());
                        var product = productService.Get(getId);
                        if (product != null)
                        {
                            Console.WriteLine($"\nProduct found: ID: {product.Id}, Name: {product.Name}, Cost Price: {product.CostPrice}, Sale Price: {product.SalePrice}");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Cost Price: ");
                        decimal costPrice = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Sale Price: ");
                        decimal salePrice = decimal.Parse(Console.ReadLine());

                        var newProduct = new Product(name, costPrice, salePrice);

                        productService.Create(newProduct);

                        Console.WriteLine("Product created successfully.");
                        break;

                    case "4":
                        Console.Write("Enter Product ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());

                        productService.Delete(deleteId);
                        Console.WriteLine("Product deleted successfully.");
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}