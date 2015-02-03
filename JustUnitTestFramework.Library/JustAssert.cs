using System;
using System.Linq;

namespace JustUnitTestFramework.Library
{
    public static class JustAssert
    {
        public static void IsTrue(bool actual)
        {
            if (!actual)
            {
                throw new JustTestFailedException();
            }
        }
    }
}