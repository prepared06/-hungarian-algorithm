using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(4, 4);
            
            matrix.generation(1,9);

            Operation operation = new Operation(matrix);

            matrix.output();
            Console.WriteLine();

            operation.lineDiff();
            matrix.output();
            Console.WriteLine();

            operation.columnDiff();
            matrix.output();
            Console.WriteLine();
            operation.appointments();


            Console.ReadKey();
        }
    }
}
