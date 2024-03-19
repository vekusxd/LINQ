namespace _1._3;

public class Computer
{
    public string Title { get; set; }
    public uint Cost { get; set; }
    public uint Power { get; set; }
    public List<string> Users { get; set; }

    /// <summary>
    /// Конструктор вычислительной техники
    /// </summary>
    /// <param name="title">Название</param>
    /// <param name="cost">Стоимость</param>
    /// <param name="power">Мощность</param>
    /// <param name="users">Пользователи</param>
    public Computer(string title, uint cost, uint power, List<string> users)
    {
        Title = title;
        Cost = cost;
        Power = power;
        Users = users;
    }
}