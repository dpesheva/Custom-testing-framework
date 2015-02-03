namespace MyTests
{
    using System;
    using System.Linq;
    using JustUnitTestFramework.Library;

    public class Tests
    {
        [JustTest]
        public void TestSumWith1And5()
        {
            TestMe testMe = new TestMe();
            var result = testMe.Sum(1, 5);

            JustAssert.IsTrue(result == 6);
        }
    }
}