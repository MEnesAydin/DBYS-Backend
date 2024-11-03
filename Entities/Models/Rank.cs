namespace Entities.Models;

public class Rank : BaseClass
{
    public string Name { get; set; }
    public string ShortName { get; set; }

    public ICollection<Teacher> Teachers { get; set; }
}