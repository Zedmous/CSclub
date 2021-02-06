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
    public partial class VLogin : Form
    {
        
        private MLogin mlogin;
        private bool InicioSeccion = false;
        public bool _InicioSeccion { get { return InicioSeccion; } set { InicioSeccion = value; } }

        public VLogin()
        {
            InitializeComponent();
        }
        
        private void btningresar_Click(object sender, EventArgs e)
        {
            if (verificar())
            {
                mlogin = new MLogin();
                
                if (mlogin.acceder(txtlogin.Text.ToUpper(), txtclave.Text.ToUpper()))
                {
                    
                    MessageBox.Show("¡CONTRASEÑA CORRECTA, SEA BIENVENIDO!", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InicioSeccion = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("USUARIO O CLAVE INCORRECTA", "Logueo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }

        public bool verificar()
        {
            if (txtlogin.Text.Equals(""))
            {
                return false;
            }else if (txtclave.Text.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
