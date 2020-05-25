using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        List<Client> clients;
        private string connectionString = @"Data Source=C:\Users\necmarius\source\repos\WindowsFormsApp1\WindowsFormsApp1\database.db";
        public MainForm()
        {
            InitializeComponent();
            clients = new List<Client>();
        }
        private List<Client> loadFromFile()
        {
            const string stringSql = "SELECT  ClientID, FirstName, LastName, CreditId, ReimbursementId, Clients.CreditType, Clients.ReimbursementType, CreditValue, Credits.NoMonths, Reimbursements.NoMonths, ReimbursementValue  FROM Clients, Credits, Reimbursements Where Credits.CreditType = Clients.CreditType and Reimbursements.ReimbursementType = Clients.ReimbursementType Group by ClientID;";

            List<Client> clients2 = new List<Client>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var command = new SQLiteCommand(stringSql,connection);
                using (SQLiteDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {


                        string lastName = sqlReader.GetString(2);
                        string firstName = sqlReader.GetString(1);
                        int id = sqlReader.GetInt32(0);
                        string creditType = sqlReader.GetString(5);
                        string reimbType = sqlReader.GetString(6);
                        long creditId = sqlReader.GetInt32(3);
                        long reimbId = sqlReader.GetInt32(4);
                        long creditMonths = sqlReader.GetInt32(8);
                        long reimbMonths = sqlReader.GetInt32(9);
                        long creditValue = sqlReader.GetInt32(7);
                        long reimbValue = sqlReader.GetInt64(10);
                        Credit crd = new Credit((int)creditValue, (int)creditMonths, creditType, (int)creditId);
                        Reimbursement reimb = new Reimbursement((int)reimbValue, (int)reimbMonths, (int)reimbId, reimbType);
                        Client client = new Client(firstName, lastName, crd, reimb, (int)id);
                        clients2.Add(client);
                    }
                }
                
            }
            return clients2;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void createClient_Click(object sender, EventArgs e)
        {
            AddClient cl1 = new AddClient();
            cl1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowClients scl = new ShowClients();
            scl.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteClient dcl = new DeleteClient();
            dcl.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            EditClient ecl = new EditClient();
            ecl.ShowDialog();
        }

        private void saveAsTextFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Client> clients2 = loadFromFile();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "Save as text file";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(saveFileDialog.FileName))
                {
                    file.WriteLine("LastName,FirstName,CreditValue, ReimbValue");

                    foreach (Client client in clients2)
                    {
                        file.WriteLine($" || {client.LastName} || {client.FirstName} || {client.credit.value} || {client.reimb.monthlyPayback}");
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddClient form1 = new AddClient();
            form1.ShowDialog();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ShowClients form1 = new ShowClients();
            form1.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DeleteClient form1 = new DeleteClient();
            form1.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            EditClient form1 = new EditClient();
            form1.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient form1 = new AddClient();
            form1.ShowDialog();
        }

        private void editClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditClient form1 = new EditClient();
            form1.ShowDialog();
        }

        private void deleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteClient form1 = new DeleteClient();
            form1.ShowDialog();
        }

        private void showClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClients form1 = new ShowClients();
            form1.ShowDialog();
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode == Keys.A)
            {
                AddClient form1 = new AddClient();
                form1.Show();
            }
        }

        private void saveAsXMLFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Client> clients2 = loadFromFile();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Client>));
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML File | *.xml";
            saveFileDialog.Title = "Save as XML file";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream s = File.Create(saveFileDialog.FileName))
                    serializer.Serialize(s, clients2);
            }
           
            
        }
    }
}
