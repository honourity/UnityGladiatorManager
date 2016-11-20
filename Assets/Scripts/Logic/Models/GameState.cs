using System.Collections.Generic;

namespace Assets.Scripts.Logic.Models
{
    public class GameState
    {
        public IDictionary<string, string> Config { get; set; }

        public Manager Player { get; set; }
    }
}