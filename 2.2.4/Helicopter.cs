namespace _2._2._4;

public class Helicopter
{
    public string Type { get; set; }
    public int WeightCapacity { get; set; }
    public int MaxHeight { get; set; }
    public int MaxLength { get; set; }
    public int CompanyId { get; set; }

    /// <summary>
    /// Конструктор вертолета
    /// </summary>
    /// <param name="type">Тип</param>
    /// <param name="weightCapacity">Вес</param>
    /// <param name="maxHeight">максимальная высота</param>
    /// <param name="maxLength">максимальная длина полета</param>
    /// <param name="companyId">Id компании</param>
    public Helicopter(string type, int weightCapacity, int maxHeight, int maxLength, int companyId)
    {
        Type = type;
        WeightCapacity = weightCapacity;
        MaxHeight = maxHeight;
        MaxLength = maxLength;
        CompanyId = companyId;
    }
}