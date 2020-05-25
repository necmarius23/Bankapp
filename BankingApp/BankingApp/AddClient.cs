using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1
{
    public partial class AddClient : Form
    {
        private List<Client> clients;
        private string connectionString = @"URI=file:C:\Users\necmarius\source\repos\WindowsFormsApp1\WindowsFormsApp1\database.db";
        public AddClient()
        {
            InitializeComponent();
        }

        private void AddClientToDb(Client client)
        {
            var queryInsertClient = "insert into CLIENTS( FirstName, LastName, CreditType, ReimbursementType)" +
            " values(@FirstName,@LastName,@CreditType,@ReimbursementType)";
            var queryInsertCredit = "insert into CREDITS(CreditType,CreditValue, NoMonths)" +
            " values(@CreditType, @CreditValue, @NoMonths)";
            var queryInsertReimb = "insert into REIMBURSEMENTS(ReimbursementValue, NoMonths, ReimbursementType)" +
            " values(@ReimbursementValue, @NoMonths,@ReimbursementType)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(connection);
                var commandCredit = new SQLiteCommand(connection);
                var commandReimb = new SQLiteCommand(connection);
                command.CommandText = queryInsertClient;
                commandCredit.CommandText = queryInsertCredit;
                commandReimb.CommandText = queryInsertReimb;
                command.Parameters.AddWithValue("@FirstName", client.FirstName);
                command.Parameters.AddWithValue("@LastName", client.LastName);
                command.Parameters.AddWithValue("@CreditType", client.credit.creditType);
                command.Parameters.AddWithValue("@ReimbursementType", client.reimb.reimbType);
                command.Prepare();
                command.ExecuteNonQuery();
                commandCredit.Parameters.AddWithValue("@CreditType", client.credit.creditType);
                commandCredit.Parameters.AddWithValue("@CreditValue", client.credit.value);
                commandCredit.Parameters.AddWithValue("@NoMonths", client.credit.noMonths);
                commandCredit.Prepare();
                commandCredit.ExecuteNonQuery();
                commandReimb.Parameters.AddWithValue("@ReimbursementType", client.reimb.reimbType);
                commandReimb.Parameters.AddWithValue("@ReimbursementValue", client.reimb.monthlyPayback);
                commandReimb.Parameters.AddWithValue("@NoMonths", client.reimb.noMonts);
                commandReimb.Prepare();
                commandReimb.ExecuteNonQuery();
            }
        }
        private void tbCreditValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void tbNoMonthsCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void tbReimbValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void tbNoMonthsReimb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }
        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {

            if (tbFirstName.Text.Trim().Length < 5)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorClient.SetError(tbFirstName, "The name must have at least 5 characters!");
            }
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (tbFirstName.Text.Trim().Length < 5)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorClient.SetError(tbFirstName, "The name must have at least 5 characters!");
            }

        }

        private void tbFirstName_Validated(object sender, EventArgs e)
        {
            errorClient.SetError(tbFirstName, null);

        }
        private void tbLastName_Validated(object sender, EventArgs e)
        {
            errorClient.SetError(tbLastName, null);

        }

        private void tbCreditValue_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(tbCreditValue.Text) == 0)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorClient.SetError(tbCreditValue, "The credit value cannot be 0!");
            }
        }
        private void tbCreditValue_Validated(object sender, EventArgs e)
        {
            errorClient.SetError(tbCreditValue, null);
        }

        private void tbNoMonthsCredit_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(tbNoMonthsCredit.Text) == 0)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorClient.SetError(tbCreditValue, "The no of months cannot be 0!");
            }
        }
        private void tbNoMonthsCredit_Validated(object sender, EventArgs e)
        {
            errorClient.SetError(tbNoMonthsCredit, null);

        }

        private void tbReimbValue_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(tbReimbValue.Text) == 0)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorClient.SetError(tbReimbValue, "The reimb value cannot be 0!");
            }
        }
        private void tbReimbValue_Validated(object sender, EventArgs e)
        {
            errorClient.SetError(tbReimbValue, null);

        }

        private void tbNoMonthsReimb_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(tbNoMonthsCredit.Text) == 0)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorClient.SetError(tbCreditValue, "The no of months cannot be 0!");
            }
        }
        private void tbNoMonthsReimb_Validated(object sender, EventArgs e)
        {
            errorClient.SetError(tbNoMonthsReimb, null);

        }

        private void AddClientButt_Click(object sender, EventArgs e)
        {

            Credit crd = new Credit(int.Parse(tbCreditValue.Text), int.Parse(tbNoMonthsCredit.Text), 
                tbCreditType.Text);
            Reimbursement reimb = new Reimbursement(int.Parse(tbReimbValue.Text), int.Parse(tbNoMonthsReimb.Text),
                tbReimbType.Text);
            Client client = new Client(tbFirstName.Text, tbLastName.Text,crd, reimb);
            AddClientToDb(client);
            this.Hide();
        }



        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void tbReimbType_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddClient_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }
    }

}
