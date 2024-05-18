using Coder;
using Product;
using window;

namespace start
{
    class Program
    {
        static void Main()
        {
            IProduct l1=new Lamp(1,"lamp",213,32,"белый");
            Lamp l2 = new Lamp(2, "lamp2", 23, 2, "желтый");
            FloorLamp l3 = new FloorLamp(23, "Floorlamp3", 23, 2, "желтый", 123);
            FloorLamp l4 = new FloorLamp(1, "Floorlamp4", 23, 2, "желтый", 123);

            ShowСase<IProduct> vitrina1 = (5, 1);
            vitrina1.Add(l1);
            vitrina1.Add(l2, 3);
            vitrina1.Add(l3);
            vitrina1.Add(l2);
            vitrina1.ID = 2;
            var sample1 = new FloorLamp(2, "FloorLamp5", 23, 2, "зеленый", 231);
            var sample2 = new Lamp(3, "lamp3", 32, 1, "черный");
            Console.WriteLine(sample2);
            
            vitrina1.Add(sample2);
            sample1.ID_Device += 1;
            sample2.ID_Device += 1;
            vitrina1.ID = 5;
            vitrina1.Show();

        }

    }
}