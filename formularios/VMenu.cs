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
    public partial class VMenu : Form
    {
        private LDatos ldatos;
        private VLogin vlogin= new VLogin();
        public VMenu()
        {
            InitializeComponent();
            ldatos = new LDatos(this);
            actualizar();

        }
        public VMenu(LDatos ldatos)
        {
            InitializeComponent();
            this.ldatos = ldatos;
            actualizar();
        }

        private void btnbingo_Click(object sender, EventArgs e)
        {
            VBingo vbingo = new VBingo(ldatos);
            vbingo.ShowDialog();
        }
        private void btnloteria_Click(object sender, EventArgs e)
        {
            VLoteria vloteria = new VLoteria(ldatos);
            vloteria.ShowDialog();
        }
        public void actualizar()
        {
            txtpote.Text = Convert.ToString(ldatos.getPote());
            txtcartones.Text = Convert.ToString(ldatos.getCartones());
            txtganancias.Text = Convert.ToString(ldatos.getGanancias());
            txtloterias.Text = Convert.ToString(ldatos.getJuegosloteria());
            txtbingos.Text = Convert.ToString(ldatos.getJuegosbingo());
            txttotalL.Text= Convert.ToString(ldatos.getTotalrepartidoL());
            txttotalB.Text = Convert.ToString(ldatos.getTotalrepartidoB());
            txtpote.ReadOnly=true;
            txtcartones.ReadOnly = true;
            txtganancias.ReadOnly = true;
            txtloterias.ReadOnly = true;
            txtbingos.ReadOnly = true;
            txttotalL.ReadOnly = true;
            txttotalB.ReadOnly = true;
            if (ldatos.getCartones()==0)
            {
                btnbingo.Enabled = false;
                btnloteria.Enabled = false;
            }
            else
            {
                btnbingo.Enabled = true;
                btnloteria.Enabled = true;
            }
        }
        private void btncarton_Click(object sender, EventArgs e)
        {
            VCarton vcarton = new VCarton(ldatos);
            vcarton.ShowDialog();
        }

        private void VMenu_Load(object sender, EventArgs e)
        {
            vlogin.ShowDialog();
            if (vlogin._InicioSeccion == false)
            {
                this.Close();
            }
        }
    }
}
        