namespace _2._2._4;

public class Company
{
    public string Title { get; set; }
    public string Address { get; set; }
    public int Year { get; set; }
    public int Id { get; set; }

    /// <summary>
    /// Конструктор компании
    /// </summary>
    /// <param name="title">Название компании</param>
    /// <param name="address">Адресс офиса</param>
    /// <param name="year">Год основания</param>
    /// <param name="id">id</param>
    public Company(string title, string address, int year, int id)
    {
        Title = title;
        Address = address;
        Year = year;
        Id = id;
    }
}