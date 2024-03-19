namespace _1._5;

public class Trolleybus
{
    public string Begin { get; set; }
    public string End { get; set; }
    public int Count { get; set; }
    public string Time { get; set; }
    public List<int> Numbers { get; set; }

    /// <summary>
    /// Конструктор троллейбуса
    /// </summary>
    /// <param name="begin">Начало маршрута</param>
    /// <param name="end">Конец маршрута</param>
    /// <param name="count">Количество троллейбусов</param>
    /// <param name="time">Время от начала до конца</param>
    /// <param name="numbers">Список номер троллейбусов</param>
    public Trolleybus(string begin, string end, int count, string time, List<int> numbers)
    {
        Begin = begin;
        End = end;
        Count = count;
        Time = time;
        Numbers = numbers;
    }
}