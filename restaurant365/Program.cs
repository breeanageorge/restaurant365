using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant365
{
    class Program
    {
        static void Main(string[] args)
        {
            //User input
            Console.WriteLine("Type any number,number:  ");
            string user_input = Console.ReadLine();

            //Call Calculator Function
            Calculator(user_input);

            //Unit tests
            Console.WriteLine("Unit test: 1,2");
            Calculator("1,2");
            Console.WriteLine("Unit test: 123,456");
            Calculator("123,456");
            Console.WriteLine("Unit test: 123");
            Calculator("123");
            Console.WriteLine("Unit test: 3,asdf");
            Calculator("3,asdf");
            Console.WriteLine("Unit test: abc,asdf");
            Calculator("abc,asdf");
            Console.WriteLine("Unit test: 1,2,3");
            Calculator("1,2,3");

            Console.ReadKey();
        }

        public static void Calculator(string user_in)
        {
            //Variables
            int total = 0;
            int first_num = 0;
            int second_num = 0;

            //Split string at , and parse string values into variables
            string[] nums = user_in.Split(',');
            Int32.TryParse(nums[0], out first_num);
            //Check if there are at least 2 items in the array
            if (nums.Length > 1)
            {
                Int32.TryParse(nums[1], out second_num);
            }

            //Add numbers together
            total = first_num + second_num;

            //Write total to console
            Console.WriteLine(total);
        }
    }
}
