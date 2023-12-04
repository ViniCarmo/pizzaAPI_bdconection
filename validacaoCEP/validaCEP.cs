using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.validacao
{
    public class ValidaCEP {


        // Método que retorna as informações do CEP

        Principal principal = new Principal();
        Cadastro cadastro = new Cadastro();

        public String ValidacaoCEP(TextBox cepUsuario)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {
                try
                {
                    Principal principal = new Principal();
                    var enderecoWS = ws.consultaCEP(cepUsuario.Text.Trim());
                    return "De acordo com seu CEP sua localização é " + enderecoWS.end + ", " + enderecoWS.cidade + ", " + enderecoWS.bairro + ", " + enderecoWS.uf;
                   

                }
                catch (Exception ex)
                {
                    return ex.Message;
                    
                }
            }

            {

            }
        }

        public bool ValidacaoCEP(String cepUsuario)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {
                try
                {
                    Principal principal = new Principal();
                    var enderecoWS = ws.consultaCEP(cepUsuario.ToString().Trim());
                    return true;

                }
                catch (Exception ex)
                {
                } return false;
            }

        }



    }
        }

