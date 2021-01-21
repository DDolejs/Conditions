using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Kriteria
{
    public delegate bool Condition(string input);
    class ThreadMethods
    {
        public Condition[] CondArr { get; set; }
        Condition cond;
        public ThreadMethods()
        {
            CondArr = new Condition[]
            {
                ContainsThreeAndIsAtLeastThreeDigitsLong,
                ContainsThreeSameDigitsInARow
            };
            
        }

       
        private bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        private bool ContainsThreeAndIsAtLeastThreeDigitsLong(string input)
        {
            if (input.Contains("3")&& input.Length>=3) return true;
            else return false;
        }

        private bool ContainsThreeSameDigitsInARow(string input) 
        {
            for (int i = 2; i < input.Length; ++i)
            {
                if (input[i] == input[i - 1] && input[i] == input[i - 2])
                    return true;
            }
            return false;
        }

        public async Task<string> SearchAsync(int chosenCondition) 
        {
            cond = CondArr[chosenCondition];
            int result = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i <= int.MaxValue; i++)
                {
                    try
                    {
                        if (IsPrime(i) && cond(i.ToString()))
                        {
                            result = i;
                            break;
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                        return;
                    }
                }
            });

            return result.ToString();

        }
        
        
        
    }
}
