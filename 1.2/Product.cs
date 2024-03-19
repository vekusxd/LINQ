namespace _1._2;

public class Product
{
    public string Title { get; set; }
    public double Cost { get; set; }
    public int Count { get; set; }
    public List<String> Dates { get; set; }
    public string Manufacturer { get; set; }

    /// <summary>
    /// Конструктор товара
    /// </summary>
    /// <param name="title">Название товара</param>
    /// <param name="cost">Стоимость товара</param>
    /// <param name="count">Количество товаров</param>
    /// <param name="dates">Даты поступления на склад</param>
    /// <param name="manufacturer">Производитель</param>
    public Product(string title, double cost, int count, List<String> dates, string manufacturer)
    {
        Title = title;
        Count = count;
        Cost = cost;
        Dates = dates;
        Manufacturer = manufacturer;
    }
}