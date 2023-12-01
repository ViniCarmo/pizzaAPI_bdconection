using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.validacao
{
    public class validaCEP
    {
        Principal principal = new Principal();
        Cadastro cadastro = new Cadastro();
        public void validacaoCEP(TextBox cepUsuario)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {
                try
                {
                    Principal principal = new Principal();
                    var enderecoWS = ws.consultaCEP(cepUsuario.Text.Trim());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.cadastro.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

          
            {

            }
        }
    }
}
