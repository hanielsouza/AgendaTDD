using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;
            string strCon = @"Data Source = LAPTOP-BRVE8T7A\SQLEXPRESS;Initial Catalog=Agenda;Integrated Security=True;";
            string id = Guid.NewGuid().ToString();
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            string sql = String.Format("insert into Contato (Id,Nome) values('{0}','{1}')", id,nome);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            sql = string.Format("select Nome from Contato where Id = '{0}'",id);
            cmd = new SqlCommand(sql, con);
           txtContatoSalvo.Text =  cmd.ExecuteScalar().ToString();
            con.Close();
        }
    }
}
