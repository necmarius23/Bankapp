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

namespace WindowsFormsApp1
{
    public partial class EditClient : Form
    {
        private string connectionString = @"URI=file:C:\Users\necmarius\source\repos\WindowsFormsApp1\WindowsFormsApp1\database.db";
        public EditClient()
        {
            InitializeComponent();
        }

        private void tbEditCredit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void UpdateReimb(int id, string creditType)
        {
            const string stringSql = "UPDATE Clients SET ReimbursementType= @reimbType WHERE ClientID=@ClientID;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                SQLiteCommand command = new SQLiteCommand(stringSql, connection);
                command.Parameters.AddWithValue("@reimbType", creditType);
                command.Parameters.AddWithValue("@ClientID", id);

                command.ExecuteNonQuery();

            }

        }
        private void UpdateCredit(int id, string creditType)
        {
            const string stringSql = "UPDATE Clients SET CreditType= @CreditType WHERE ClientID=@ClientID;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                SQLiteCommand command = new SQLiteCommand(stringSql, connection);
                command.Parameters.AddWithValue("@creditType", creditType);
                command.Parameters.AddWithValue("@ClientID", id);

                command.ExecuteNonQuery();

            }

        }
        private void tbEditCredit_Validating(object sender, CancelEventArgs e)
        {
            if (tbEditCredit.Text.Length < 3)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorEdit.SetError(tbEditCredit, "The type must have at least 3 letters!");
            }
        }

        private void tbEditCredit_Validated(object sender, EventArgs e)
        {
            errorEdit.SetError(tbEditCredit, null);
        }
        private void tbChangeReimb_Validated(object sender, EventArgs e)
        {
            errorEdit.SetError(tbChangeReimb, null);
        }
        private void tbChangeReimb_Validating(object sender, CancelEventArgs e)
        {
            if (tbChangeReimb.Text.Length < 3)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorEdit.SetError(tbChangeReimb, "The type must have at least 3 letters!");
            }
        }

        private void tbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }
        private void tbId_Validated(object sender, EventArgs e)
        {
            errorEdit.SetError(tbId, null);
        }
        private void tbId_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(tbId.Text) == 0)
            {
                e.Cancel = true; //prevents the user from changing the focus to another control
                errorEdit.SetError(tbId, "The id value cannot be 0!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateCredit(int.Parse(tbId.Text), tbEditCredit.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void EditReimb_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateReimb(int.Parse(tbId.Text), tbChangeReimb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
