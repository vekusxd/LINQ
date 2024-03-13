using System.Runtime.InteropServices;

namespace _2._2._2;

public class Product
{
    public string Title { get; set; }
    public int Price { get; set; }
    public int Quanity { get; set; }
    public int Manufacturer_id { get; set; }

    /// <summary>
    /// Коструктор товара
    /// </summary>
    /// <param name="title">Название товара</param>
    /// <param name="price">Стоимость товара</param>
    /// <param name="quanity">Количество</param>
    /// <param name="manufacturerId">Id производителя</param>
    public Product(string title, int price, int quanity, int manufacturerId)
    {
        Title = title;
        Price = price;
        Quanity = quanity;
        Manufacturer_id = manufacturerId;
    }
}