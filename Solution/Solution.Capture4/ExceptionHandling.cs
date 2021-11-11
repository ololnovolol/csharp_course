using System;

namespace Solution.Capture4
{
    public class ExceptionHandling
    {
        private int x = 10;
        private int j = 10;
        private readonly string[] f = new string[5];
        public int result;

        public ExceptionHandling()
        {
            try
            {
                result = x / j;
                j = f.Length > 0 ? 10 : throw new ArgumentException("Danger! exception by Throw new =)");

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