namespace _2._2._2;

public class Manufacturer
{
    public string Title { get; set; }
    public string BossInitials { get; set; }
    public int Id { get; set; }

    public Manufacturer(string title, string bossInitials, int id)
    {
        Title = title;
        BossInitials = bossInitials;
        Id = id;
    }
}