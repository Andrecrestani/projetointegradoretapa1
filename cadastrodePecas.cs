using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_integrador
{
    public partial class cadastrodePecas : Form
    {
        public cadastrodePecas()
        {
            InitializeComponent();
        }


        private MySqlConnectionStringBuilder conexaoBanco()
        {

            MySqlConnectionStringBuilder conexaoDB = new MySqlConnectionStringBuilder();
            conexaoDB.Server = "localhost";
            conexaoDB.Database = "peças";
            conexaoDB.UserID = "root";
            conexaoDB.Password = "";
            conexaoDB.SslMode = 0;
            return conexaoDB;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtpartnunber.Clear();
            txtnome.Clear();
            txtdescricao.Clear();
            mtbdata.Clear();
            
        }

        private void cadastrodePecas_Load(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void atualizaGrid()
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM filme WHERE ativoFilme = 1";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgpeca.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgpeca.Rows[0].Clone();//FAZ UM CAST E CLONA A LINHA DA TABELA
                    row.Cells[0].Value = reader.GetInt32(0);//ID
                    row.Cells[1].Value = reader.GetString(1);//NOME
                    row.Cells[2].Value = reader.GetString(2);//DESCRICAO
                    row.Cells[3].Value = reader.GetString(3);//CATEGORIA
                    row.Cells[4].Value = reader.GetString(4);//ANO
                    dgpeca.Rows.Add(row);//ADICIONO A LINHA NA TABELA
                }

                realizaConexacoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message);
            }
        }
        private void cadastroDePeçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastrodePecas cadastro = new cadastrodePecas();
            cadastro.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

