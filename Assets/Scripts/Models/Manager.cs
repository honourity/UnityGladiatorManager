using System.Collections.Generic;

public class Manager
{
    public long Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Gladiator> Gladiators { get; set; }
}