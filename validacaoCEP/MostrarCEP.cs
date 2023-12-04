using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.validacaoCEP
{
    internal class MostrarCEP
    {
        public String MostraCep(String cepUsuario)
        {
            using (var ws = new WSCorreios.AtendeClienteClient())
            {

                Principal principal = new Principal();
                var enderecoWS = ws.consultaCEP(cepUsuario.ToString().Trim());

                return enderecoWS.end + ", " + enderecoWS.cidade + ", " + enderecoWS.bairro + ", " + enderecoWS.uf;
            }
            }
    }
}
