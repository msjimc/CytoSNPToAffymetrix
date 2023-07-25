using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CytoSNPToAffymetrix
{
    class SNPData_Sorter: IComparer<SNPData>
    {
        int IComparer<SNPData>.Compare(SNPData x, SNPData y)
        {
            if (y == null || x == null)
            {
                if (y == null)
                { return -1; }
                else if (x == null)
                { return 1; }
            }

            return x.Name.CompareTo(y.Name);

        }    
    }
}
