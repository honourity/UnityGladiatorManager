namespace Assets.Scripts.Logic.Models
{
    public class Gladiator
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long? ManagerId { get; set; }

        public bool IsPlayer { get; set; }
    }
}