using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CytoSNPToAffymetrix
{
    class SNPData_Search : IComparer
    {
        public int Compare(object x, object y)
        {
            if (y == null || x == null)
            {
                if (y == null)
                { return -1; }
                else if (x == null)
                { return 1; }
            }

            SNPData a = (SNPData)x;
            string b = (string)y;

            return a.Name.CompareTo(b);
        }
    }
}
