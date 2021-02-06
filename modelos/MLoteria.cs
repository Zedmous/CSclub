using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club
{
    public class MLoteria
    {
        private int nloteria;
        private List<int> secuencia;
        private double total6;
        private double total5;
        private double total4;
        private double total3;
        private int aciertos6;
        private int aciertos5;
        private int aciertos4;
        private int aciertos3;

        public double Total6 { get => total6; set => total6 = value; }
        public double Total5 { get => total5; set => total5 = value; }
        public double Total4 { get => total4; set => total4 = value; }
        public double Total3 { get => total3; set => total3 = value; }
        public int Aciertos6 { get => aciertos6; set => aciertos6 = value; }
        public int Aciertos5 { get => aciertos5; set => aciertos5 = value; }
        public int Aciertos4 { get => aciertos4; set => aciertos4 = value; }
        public int Aciertos3 { get => aciertos3; set => aciertos3 = value; }
        

        public MLoteria()
        {
            secuencia = new List<int>();
        }
        public void setNloteria(int nloteria)
        {
            this.nloteria = nloteria;
        }
        public int getNloteria()
        {
            return nloteria;
        }
        public void setESecuencia(int numero,int pos)
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
