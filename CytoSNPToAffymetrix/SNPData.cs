using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CytoSNPToAffymetrix
{
    class SNPData
    {
        private int position = -1;
        private int chromosome = -1;
        private string name = "";
        private bool isGood = false;
        public SNPData(string line)
        {
            string[] items = line.Split(',');
            try
            {
                position = Convert.ToInt32(items[10]);
                if (items[9] == "X")
                { chromosome = 24; }
                else if (items[9] == "Y")
                { chromosome = 25; }
                else
                { chromosome = Convert.ToInt32(items[9]); }
                name = items[1];

                if (position == 0 || chromosome == 0)
                { isGood = false; }
                else { isGood = true; }
            }
            catch { isGood = false; }
        }

        public bool Good
        { get { return isGood; } }
        
        public int Location
        { get { return position; } }

        public int Chromosome
        { get { return chromosome; } }

        public string Name
        { get { return name; } }

    }
}
