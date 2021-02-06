using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club
{
    public class MBingo
    {
        private int nbingo;
        private List<int> secuencia;
        private List<int> ganadores;
        private double total;//total a repartir
        
        public double Total { get => total; set => total = value; }
        public MBingo()
        {
            secuencia = new List<int>();
            ganadores = new List<int>();
        }
        public void setNbingo(int nbingo)
        {
            this.nbingo = nbingo;
        }
        public int getNbingo()
        {
            return nbingo;
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
        public int getSecuencias()
        {
            return secuencia.Count();
        }
        public void setEGanador(int numero, int pos)
        {
            ganadores.Insert(pos, numero);
        }
        public int getEGanador(int pos)
        {
            return ganadores[pos];
        }
        public void agregarEGanador(int numero)
        {
            ganadores.Add(numero);
        }
        public void borrarEGanador(int pos)
        {
            ganadores.RemoveAt(pos);
        }
        public int getGanadores()
        {
            return ganadores.Count();
        }
    }
}
