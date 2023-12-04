using Academia.validacao;
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
    internal class LoginDaoComando {
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

            try {
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
                this.mensagem = "Erro no banco de dados";
            }
            return tem;
        }

        public String cadastrar(String email, String nome, String senha, String cep)
        {

            ValidaCEP validaCEP = new ValidaCEP();

            if (validaCEP.ValidacaoCEP(cep))
            {
                tem = false;
                //comando para inserir no banco
                cmd.CommandText = "insert into logins values (@e,@n,@s,@c);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@n", senha);
                cmd.Parameters.AddWithValue("@s", nome);
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
            }else
            {
                
                this.mensagem = "Por favor digite um CEP válido!";
                return mensagem;
           
            }
        }
        }
    }

