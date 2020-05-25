using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
     public class Client
    {
       public string FirstName;
        public string LastName;
        public Credit credit;
        public Reimbursement reimb;
        public int clientID;

        public Client()
        {

        }
        public Client(string name, string lname, Credit credit, Reimbursement reimb)
        {
            this.FirstName = name;
            this.credit = credit;
            this.reimb = reimb;
            this.LastName = lname;
        }
        public Client(string name, string lname, Credit credit, Reimbursement reimb, int clientId)
        {
            this.FirstName = name;
            this.credit = credit;
            this.reimb = reimb;
            this.LastName = lname;
            this.clientID = clientId;
        }
    }
}
