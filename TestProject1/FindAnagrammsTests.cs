using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class FindAnagrammsTests
    {


        private readonly string[][] _assertResult = new[]
        {
            new string[]{"ток", "кот", "Кто" },
            new string[]{"рост", "торс" },
            new string[]{"фывап" },
            new string[]{"рок" }
        };

        [Fact]
        public void FindAnagrammsByLinq()
        {
            // Arrange
            var words = new string[]
            {
               "ток","рост","кот","торс","Кто","фывап","рок"
            };


            // Act
            var result = words
                .GroupBy(x => x, new AnagrammEqualityComparer(ignoreCase: true))
                .Select(x =>
                    x.Select(s => s).ToArray()
                ).ToArray();

            // Assert

            var isSequenceEqual = CompareArrays(result, _assertResult);
            Assert.True(isSequenceEqual);
        }


        private bool CompareArrays(string[][] arr1, string[][] arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;

            for (int i = 0; i < arr1.Length; i++)
            {
                var innerArray1 = arr1[i];
                var innerArray2 = arr2[i];
                if (innerArray1.Length != innerArray2.Length)
                    return false;

                if (!innerArray1.SequenceEqual(innerArray2))
                    return false;
            }
            return true;
        }
    }
}
