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
            Console.WriteLine("Type any set of numbers seperated by , or newline, or your custom delimiter:  ");
            string user_input = Console.ReadLine();

            //Call Calculator Function
            Calculator(user_input);

            //Unit tests
            Console.WriteLine("Unit test: //!\n1,-2\n3\n-4!5,-6");
            Calculator("//!\n1,-2\n3\n-4!5,-6");
            Console.WriteLine("Unit test: //!\n123!456!-789!1001!-5000");
            Calculator("//!\n123!456!-789!1001!-5000");
            Console.WriteLine("Unit test: 123");
            Calculator("123");
            Console.WriteLine("Unit test: //*\n3*asdf\n3*abc\n-3*1004");
            Calculator("//*\n3*asdf\n3*abc\n-3*1004");
            Console.WriteLine("Unit test: //?\n-abc,asdf\nwer?qewr,erer\neee");
            Calculator("//?\n-abc,asdf\nwer?qewr,erer\neee");
            Console.WriteLine("Unit test: -1\n-2\n-3");
            Calculator("-1\n-2\n-3");

            Console.ReadKey();
        }

        public static void Calculator(string user_in)
        {
            //Variables
            int total = 0;
            int temp_num = 0;
            string custom = "";
            List<int> negativesList = new List<int>();

            //Check if custom delimiter exists in input
            if (user_in.StartsWith("//"))
            {
                custom = user_in.Substring(2,1);
            }

            //Split string at ',' and '\n' and parse string values into variables
            string[] nums = user_in.Split(new string[] { ",", "\n", "\\n", custom }, StringSplitOptions.None);

            //Loop through array values
            for (int i = 0; i < nums.Length; i++)
            {
                //Set temp num to the value of the current point in array
                Int32.TryParse(nums[i], out temp_num);
                if (temp_num < 0)
                {
                    //Append negative number to list for exception
                    negativesList.Add(temp_num);
                }
                else if(temp_num <= 1000)
                {
                    //Add it to the current total
                    total += temp_num;
                }
                //Set temp num back to 0 in case of invalid input
                temp_num = 0;
            }

            //Write total to console
            Console.WriteLine("Answer: {0}", total);
            //Write negatives exception to console
            if (negativesList.Count > 0)
            {
                Console.WriteLine("Exception - Negative Numbers: {0}", String.Join(", ", negativesList));
            }
        }
    }
}
