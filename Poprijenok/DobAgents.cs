using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poprijenok
{
    public partial class DobAgents : Form
    {
        public Model1 db { get; set; }
        public Agent agent { get; set; }
        public DobAgents()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agents pmf = new Agents();
            pmf.Show();
            Hide();
        }

        private void DobAgents_Load(object sender, EventArgs e)
        {
            if (agent == null)
            {
                agentBindingSource.AddNew();

                Text = " Добавление нового клиента ";
            }
            else
            {
                agentBindingSource.Add(agent);
                iDTextBox.ReadOnly = true;
                Text = " Корректировка клиента " + agent.ID;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (agent == null)
            {
                agent = (Agent)agentBindingSource.List[0];
                db.Agent.Add(agent);
            }
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Ошибка " + ex.InnerException.InnerException.Message);
            }
        }

        private void logoTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
