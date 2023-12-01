using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.DAL
{
    public class Conexao
    {

        SqlConnection con = new SqlConnection();

        public Conexao()
        {
            con.ConnectionString = @"Server=VINI\SQLSERVER2022;Database=ProjetoAcademia;Trusted_Connection=True;";
        }

        public SqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public void desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

