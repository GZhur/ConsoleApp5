namespace TestProject1
{
    public class AnagrammEqualityComparerTests
    {
        private static readonly AnagrammEqualityComparer _anagrammEqualityComparer = new AnagrammEqualityComparer(ignoreCase: false);

        [Fact]
        public void TestGetHashCode_SwappedCharacters_True()
        {
            // Arrange
            string word1 = "сон";
            string word2 = "нос";

            // Act
            int hashCode1 = _anagrammEqualityComparer.GetHashCode(word1);
            int hashCode2 = _anagrammEqualityComparer.GetHashCode(word2);

            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }

        [Fact]
        public void TestGetHashCode_SwappedCharacters_False()
        {
            // Arrange
            string word1 = "кот";
            string word2 = "нос";

            // Act
            int hashCode1 = _anagrammEqualityComparer.GetHashCode(word1);
            int hashCode2 = _anagrammEqualityComparer.GetHashCode(word2);

            // Assert
            Assert.NotEqual(hashCode1, hashCode2);
        }

        [Fact]
        public void AnagrammEqualityComparer_Equals_True()
        {
            // Arrange
            string word1 = "кот";
            string word2 = "кто";

            // Act
            bool result = _anagrammEqualityComparer.Equals(word1, word2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AnagrammEqualityComparer_Equals_False()
        {
            // Arrange
            string word1 = "нос";
            string word2 = "кто";

            // Act
            bool result = _anagrammEqualityComparer.Equals(word1, word2);

            // Assert
            Assert.False(result);
        }
    }
}