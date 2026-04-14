using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace granjita
{
    internal class Juego
    {
        bool Fin;
        int dia;
        int dinero;
        int espacioMax;

        List<Cultivo> cultivos;
        List<Animal> animales;
        List<Venta> ventas;

        private void InitVariables()
        {
            Fin = false;
            dia = 1;
            dinero = 100;
            espacioMax = 3;

            cultivos = new List<Cultivo>();
            animales = new List<Animal>();
            ventas = new List<Venta>();
        }

        public Juego()
        {
            InitVariables();
            Console.WriteLine("Bienvenido a tu granja");
        }

        public void Run()
        {
            while (!Fin)
            {
                Console.WriteLine("\n--- Día " + dia + " ---");
                Console.WriteLine("Dinero: " + dinero);
                Console.WriteLine("Espacio usado: " + (cultivos.Count + animales.Count) + "/" + espacioMax);

                Console.WriteLine("1. Plantar");
                Console.WriteLine("2. Cosechar");
                Console.WriteLine("3. Comprar animal");
                Console.WriteLine("4. Recolectar animal");
                Console.WriteLine("5. Pasar día");
                Console.WriteLine("0. Salir");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        if (cultivos.Count + animales.Count >= espacioMax)
                        {
                            Console.WriteLine("No hay espacio");
                            break;
                        }
                        cultivos.Add(new Cultivo());
                        Console.WriteLine("Plantaste algo");
                        break;

                    case 2:
                        if (cultivos.Count > 0)
                        {
                            int antes = ventas.Count;
                            // guardamos cuántas ventas había antes

                            cultivos[0].Producir(ventas);
                            // llama a la interfaz IProducible
                            // no importa si es Cultivo o Animal, ambos tienen Producir()
                         

                            if (ventas.Count > antes)
                            {
                                cultivos.RemoveAt(0);
                                Console.WriteLine("Cosechaste (se venderá en 2 días)");
                            }
                        }
                        break;

                    case 3:
                        if (cultivos.Count + animales.Count >= espacioMax)
                        {
                            Console.WriteLine("No hay espacio");
                            break;
                        }

                        if (dinero >= 50)
                        {
                            animales.Add(new Animal());
                            dinero -= 50;
                            Console.WriteLine("Compraste un animal");
                        }
                        else
                        {
                            Console.WriteLine("No tienes dinero");
                        }
                        break;

                    case 4:
                        {
                            bool recolectoAlgo = false;

                            foreach (var a in animales)
                            {
                                int antes = ventas.Count;

                                a.Producir(ventas);
                                //  uso de la interfas
                                // deja que el Animal decida si produce o no
                               

                                if (ventas.Count > antes)
                                {
                                    Console.WriteLine("Recolectaste producto");
                                    recolectoAlgo = true;
                                }
                            }

                            if (!recolectoAlgo)
                            {
                                Console.WriteLine("No hay nada que recoger :c");
                            }
                            break;
                        }

                    case 5:
                        PasarDia();
                        break;

                    case 0:
                        Fin = true;
                        break;
                }
            }
        }

        private void PasarDia()
        {
            dia++;

            foreach (var c in cultivos)
                c.PasarDia();
            // método heredado de la clase  SerGranja

            foreach (var a in animales)
                a.PasarDia();
            // es el mismo metodo pero cada clase lo usará diferente

            foreach (var v in ventas.ToArray())
            {
                v.PasarDia();

                if (v.Listo)
                {
                    dinero += v.Ganancia;
                    ventas.Remove(v);
                    Console.WriteLine("Venta completada, recibiste dinero");
                }
            }
        }
    }
}