
namespace Program
{
    class MyArr
    {
        public int _length { get { return _array.Length; } }
        private int[] _array;
        public int Count { get; private set; }

        public MyArr(int length)
        {
            _array = new int[length];
            Count = 0;
        }

        public MyArr(int[] arr)
        {
            int length = (int)(arr.Length * 1.5);
            _array = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                _array[i] = arr[i];
            }
            Count = _array.Length;
        }

        //int _num;
        //public int Num
        //{
        //    get { return _num; }
        //    set { _num = value;}
        //} 

          
    public int this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        public void IncreathLength(int countElements=1)
        {
            int newLength = _length;
            while (newLength <= _length)
            {
                newLength = (int)(newLength  + countElements);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _length);
            _array = newArray;  // Зачем?
        }

       
        //1)Написать метод добавления по индексу
        //Add(int element, int index){} пример: Я хочу добавить элемент
        //4 на позицию 3(Другие элементы должны сдвинуться)   1, 2, 3, 5 => 1, 2, 3, 4, 5
        public void Addindex(int index, int value)
        {
            if (Count >= _array.Length) // Зачем это здесь?!
            {
                IncreathLength();
            }
            int[] newArray = new int[_array.Length];
            Array.Copy( _array, 0, newArray, 0, index);
            newArray[index] = value;
            Console.WriteLine(_array.Length);
            int diapTwo = _array.Length - (index + 1);
            Array.Copy(_array, index, newArray, index+1, diapTwo);
            _array = newArray; // Зачем?
        }


        //2)Написать метод для уменьшения размера массива(По аналогии с Increathlength)
        public void Decrease() // Работает!!!!!!!!!!!!!!!!!
        {
            int[] newArray = new int[_array.Length - 1];
            int len = _array.Length - 1;
            Array.Copy(_array, newArray, _array.Length-1);
            _array = newArray; // ПАЧЕМУ?!!!
        }

        //3)Написать удаление элемента по индексу
        public void DeleteIndex(int index)
        {
            Decrease(); 
            int[] newArray = new int[_array.Length];
            Array.Copy(_array, 0, newArray, 0, index);
            Console.WriteLine(_array.Length);
            int diapazonTwo = _array.Length - (index+1);// Здесь должно быть = _array.Length - (index);
                                                        // но так не получается и поэтому последний элемент массива не копируется
                                                        // не знаю почему!
            Array.Copy(_array, index+1, newArray, index, diapazonTwo);
            _array = newArray;
        }

        //4)Написать метод удаления элементов. То есть я хочу удалить из списка
        //все элементы равные 5(название метода Remove(int element)) 1, 5, 2, 3, 5 => 1, 2, 3
        public void Remove(int value)
        {   

            for (int i = 0; i < _array.Length; ++i)
            if (_array[i] == value)                        // Работает неправильно, не могу понять
            {
                    DeleteIndex(_array[i]);
            }
        }

        //5)Написать метод нахождения максимального числа
        public void PoiskMax()
        {
            int max=0;
            for (int i = 0; i < _array.Length; ++i)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            Console.WriteLine("Максимальный элемент = " + max);
        }

        //6)Написать метод нахождения минимального числа
        public void PoiskMin()
        {
            int min = 3; 
            for (int i = 0; i < _array.Length; ++i)
            {
                
                if (_array[i] < min)
                {
                    
                    min = _array[i];
                }
                
            }
            Console.WriteLine("Минимальный элемент = " + min);
        }



        public void Create()
        {
            Random random = new Random();
            for (int i = 0; i < _array.Length; ++i)
            {
                _array[i] = (random.Next(1, 9));
            }

        }

        public void Print()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write(_array[i]+" ");
            }
            Console.WriteLine();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
           int[] mas = new int [10];
            MyArr massive = new MyArr(mas);
            massive.Create();
            massive.Print();
            massive.Addindex(6, 31); // 1
            massive.Print();
            massive.Decrease();      // 2
            massive.Print();
            massive.DeleteIndex(5);  // 3 Работает неправильно, не могу понять
            massive.Print();
            massive.Remove(7);       // 4 Работает неправильно, не могу понять
            massive.Print();
            massive.PoiskMax();      // 5
            massive.Print();
            massive.PoiskMin();      // 6
            massive.Print();
        }
    }
}
