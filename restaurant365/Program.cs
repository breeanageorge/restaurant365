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
            Console.WriteLine("Unit test: //!!!@@###\n1@@-2\n3###-4!!!5,-6");
            Calculator("//!!!@@###\n1@@-2\n3###-4!!!5,-6");
            Console.WriteLine("Unit test: //!!*###\n123*456!!-789###1001!!-5000");
            Calculator("//!!*###\n123*456!!-789###1001!!-5000");
            Console.WriteLine("Unit test: 123");
            Calculator("123");
            Console.WriteLine("Unit test: //*\n3*asdf\n3*abc\n-3*1004");
            Calculator("//*\n3*asdf\n3*abc\n-3*1004");
            Console.WriteLine("Unit test: //????##\n-abc,asdf##wer????qewr,erer????eee");
            Calculator("//????##\n-abc,asdf##wer????qewr,erer????eee");
            Console.WriteLine("Unit test: -1\n-2\n-3");
            Calculator("-1\n-2\n-3");

            Console.ReadKey();
        }

        public static void Calculator(string user_in)
        {
            //Variables
            int total = 0;
            int temp_num = 0;
            List<int> negativesList = new List<int>();
            List<int> numList = new List<int>();
            List<string> delimiterList = new List<string>(new string[] { ",", "\n", "\\n"});

            //Check if custom delimiter exists in input
            if (user_in.StartsWith("//"))
            {
                string[] temp_string = user_in.Split(new string[] {"\n", "\\n"}, 2, StringSplitOptions.None);
                temp_string[0] = temp_string[0].Remove(0, 2);
                user_in = temp_string[1];

                //Go through delimiters and seperate them
                StringBuilder temp_word = new StringBuilder();
                temp_word.Append(temp_string[0].Substring(0, 1));
                for (int i = 1; i < temp_string[0].Length; i++)
                {
                    if(temp_string[0].Substring(i, 1) == temp_string[0].Substring(i-1, 1))
                    {   
                        //Append char to temporary word 
                        temp_word.Append(temp_string[0].Substring(i, 1));
                    }
                    else if(temp_string[0].Substring(i, 1) != temp_string[0].Substring(i - 1, 1) && temp_string[0].Substring(i, 1) != temp_string[0].Substring(i + 1, 1))
                    {
                        //If it is a single char delimiter add it to the delimiter list
                        delimiterList.Add(temp_string[0].Substring(i, 1));
                    }
                    else
                    {
                        //Add word to delimiter list
                        delimiterList.Add(temp_word.ToString());
                        temp_word.Clear();
                        //Append char to temporary word 
                        temp_word.Append(temp_string[0].Substring(i, 1));
                    }
                }
                delimiterList.Add(temp_word.ToString());
                temp_word.Clear();
            }

            //Split string at ',' and '\n' and parse string values into variables
            string[] nums = user_in.Split(delimiterList.ToArray(), StringSplitOptions.None);

            //Loop through array values
            for (int i = 0; i < nums.Length; i++)
            {
                //Set temp num to the value of the current point in array
                Int32.TryParse(nums[i], out temp_num);
                if (temp_num < 0)
                {
                    //Append negative number to list for exception
                    negativesList.Add(temp_num);
                    //Add 0 to numList
                    numList.Add(0);
                }
                else if(temp_num <= 1000)
                {
                    //Add it to the current total
                    total += temp_num;
                    //Add number to numList
                    numList.Add(temp_num);
                }
                else
                {
                    //Add 0 to numList
                    numList.Add(0);
                }
                //Set temp num back to 0 in case of invalid input
                temp_num = 0;
            }

            //Write total to console
            Console.WriteLine("Answer: {0} = {1}", String.Join("+", numList), total);
            //Write negatives exception to console
            if (negativesList.Count > 0)
            {
                Console.WriteLine("Exception - Negative Numbers: {0}", String.Join(", ", negativesList));
            }
        }
    }
}
