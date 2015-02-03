namespace JustUnitTestFramework
{
    using System;
    using System.Linq;
    using System.Reflection;
    using JustUnitTestFramework.Library;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(@"Not enough arguments. Use: Program C:\..\..");
                Environment.Exit(0);
            }

            Assembly libriry = Assembly.LoadFile(args[0]);
            var types = libriry.GetTypes();

            foreach (var type in types)
            {
                if (type.IsClass && type.IsPublic)
                {
                    var methods = type.GetMethods();
                    foreach (var method in methods)
                    {
                        var attribute = method.GetCustomAttribute(typeof(JustTestAttribute));
                        if (attribute != null)
                        {
                            object obj = Activator.CreateInstance(type);
                            try
                            {
                                method.Invoke(obj, null);
                                Console.WriteLine("{0} -> Test passed", method.Name);
                            }
                            catch (Exception ex)
                            {
                                if (ex.InnerException is JustTestFailedException)
                                {
                                    Console.WriteLine("{0} -> Test failed", method.Name);
                                }
                                else
                                {
                                    Console.WriteLine("{0} -> Test failed because of exception of type {0}", method.Name, ex.InnerException.GetType().Name);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}