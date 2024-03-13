namespace _2._2._4;

public class Airplane
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int WeightCapacity { get; set; }
    public int MaxLength { get; set; }
    public int WingSpan { get; set; }
    public int TakeoffLength { get; set; }
    public int CompanyId { get; set; }

    /// <summary>
    /// Самолет
    /// </summary>
    /// <param name="type">Тип самолета</param>
    /// <param name="weightCapacity">Грузоподъемность</param>
    /// <param name="maxLength">Максимальная дальность</param>
    /// <param name="wingSpan">Размах крыльев</param>
    /// <param name="takeoffLength">Длина разбега</param>
    /// <param name="companyId">id компании</param>
    public Airplane(string name, string type, int weightCapacity, int maxLength, int wingSpan, int takeoffLength, int companyId)
    {
        Name = name;
        Type = type;
        WeightCapacity = weightCapacity;
        MaxLength = maxLength;
        WingSpan = wingSpan;
        TakeoffLength = takeoffLength;
        CompanyId = companyId;
    }
}