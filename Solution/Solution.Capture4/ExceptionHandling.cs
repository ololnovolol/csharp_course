using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Capture4
{
    public class ExceptionHandling
    {
        private int x = 10;
        private int j = 10;
        string[] f = new string[5];
        public int result;

        public ExceptionHandling()
        {
            try
            {
                result = x / j;
                if (f.Length > 0)
                {
                    j = 10;
                }
                else
                {
                    throw new ArgumentException("Danger! exception by Throw new =)");
                }

                try
                {
                    f[6] = "name";
                }
                catch (Exception)
                {

                    throw new MyExceptoin("MyExceptoin! by Throw new =)", f.Length);
                }
                finally
                {
                    Console.WriteLine($"MyExceptoin finally");
                }

            }
            catch (DivideByZeroException) when (x > 100)
            {
                Console.WriteLine($"\nCatch One!!! DivideByZeroException in code\n");
            }
            catch (DivideByZeroException) when (x < 100)
            {
                Console.WriteLine($"\nCatch Two!!! DivideByZeroException in code\n");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"\nCatch Three!!! DivideByZeroException in code\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nCatch Four !exeption in code: {ex.Message}\n");
            }
            finally
            {
                Console.WriteLine("Block finally");
            }

        }
    }

}