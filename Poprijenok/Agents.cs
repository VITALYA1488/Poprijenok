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
    public partial class Agents : Form
    {
        Model1 db = new Model1();
        public Agents()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 pmf = new Form4();
            pmf.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agent agent = (Agent)agentBindingSource.Current;
            DobAgents frm = new DobAgents();
            frm.db = db;
            frm.agent = null;
            DialogResult dr = frm.ShowDialog(); ;
            if (dr == DialogResult.OK)
            {
                agentBindingSource.DataSource = null;
                agentBindingSource.DataSource = db.Agent.ToList();
            }
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

        private void Agents_Load(object sender, EventArgs e)
        {
            agentBindingSource.DataSource = db.Agent.ToList();
            agentTypeBindingSource.DataSource = db.AgentType.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;
            int n = (int)comboBox1.SelectedValue;
            agentBindingSource.DataSource = db.Agent.Where(x => x.AgentTypeID == n).ToList();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Тип агента")
            {
                agentBindingSource.DataSource = db.Agent.OrderBy(a => a.AgentTypeID).ToList();
            }
            if (comboBox1.Text == "Приоритет")
            {
                agentBindingSource.DataSource = db.Agent.OrderBy(a => a.Priority).ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Agent ag = (Agent)agentBindingSource.Current;
            DialogResult dr = MessageBox.Show("Вы действтиельно хотите удалить агента - " +
                ag.Title.ToString() + "?", "Удаление агента",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Agent.Remove(ag);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            agentBindingSource.DataSource = db.Agent.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Agent agent = (Agent)agentBindingSource.Current;
            DobAgents frm = new DobAgents();
            frm.agent = agent;
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                agentBindingSource.DataSource = null;
                agentBindingSource.DataSource = db.Agent.ToList();
            }
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            agentBindingSource.DataSource = null;
            agentBindingSource.DataSource = db.Agent.ToList<Agent>();
        }

        private void SearchTxt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;
            int n = (int)comboBox1.SelectedValue;
            agentBindingSource.DataSource = db.Agent.Where(x => x.AgentTypeID == n).ToList();
        }
    }
}
