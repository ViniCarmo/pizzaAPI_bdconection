using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.DAL
{
    internal class LoginDaoComando{
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao(); 
        SqlDataReader dr;   

        public bool verificarLogin(String login, String senha)
        {
            //comandos sql para ver se tem no banco
            cmd.CommandText = "select * from logins where email = @email and senha = @senha";
            cmd.Parameters.AddWithValue("@email", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try{
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro no banc" +
                    "" +
                    "o de dados";
            }
            return tem;
        }

        public String cadastrar(String email, String nome, String senha, String cep)
        {
            tem = false;
            //comando para inserir no banco
            cmd.CommandText = "insert into logins values (@e,@n,@s,@c);";
            cmd.Parameters.AddWithValue("@e",email);
            cmd.Parameters.AddWithValue("@n", nome);
            cmd.Parameters.AddWithValue("@s", senha);
            cmd.Parameters.AddWithValue("@c", cep);

            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.mensagem = "Cadastrado com sucesso!";
                tem = true;
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com o banco de dados";
            }

            return mensagem;
        }
    }
}
