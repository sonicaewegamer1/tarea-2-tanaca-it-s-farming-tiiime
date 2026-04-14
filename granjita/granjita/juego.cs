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
                        // SOLO cosecha uno (detalle "humano")
                        if (cultivos.Count > 0 && cultivos[0].Listo)
                        {
                            ventas.Add(new Venta(2, 30));
                            cultivos.RemoveAt(0);
                            Console.WriteLine("Cosechaste (se venderá en 2 días)");
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
                        foreach (var a in animales)
                        {
                            if (a.Listo)
                            {
                                ventas.Add(new Venta(3, 40));
                                a.Reset();
                                Console.WriteLine("Recolectaste producto");
                            }
                        }
                        break;

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

            foreach (var a in animales)
                a.PasarDia();

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