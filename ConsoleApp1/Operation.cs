using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Operation
    {
        public Matrix matrix { get; }
        CircularLinkedList<Zero> circularList = new CircularLinkedList<Zero>();
        public Operation(Matrix matrix)
        {
            this.matrix = matrix;
        }
        public void lineDiff()
        {

            int[] minNumber = new int[matrix.height];//массив минимальных чисел со всех строк
            //нахождение минимальных чисел из каждой строки
            for(int i=0;i< matrix.height;i++)
            {
                minNumber[i] = matrix[i, 0];//берем за минимальное число сначало первый элемент в строке
                for (int j = 1; j < matrix.width; j++)
                {
                    if(minNumber[i]> matrix[i, j])//если числа из строки больше чем выбранный до этого элемент - меняем минимальное значение
                    {
                        minNumber[i] = matrix[i, j];
                    }
                }
            }
            //разница всей строки от минимального числа для этой строки и так для всей матрицы
            for (int i = 0; i < matrix.height; i++)
            {
                for (int j = 0; j < matrix.width; j++)
                {
                    matrix[i, j] = matrix[i, j] - minNumber[i];
                }
            }
        }
        public void columnDiff()
        {
            int[] minNumber = new int[matrix.width];//массив минимальных чисел со всех столбцов
            //нахождение минимальных чисел из каждого столбца
            for (int j = 0; j < matrix.width; j++)
            {
                minNumber[j] = matrix[0, j];//берем за минимальное число сначало первый элемент в столбце
                for (int i = 1; i < matrix.height; i++)
                {
                    if (minNumber[j] > matrix[i, j])//если числа из столбца больше чем выбранный до этого элемент - меняем минимальное значение
                    {
                        minNumber[j] = matrix[i, j];
                    }
                }
            }
            //разница всего столбца от минимального числа для этой столбца и так для всей матрицы
            for (int j = 0; j < matrix.width; j++)
            {
                for (int i = 0; i < matrix.height; i++)
                {
                    matrix[i, j] = matrix[i, j] - minNumber[j];
                }
            }
        }
        public void appointments()
        {
            zeroSearch();
            Console.WriteLine(searchCombination());

        }

        

        private void zeroSearch()
        {
            for(int i=0;i<matrix.height;i++)
            {
                for (int j = 0; j < matrix.width; j++)
                {
                    if(matrix[i,j]==0)
                    {
                        circularList.Add(new Zero(i, j));
                    }
                }

            }
        }
        private bool searchCombination()
        {
            Node<Zero> current = circularList.head;
            int countOfSucces=0;
            do
            {
                CircularLinkedList<Zero> succesZero = new CircularLinkedList<Zero>();
                succesZero.Add(current.Data);
                for(int a=0;a<circularList.Count;a++)
                {
                    countOfSucces = 0;
                    for (int b = 0; b < succesZero.Count; b++)
                    {
                        if(circularList[a].Data.i != succesZero[b].Data.i & circularList[a].Data.j != succesZero[b].Data.j)
                        {
                            ++countOfSucces;
                        }
                    }
                    if(countOfSucces==succesZero.Count)
                    {
                        succesZero.Add(circularList[a].Data);
                    }
                    if(countOfSucces==matrix.height)
                    {
                        break;
                    }
                }

                if (countOfSucces == matrix.height)
                {
                    foreach(var item in succesZero)
                    {
                        Console.WriteLine((item.i+1)+" "+(item.j+1));
                    } 
                    return true;
                }



                current = current.Next;
            } while (current != circularList.head);
            return false;
        }

    }
}
