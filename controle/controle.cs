using Academia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.controle
{
    public class Controle{

        public bool tem;
        public String mensagem = "";
        public bool acessar(String login, String senha)
        {
            LoginDaoComando loginDaoComando = new LoginDaoComando();
            tem = loginDaoComando.verificarLogin(login, senha);
            if (!loginDaoComando.mensagem.Equals("")){
                this.mensagem = loginDaoComando.mensagem;
            }
            return tem;
        }

        public String cadastrar(String email, String nome, String senha, String cep)
        {
            LoginDaoComando loginDaoComando = new LoginDaoComando();
            this.mensagem = loginDaoComando.cadastrar(email, nome, senha, cep);
            if (loginDaoComando.tem)
            {
                this.tem = true;
            }
            return mensagem;
        }
    }
}
