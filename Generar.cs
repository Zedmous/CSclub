using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club
{
    
    class Generar
    {
        private List<int> lnumeros;
        public Generar()
        {
            lnumeros = new List<int>();
            generarnumeros();
        }
        public void generarnumeros()
        {
            //Generara los numeros del 1 al 42
            int i = 1;
            while (i<=42)
            {
                lnumeros.Add(i);
                i++;
            }
        }
        public int getLnumeros(){
            return lnumeros.Count();
        }

        public int getObtenerNumero(int pos)
        {
            int valor = lnumeros[pos];
            lnumeros.RemoveAt(pos);
            return valor;
        }
        
    }
}
