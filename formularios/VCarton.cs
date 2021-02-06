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
    public partial class VCarton : Form
    {
        private LDatos ldatos;//
        private MCarton mcarton;
        public VCarton()
        {
            InitializeComponent();
            ldatos = new LDatos();//esto es para hacer la corrida directamente
            limpiar();
        }
        public VCarton(LDatos ldatos)
        {
            InitializeComponent();
            this.ldatos = ldatos;//esto es para hacer la corrida de forma normal
            limpiar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "")
            {
                MessageBox.Show("Ingrese un numero de serial para buscar el carton", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbuscar.Focus();
            }
            else
            {
                int pos = ldatos.buscarCarton(Convert.ToInt32(txtbuscar.Text));//busca la posicion del carton
                if (pos >= 0)//si existe es una posicion mayor o igual a 0
                {
                    MessageBox.Show("Carton encontrado exitosamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mcarton = new MCarton();//instanciamos un nuevo objeto de tipo carton
                    mcarton = ldatos.getLCarton(pos);//buscamos el carton el la lista de datos, y lo guardamos en carton
                    txtserial.Text= Convert.ToString(mcarton.getSerial());
                    txt1.Text = Convert.ToString(mcarton.getESecuencia(0));
                    txt2.Text = Convert.ToString(mcarton.getESecuencia(1));
                    txt3.Text = Convert.ToString(mcarton.getESecuencia(2));
                    txt4.Text = Convert.ToString(mcarton.getESecuencia(3));
                    txt5.Text = Convert.ToString(mcarton.getESecuencia(4));
                    txt6.Text = Convert.ToString(mcarton.getESecuencia(5));
                    encontrado();//cambiamos el estado del formulario a un registro encontrado
                }
                else//sino existe es porque retorno -1
                {
                    MessageBox.Show("Carton no encontrado", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtserial.Text = "";
                }

            }
        }

        private void btngenerar_Click(object sender, EventArgs e)
        {
            noencontrado();
            mcarton = new MCarton();
            if (ldatos.generarCarton(mcarton)) {
                MessageBox.Show("Carton Generado exitosamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtserial.Text= Convert.ToString(mcarton.getSerial());
            txt1.Text = Convert.ToString(mcarton.getESecuencia(0));
            txt2.Text = Convert.ToString(mcarton.getESecuencia(1));
            txt3.Text = Convert.ToString(mcarton.getESecuencia(2));
            txt4.Text = Convert.ToString(mcarton.getESecuencia(3));
            txt5.Text = Convert.ToString(mcarton.getESecuencia(4));
            txt6.Text = Convert.ToString(mcarton.getESecuencia(5));
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if(txt1.Text==""){
                MessageBox.Show("Ingrese el numero 1", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt1.Focus();
            }else if(txt2.Text==""){
                MessageBox.Show("Ingrese el numero 2", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt2.Focus();
            }
            else if(txt3.Text==""){
                MessageBox.Show("Ingrese el numero 3", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt3.Focus();
            }
            else if(txt4.Text==""){
                MessageBox.Show("Ingrese el numero 4", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt4.Focus();
            }
            else if(txt5.Text==""){
                MessageBox.Show("Ingrese el numero 5", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt5.Focus();
            }
            else if(txt6.Text==""){
                MessageBox.Show("Ingrese el numero 6", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt6.Focus();
            }
            else{
                mcarton = new MCarton();

                //capturamos los datos nuevamente
                mcarton.setSerial(Convert.ToInt32(txtserial.Text));
                mcarton.agregarESecuencia(Convert.ToInt32(txt1.Text));
                mcarton.agregarESecuencia(Convert.ToInt32(txt2.Text));
                mcarton.agregarESecuencia(Convert.ToInt32(txt3.Text));
                mcarton.agregarESecuencia(Convert.ToInt32(txt4.Text));
                mcarton.agregarESecuencia(Convert.ToInt32(txt5.Text));
                mcarton.agregarESecuencia(Convert.ToInt32(txt6.Text));
                if (ldatos.buscarSecuencia(mcarton))//verifica nuevamente la secuencia por si editaron los datos
                {
                    MessageBox.Show("Secuencia de ticket existente ingrese uno diferente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ldatos.agregarCarton(mcarton);// se registra el carton a la lista que simula la base de datos
                    ldatos.setPote(ldatos.getPote() + 100);//se registran los 100$ al pote es automatico
                    ldatos.actualizar();
                    MessageBox.Show("Carton registrado exitosamente", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    encontrado();//estado del formulario cuando se encuentra un registro, en este caso se registro
                }
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("¿Desea restablecer los campos?", "Restablecer", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resp == DialogResult.Yes)//si en caso de que queramos restablecer el formulario a su estado por defecto
            {
                limpiar();
            }
        }

        public void limpiar()
        {
            txtbuscar.ReadOnly = false;
            txtserial.ReadOnly = true;
            txt1.ReadOnly = true;
            txt2.ReadOnly = true;
            txt3.ReadOnly = true;
            txt4.ReadOnly = true;
            txt5.ReadOnly = true;
            txt6.ReadOnly = true;
            txtbuscar.Text = "";
            txtserial.Text = "";
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            if (ldatos.getCartones()>0)
            {
                btnbuscar.Enabled = true;
            }
            else
            {
                btnbuscar.Enabled = false;
            }
            
            btngenerar.Enabled = true;
            btnregistrar.Enabled = false;
            btncancelar.Enabled = true;
        }
        public void encontrado()
        {
            txtbuscar.ReadOnly = true;
            txtserial.ReadOnly = true;
            txt1.ReadOnly = true;
            txt2.ReadOnly = true;
            txt3.ReadOnly = true;
            txt4.ReadOnly = true;
            txt5.ReadOnly = true;
            txt6.ReadOnly = true;
            txtbuscar.Text = "";
            btnbuscar.Enabled = false;
            btngenerar.Enabled = false;
            btnregistrar.Enabled = false;
            btncancelar.Enabled = true;
        }
        public void noencontrado()
        {
            txtbuscar.ReadOnly = true;
            txtserial.ReadOnly = true;
            txt1.ReadOnly = false;
            txt2.ReadOnly = false;
            txt3.ReadOnly = false;
            txt4.ReadOnly = false;
            txt5.ReadOnly = false;
            txt6.ReadOnly = false;
            txtbuscar.Text = "";
            btnbuscar.Enabled = false;
            btngenerar.Enabled = true;
            btnregistrar.Enabled = true;
            btncancelar.Enabled = true;
        }
    }
}
