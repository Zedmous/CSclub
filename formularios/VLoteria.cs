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
    public partial class VLoteria : Form
    {
        private LDatos ldatos;
        private MLoteria mloteria;
        public VLoteria()
        {
            InitializeComponent();
            this.ldatos = new LDatos();//esto es para hacer la corrida directamente
            limpiar();
        }
        public VLoteria(LDatos ldatos)
        {
            InitializeComponent();
            this.ldatos = ldatos;//esto es para hacer la corrida normal
            limpiar();
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Instanciando la loteria");
            mloteria = new MLoteria();
            Console.WriteLine("Generando la loteria");
            ldatos.generarLoteria(mloteria);
            Console.WriteLine("Imprimiendo resultados la loteria");
            txt1.Text = Convert.ToString(mloteria.getESecuencia(0));
            txt2.Text = Convert.ToString(mloteria.getESecuencia(1));
            txt3.Text = Convert.ToString(mloteria.getESecuencia(2));
            txt4.Text = Convert.ToString(mloteria.getESecuencia(3));
            txt5.Text = Convert.ToString(mloteria.getESecuencia(4));
            txt6.Text = Convert.ToString(mloteria.getESecuencia(5));
            if (mloteria.Aciertos6>0)
            {
                txtganadores6.Text = Convert.ToString(mloteria.Aciertos6);
                txttotal6.Text = Convert.ToString(mloteria.Total6);

            }
            else
            {
                txtganadores6.Text = "0";
                txttotal6.Text = "0";
            }
            if (mloteria.Aciertos5 > 0)
            {
                txtganadores5.Text = Convert.ToString(mloteria.Aciertos5);
                txttotal5.Text = Convert.ToString(mloteria.Total5);
            }
            else
            {
                txtganadores5.Text = "0";
                txttotal5.Text = "0";
            }
            if (mloteria.Aciertos4 > 0)
            {
                txtganadores4.Text = Convert.ToString(mloteria.Aciertos4);
                txttotal4.Text = Convert.ToString(mloteria.Total4);
            }
            else
            {
                txtganadores4.Text = "0";
                txttotal4.Text = "0";
            }
            if (mloteria.Aciertos3 > 0)
            {
                txtganadores3.Text = Convert.ToString(mloteria.Aciertos3);
                txttotal3.Text = Convert.ToString(mloteria.Total3);
            }
            else
            {
                txtganadores3.Text = "0";
                txttotal3.Text = "0";
            }
            MessageBox.Show("Loteria Generada", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnrestablecer_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            const bool V = true;
            txt1.ReadOnly = V;
            txt2.ReadOnly = V;
            txt3.ReadOnly = V;
            txt4.ReadOnly = V;
            txt5.ReadOnly = V;
            txt6.ReadOnly = V;
            txtganadores6.ReadOnly = V;
            txtganadores5.ReadOnly = V;
            txtganadores4.ReadOnly = V;
            txtganadores3.ReadOnly = V;
            txttotal6.ReadOnly = V;
            txttotal5.ReadOnly = V;
            txttotal4.ReadOnly = V;
            txttotal3.ReadOnly = V;
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txtganadores6.Text = "";
            txtganadores5.Text = "";
            txtganadores4.Text = "";
            txtganadores3.Text = "";
            txttotal6.Text = "";
            txttotal5.Text = "";
            txttotal4.Text = "";
            txttotal3.Text = "";
            btngenerar.Enabled = V;
            btnrestablecer.Enabled = V;
        }
        public void nencontrado()
        {
            const bool V = true;
            const bool F = false;
            btngenerar.Enabled = F;
            btnrestablecer.Enabled = V;
        }
    }
}
