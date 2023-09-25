using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Linq;




Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("To Enter a Product - Follow The Steps | To Generate a List Type 'Q'");
Console.ResetColor();
Console.WriteLine();

List<Product> productList = new List<Product>();

// Call the addProducts method to add products to the list
addProducts(productList);


Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("To Add More Products Type 'Y' and To Generate a List Type 'Q' | Or Any Key To Exit");
Console.ResetColor();
string addMore = Console.ReadLine();


if (addMore.ToLower() == "y")
    addProducts(productList);

else
    Environment.Exit(0);


Console.ReadLine();


//method to add products to the list
static void addProducts(List<Product> productList)
{
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter a Category: ");
        Console.ResetColor();
        string category = Console.ReadLine();

        if (category.ToLower().Trim() == "q")
            break;


        if (string.IsNullOrWhiteSpace(category))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect Category");
            Console.ResetColor();
            continue; // Skip the rest of the loop and start from the beginning
        }


        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter the Product Name: ");
        Console.ResetColor();
        string name = Console.ReadLine();

        if (name.Trim().ToLower() == "q")
            break;

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect Product Name. Enter Product Category Again and then the Correct Product Name");
            Console.ResetColor();
            continue;
        }


        decimal price = 0;

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter the Product Price: ");
            Console.ResetColor();
            string priceInput = Console.ReadLine();


            if (priceInput.Trim().ToLower() == "q")
                break;

            if (decimal.TryParse(priceInput, out price) && price >= 0)
                break;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect Price Format");
                Console.ResetColor();

            }

        }
        // Create a new Product object and add it to the list
        Product product = new Product(category, name, price);
        productList.Add(product);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product Added To The List!");
        Console.ResetColor();

        Console.WriteLine("--------------------------------------");

    }

    // Create the dotted line
    int lineLength = Console.WindowWidth;
    string dottedLine = new string('-', lineLength);
    Console.WriteLine(dottedLine);

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("The Product List");
    Console.ResetColor();

    // create the list of products
    List<Product> sotedList = productList.OrderBy(Product => Product.Price).ToList();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Category".PadRight(15) + "Product Name".PadRight(20) + "Price");
    Console.ResetColor();

    foreach (Product product in sotedList)
    {
        Console.WriteLine(product.Category.PadRight(15) + product.Name.PadRight(20) + product.Price.ToString());
    }

    // to calculate the total price
    decimal totalSum = productList.Sum(Product => Product.Price);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(("Total Price: " + totalSum).PadLeft(38));
    Console.ResetColor();


}

class Product
{
    public Product(string category, string name, decimal price)
    {
        Category = category;
        Name = name;
        Price = price;
    }

    public string Category { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
