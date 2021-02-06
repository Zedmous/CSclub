using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club
{
    public class MCarton
    {
        private int serial;
        private List<int> secuencia;
        public MCarton()
        {
            secuencia = new List<int>();
        }
        public void setSerial(int serial)
        {
            this.serial = serial;
        }
        public int getSerial()
        {
            return serial;
        }
        
        public void setESecuencia(int numero, int pos)
        {
            secuencia.Insert(pos, numero);
        }
        public int getESecuencia(int pos)
        {
            return secuencia[pos];
        }
        public void agregarESecuencia(int numero)
        {
            secuencia.Add(numero);
        }
        public void borrarESecuencia(int pos)
        {
            secuencia.RemoveAt(pos);
        }
        public int elementos()
        {
            return secuencia.Count();
        }
        
    }
}
