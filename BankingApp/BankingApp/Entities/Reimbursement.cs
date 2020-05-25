using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
   public  class Reimbursement
    {
       public int monthlyPayback;
        public int noMonts;
        public int reimbId;
        public string reimbType;
        public string creditType { get; set; }
        public Reimbursement()
        {

        }
        public Reimbursement(int monthlyPayback, int noMonts, int reimbId, string reimbType)
        {
            this.monthlyPayback = monthlyPayback;
            this.noMonts = noMonts;
            this.reimbId = reimbId;
            this.reimbType = reimbType;
        }
        public Reimbursement(int monthlyPayback, int noMonts,string reimbType)
        {
            this.monthlyPayback = monthlyPayback;
            this.noMonts = noMonts;
            this.reimbType = reimbType;
        }
    }
}
