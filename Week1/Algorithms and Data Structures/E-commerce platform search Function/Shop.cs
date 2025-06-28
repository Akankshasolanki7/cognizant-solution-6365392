using System;

public class Shop
{
    private Product[] products = new Product[10];

    public void StoreProducts()
    {
        products[0] = new Product(1, "Phone", "Electronics");
        products[1] = new Product(2, "Laptop", "Electronics");
        products[2] = new Product(3, "Shirt", "Fashion");
        products[3] = new Product(4, "Shoes", "Fashion");
        products[4] = new Product(5, "Stove", "Kitchen");
        products[5] = new Product(6, "Bat", "Sports");
        products[6] = new Product(7, "Football", "Sports");
        products[7] = new Product(8, "Rasmalai", "sweet");
        products[8] = new Product(9, "Kadalai", "Grocery");
        products[9] = new Product(10, "Fan", "Electronics");
    }

    public int LinearSearch(int productId)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductId == productId)
                return i;
        }
        return -1;
    }

    public int BinarySearch(int productId)
    {
        int low = 0;
        int high = products.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (products[mid].ProductId == productId)
                return mid;
            else if (products[mid].ProductId > productId)
                high = mid - 1;
            else
                low = mid + 1;
        }

        return -1;
    }

    public void DisplayProduct(int index)
    {
        if (index == -1)
        {
            Console.WriteLine("Product Not Found");
            return;
        }

        Console.WriteLine($"Name: {products[index].ProductName} Category: {products[index].Category}");
    }
}
