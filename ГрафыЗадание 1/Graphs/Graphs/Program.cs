using System;


namespace Graphs
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            int flag = 0;
            IGraph? graph=null;
            StreamWriter? sw = null;

            for (int i = 0; i < args.Length; i++)
            {
                for (int j = 0; j < args.Length; j++)
                    if (args[j] == "-h")
                    {
                        ShowHelp();
                        flag = 1;
                        break;
                    }
                if (flag == 1)
                {
                    break;
                }
            }
            for (int i = 0; i<args.Length; i++) 
            {
                if (args[i]=="-m")
                {
                    graph = new Matrix(args[i + 1]);
          

                }
                else if (args[i]=="-e")
                {
                    graph = new EList(args[i+1]);

                }
                else if (args[i]=="-l")
                {
                    graph = new ADJGraph(args[i + 1]); 
                }
                else if (args[i] == "-o")
                {
                    sw = new StreamWriter(args[i+1]);
                    sw.AutoFlush = true;
                }
                
            }
            if (graph==null)
            {
                return;
            }
            if (sw == null)
            {
                sw = new StreamWriter(Console.OpenStandardOutput());
                sw.AutoFlush = true;
                Console.SetOut(sw);
            }
            if (graph.IsDirected() == false)
            {
                List<int> vector = new List<int>();
                vector = graph.VectorNOriented();
                sw.Write("Вектор ");
                vector.ArrayOutput(sw);
                sw.WriteLine();

            }
            else
            {
                List<int> V1 = new List<int>();
                List<int> V2 = new List<int>();
                V1 = graph.VectorOriented().Item1;
                sw.Write("Вектор++ ");
                V1.ArrayOutput(sw);
                sw.WriteLine();
                V2 = graph.VectorOriented().Item2;
                sw.Write("Вектор--  ");
                V2.ArrayOutput(sw);
                sw.WriteLine();
            }
            ////////////////////////////////
            var dist = graph.Floyd();
            var extr = DegreeVector.Excentr(dist);
            if (extr.Count == 0)
            {
                return;
            }
            sw.WriteLine();


            sw.WriteLine("Эксентриситет ");
            extr.ArrayOutput(sw);
            if (graph.IsDirected() == true)
            {
                return;
            }
            var radius = DegreeVector.Rad(extr);
            sw.WriteLine();
            sw.WriteLine($"Радиус - {radius}");
            var diameter = DegreeVector.Diameter(extr);
            sw.WriteLine($"Диаметр {diameter}");
            var CentralVert = DegreeVector.CVert(extr);
            sw.Write("Центральные вершины -  ");
            CentralVert.ArrayOutput(sw);
            sw.WriteLine();
            var PeripheralVert = DegreeVector.PVert(extr);
            sw.Write("Периферийные вершины - ");
            PeripheralVert.ArrayOutput(sw);
            sw.WriteLine();
            sw.WriteLine("Расстояния \n");
            dist.Matrix_output(sw);
            void ShowHelp()
            {
                Console.WriteLine("Выполнено студентом Малафеевым Андреем\n Группа М3О-225Бк-21\n Ключи:\n -m - Граф считывается из Матрицы смежности\n -e - Граф считывается из Списка ребер\n -l - Граф считывается из Списка смежности\n -o - Вывести результат в файл");
            }
        }
            





    }

}