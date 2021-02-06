using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Club
{
    public partial class VBingo : Form
    {
        private LDatos ldatos;
        private MBingo mbingo;
        public VBingo()
        {
            InitializeComponent();
            this.ldatos = new LDatos();//esto es para hacer la corrida directamente
            
        }
        public VBingo(LDatos ldatos)
        {
            InitializeComponent();
            this.ldatos = ldatos;//esto es para hacer la corrida normal
            
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            limpiar();
            Console.WriteLine("Instanciando EL BINGO");
            mbingo = new MBingo();
            Console.WriteLine("Generando EL BINGO");
            ldatos.generarBingo(mbingo);
            Console.WriteLine("Imprimiendo resultados del bingo");
            int i = 0;
            while (i<mbingo.getSecuencias())
            {
                tbresultados.Items.Add(mbingo.getESecuencia(i));
                i++;
            }
            if (mbingo.getGanadores()> 0)
            {
                int j = 0;
                while (j< mbingo.getGanadores())
                {
                    tbganadores.Items.Add(mbingo.getEGanador(j));
                    j++;
                }
                txttotal.Text = Convert.ToString(mbingo.Total);

            }
            else
            {
                tbganadores.Items.Clear();
                txttotal.Text = "0";
            }
            
            MessageBox.Show("Bingo Generada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void btnrestablecer_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            /**/
            txttotal.Text = "0";
            txttotal.ReadOnly = true;
            tbresultados.Items.Clear();
            tbganadores.Items.Clear();
        }
    }
}
