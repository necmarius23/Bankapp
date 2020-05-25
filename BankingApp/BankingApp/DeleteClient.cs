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
    public partial class DeleteClient : Form
    {
        private string connectionString = @"URI=file:C:\Users\necmarius\source\repos\WindowsFormsApp1\WindowsFormsApp1\database.db";
        public DeleteClient()
        {
            InitializeComponent();
        }
        private void DeleteClientDb(int id)
        {
            const string stringSql = "DELETE FROM Clients WHERE ClientID=@ClientID";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                SQLiteCommand command = new SQLiteCommand(connection);
                command.CommandText = stringSql;
                command.Parameters.AddWithValue("@ClientID", id);
                command.Prepare();
                command.ExecuteNonQuery();
            }
        }
        private void tbDelete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Keys.Back != (Keys)e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void tbDelete_Validating(object sender, CancelEventArgs e)
        {

        }

        private void tbDelete_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbDelete, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                DeleteClientDb(int.Parse(tbDelete.Text));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
