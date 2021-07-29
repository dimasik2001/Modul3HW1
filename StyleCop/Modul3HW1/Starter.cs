using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul3HW1
{
    public class Starter
    {
        public void Run()
        {
            var list = new MyList<int>(new int[] { 6, 7, 7, 8, 9, 10, 55, -1, -66, -286, 7 });
            list.Remove(6);
            list.Remove(7);
            list.Remove(10);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------");

            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
