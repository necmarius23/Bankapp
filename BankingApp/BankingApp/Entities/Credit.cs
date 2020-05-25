using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
    public class Credit
    {
       public int value { get; set; }
        public int noMonths { get; set; }
        public int creditId { get; set; }
        public string creditType { get; set; }
        public Credit(int value, int noMonths)
        {
            this.noMonths = noMonths;
            this.value = value;
          
        }
        public Credit()
        {

        }
        public Credit(int value, int noMonths, string creditType)
        {
            this.noMonths = noMonths;
            this.value = value;
            this.creditType = creditType;
        }
        public Credit(int value, int noMonths, string creditType, int creditId)
        {
            this.noMonths = noMonths;
            this.value = value;
            this.creditType = creditType;
            this.creditId = creditId;
        }
    }
}
