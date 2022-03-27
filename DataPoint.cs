using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCRGame
{
    public class DataPoint:NotifierBase
    {
        private double _totalGames = new int();
        public double TotalGames
        {
            get { return _totalGames; }
            set
            {
                SetProperty(ref _totalGames, value);
            }
        }

        private double _turns = new int();
        public double Turns
        {
            get { return _turns; }
            set
            {
                SetProperty(ref _turns, value);
            }
        }
    }
}
