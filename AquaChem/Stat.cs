using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaChem
{
    class Stat
    {

        public Stat() { }

        public Stat(DateTime date, decimal temperature, decimal pH, decimal ammonia, decimal nitrites, decimal nitrates)
        {
            this.Date = date;
            this.Temperature = temperature;
            this.PH = pH;
            this.Ammonia = ammonia;
            this.Nitrites = nitrites;
            this.Nitrates = nitrates;
        }

        public DateTime Date { get; }
        public decimal Temperature { get; }
        public decimal PH { get; }
        public decimal Ammonia { get; }
        public decimal Nitrites { get; }
        public decimal Nitrates { get; }

        public override string ToString()
        {
            return base.ToString() + $"Date: {Date}, Temperature: {Temperature}, PH: {PH}, Ammonia: {Ammonia}, Nitrites: {Nitrites}, Nitrates: {Nitrates}";
        }
    }
}
