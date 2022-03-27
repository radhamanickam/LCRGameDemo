using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCRGame.Model
{
    public class LCRGameModel
    {
        public string? Games { get; set; }
        public string? Players { get; set; }

        public LCRGameModel(string players, string games)
        {
            Games = games;
            Players = players;
        }
    }
}
