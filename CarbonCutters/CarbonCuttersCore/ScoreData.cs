using CarbonCuttersCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbonCuttersCore
{
    public class ScoreData
    {
        public string Date { get; set; }
        public int Score { get; set; }


        public ScoreData(string date, int score)
        {
            Date = date;
            Score = score;
        }




    }
}
