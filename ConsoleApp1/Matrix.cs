using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Matrix
    {
        public int height { get; }
        public int width { get; }
        public int[,] array { get; set; }
        public Matrix(int h, int w)
        {
            height = h;
            width = w;
            array = new int[w, h];
        }
        //индексатор
        public int this[int height, int width]
        {
            get
            {
                return array[height, width];
            }
            set
            {
                array[height, width] = value;
            }
        }

        //перезапись массива
        public void read(int [,]array_parametr)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    this.array[i, j] = array_parametr[i, j];

        }
        //генерация случайными числами
        public void generation(int min, int max)
        {
            Random r = new Random();
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    array[i, j] = r.Next(min, max);
            
        }
        //консольный вывод
        public void output()
        {
            for(int i=0;i<height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            
        }
        
    }
}
