using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Club
{
    public class LDatos
    {
        private List<MCarton> lcarton;
        //private List<MLoteria> lloteria;
        private double pote;//guarda el valor que hay en el pote
        private int juegosloteria;//cantidad de juegos de loteria realizados
        private int juegosbingo;//cantidad de juegos de bingos realizados
        private double totalrepartidoL;//total repartido por loteria
        private double totalrepartidoB;//total repartido por bingo
        private double ganancias;//total de ganancias del club
        private VMenu vmenu;
        public LDatos()
        {
            lcarton = new List<MCarton>();
            pote = 0;
            juegosbingo = 0;
            juegosloteria = 0;
            totalrepartidoB = 0;
            totalrepartidoL = 0;
            ganancias = 0;
        }
        public LDatos(VMenu vmenu)
        {
            lcarton = new List<MCarton>();
            pote = 0;
            juegosbingo = 0;
            juegosloteria = 0;
            totalrepartidoB = 0;
            totalrepartidoL = 0;
            ganancias = 0;
            this.vmenu = vmenu;
        }
        public void setPote(double pote)
        {
            this.pote = pote;
        }
        public double getPote()
        {
            return pote;
        }
        public void setJuegosloteria(int juegosloteria)
        {
            this.juegosloteria = juegosloteria;
        }

        public int getJuegosloteria()
        {
            return juegosloteria;
        }

        public void setJuegosbingo(int juegosbingo)
        {
            this.juegosbingo = juegosbingo;
        }

        public int getJuegosbingo()
        {
            return juegosbingo;
        }

        public void setTotalrepartidoL(double totalrepartidoL)
        {
            this.totalrepartidoL = totalrepartidoL;
        }

        public double getTotalrepartidoL()
        {
            return totalrepartidoL;
        }

        public void setTotalrepartidoB(double totalrepartidoB)
        {
            this.totalrepartidoB = totalrepartidoB;
        }

        public double getTotalrepartidoB()
        {
            return totalrepartidoB;
        }
        public void setGanancias(double ganancias)
        {
            this.ganancias = ganancias;
        }

        public double getGanancias()
        {
            return ganancias;
        }
        //DATOS DE LA LISTA CARTON
        public void setLCarton(MCarton mcarton, int pos)
        {
            lcarton.Insert(pos, mcarton);
        }

        public MCarton getLCarton(int pos)
        {
            return lcarton[pos];
        }

        public void agregarCarton(MCarton mcarton)
        {
            Console.WriteLine("Registrando el carton");
            lcarton.Add(mcarton);
            Console.WriteLine(lcarton.Count());
        }

        public void borrarCarton(int pos)
        {
            lcarton.RemoveAt(pos);
        }
        public int getCartones()
        {
            return lcarton.Count();
        }
        public int buscarCarton(int serial)
        {
            int i = 0;
            while (i < lcarton.Count())
            {
                if (serial == lcarton[i].getSerial())
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        public bool buscarSecuencia(MCarton mcarton)
        {
            bool enc = false;
            int i = 0;
            while (i < lcarton.Count())//registrando cada carton
            {
                if (mcarton.getESecuencia(0) == lcarton[i].getESecuencia(0) && mcarton.getESecuencia(1) == lcarton[i].getESecuencia(1) && mcarton.getESecuencia(2) == lcarton[i].getESecuencia(2) && mcarton.getESecuencia(3) == lcarton[i].getESecuencia(3) && mcarton.getESecuencia(4) == lcarton[i].getESecuencia(4) && mcarton.getESecuencia(5) == lcarton[i].getESecuencia(5))
                {
                    enc = true;
                }
                i++;
            }
            return enc;
        }

        public bool generarCarton(MCarton mcarton)
        {
            bool generado = false;
            int serial = getCartones() + 1;
            mcarton.setSerial(serial);
            Generar generar = new Generar();
            int i = 0;
            int indice = 0;
            Random r = new Random();
            while (i < 6)
            {
                indice = r.Next(0, generar.getLnumeros());//posiciones de la lista a elegir disponibles
                mcarton.agregarESecuencia(generar.getObtenerNumero(indice));
                i++;
            }
            if (!buscarSecuencia(mcarton))
            {
                i = 1;
                generado = true;
            }


            return generado;
        }
        //DATOS PARA LA LOTERIA
        public bool generarLoteria(MLoteria mloteria)
        {
            bool generado = false;
            int loteria = juegosloteria + 1;
            mloteria.setNloteria(loteria);
            Generar generar = new Generar();
            int i = 0;
            int indice = 0;
            Random r = new Random();
            Console.WriteLine("Esperando numeros de loteria");
            while (i < 6)
            {
                indice = r.Next(0, generar.getLnumeros());//posiciones de la lista a elegir disponibles
                mloteria.agregarESecuencia(generar.getObtenerNumero(indice));
                i++;
            }

            generado = true;
            double acumular = 0;
            Console.WriteLine("Verificandos numeros de loteria");
            //verificar aciertos
            List<int> acierto = verificarLoteria(mloteria);//verifico los aciertos
            Console.WriteLine("Resumiendo numeros de loteria");
            mloteria.Aciertos6 = acierto[0];
            mloteria.Aciertos5 = acierto[1];
            mloteria.Aciertos4 = acierto[2];
            mloteria.Aciertos3 = acierto[3];
            double total6 = pote * 0.25;//monto a repartir con 6 aciertos a cada uno
            double total5 = pote * 0.2;//monto a repartir con 5 aciertos a cada uno
            double total4 = pote * 0.2;//monto a repartir con 4 aciertos a cada uno
            double total3 = pote * 0.25;//monto a repartir con 3 aciertos a cada uno
            double resto = pote * 0.1;
            mloteria.Total6 = total6;
            mloteria.Total5 = total5;
            mloteria.Total4 = total4;
            mloteria.Total3 = total3;
            if (acierto[0] == 0)
            {
                acumular += total6;
            }
            else
            {
                totalrepartidoL += total6;
            }
            if (acierto[1] == 0)
            {
                acumular += total5;
            }
            else
            {
                totalrepartidoL += total5;
            }
            if (acierto[2] == 0)
            {
                acumular += total4;
            }
            else
            {
                totalrepartidoL += total4;
            }
            if (acierto[3] == 0)
            {
                acumular += total3;
            }
            else
            {
                totalrepartidoL += total3;
            }
            double club = (resto) * 0.5;
            double extrapote = (acumular )+ resto* 0.5;
            pote = extrapote;//actualizamos el pote
            ganancias += club;//actualizamos las ganancias del club
            juegosloteria++;
            actualizar();
            return generado;
        }
        //VERITIFANDO LOS ACIERTOS DE LA LOTERIA
        public List<int> verificarLoteria(MLoteria mloteria)
        {
            List<int> laciertos = new List<int>();//lista de aciertos
            laciertos.Add(0);//para 6 aciertos posicion 0
            laciertos.Add(0);//para 5 aciertos posicion 1
            laciertos.Add(0);//para 4 aciertos posicion 2
            laciertos.Add(0);//para 3 aciertos posicion 3

            int i = 0;//indice para los cartones que estan registrados
            while (i < lcarton.Count())//revisando cada carton
            {
                int j = 0;//indice para los elementos del carton Y loteria
                int nivelacierto = 6;//mide elnivel de acierto
                Console.WriteLine("Aqui es");
                Console.WriteLine("Elementos de cartones");
                Console.WriteLine(lcarton[i].elementos());
                while (j < lcarton[i].elementos())//Revisando elementos del carton
                {
                    Console.WriteLine("Antes");
                    Console.WriteLine(j);
                    if (!(lcarton[i].getESecuencia(j) == mloteria.getESecuencia(j)))
                    {
                        nivelacierto--;//disminuimos el nivel de acierto porque no encontro
                    }
                    Console.WriteLine("Despues");
                    Console.WriteLine(j);
                    j++;
                }
                Console.WriteLine("Verificando componentes de los elementos");
                //actualizamos los aciertos segun sus niveles
                if (nivelacierto == 6)
                {
                    laciertos.Insert(0, laciertos[0] + 1);
                }
                else if (nivelacierto == 5)
                {
                    laciertos.Insert(1, laciertos[1] + 1);
                }
                else if (nivelacierto == 4)
                {
                    laciertos.Insert(2, laciertos[2] + 1);
                }
                else if (nivelacierto == 3)
                {
                    laciertos.Insert(3, laciertos[3] + 1);
                }
                i++;
            }
            return laciertos;
        }

        //DATOS DEL BINGO

        public bool generarBingo(MBingo mbingo)
        {
            bool generado = false;
            int bingo = juegosbingo + 1;
            mbingo.setNbingo(bingo);
            Generar generar = new Generar();
            int i = 0;
            int indice = 0;
            Random r = new Random();
            generado = true;
            double acumular = 0;
            int aciertos = 0;//verificara los aciertos
            while (i < 21)
            {
                indice = r.Next(0, generar.getLnumeros());//posiciones de la lista a elegir disponibles
                mbingo.agregarESecuencia(generar.getObtenerNumero(indice));
                i++;
                if (mbingo.getSecuencias()>=6)//como ya hay 6 elementos se procede a evaluar
                {
                    //verificar aciertos
                    aciertos = verificarBingo(mbingo);//verifico los aciertos hasta los numeros sorteados hasta el momento
                    if (aciertos > 0)
                    {
                        i = 21;
                    }
                }
            }
            
            double total = pote * 0.7;//monto a repartir con 6 aciertos a cada uno
            double resto = pote * 0.3;
            mbingo.Total = total;
            if (aciertos == 0)
            {
                acumular += total;
            }
            else
            {
                totalrepartidoB += total;
            }
            double club = (resto) * 0.5;
            double extrapote = acumular +resto* 0.5;
            pote = extrapote;//actualizamos el pote
            ganancias += club;//actualizamos las ganancias del club
            juegosbingo++;
            actualizar();
            return generado;
        }

        //VERIFICAR LOS ACIERTOS DEL BINGO
        public int verificarBingo(MBingo mbingo)
        {
            int aciertos = 0;//cantidad de aciertos
            int i = 0;//indice para los cartones que estan registrados
            while (i < lcarton.Count())//revisando cada carton
            {
                int j = 0;//indice para los elementos del carton
                int nivelcarton = 0;//mide cuantos aciertos lleva el carton
                while (j < lcarton[i].elementos())//Revisando elementos del carton
                {
                    int h = 0;//indice para los elementos del bingo
                    while (h < mbingo.getSecuencias())//revisando los elementos del bingo
                    {
                        if (lcarton[i].getESecuencia(j) == mbingo.getESecuencia(h))
                        {
                            h = mbingo.getSecuencias();//como encontro rompemos el ciclo del bingo para saltar a otro elemnto del carton
                            nivelcarton++;
                        }
                        h++;
                    }
                    //actualizamos los aciertos
                    if (nivelcarton == 6)
                    {
                        mbingo.agregarEGanador(lcarton[i].getSerial());
                        aciertos++;
                        j = lcarton[i].elementos();
                    }
                    j++;
                }

                i++;
            }
            return aciertos;
        }
        public void actualizar()
        {
            vmenu.actualizar();
        }
    }
}
