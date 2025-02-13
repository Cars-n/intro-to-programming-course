// Strictly typed language, variables cannot change type
// Variable types are built on structs and classes
// Value types are defined by a struct and a reference types are defined by a class
namespace Banking.Tests.Syntax
{
    public class Types
    {
        string name = "carson";

        [Fact]
        public void DeclaringVariables()
        {
            System.Int32 num1 = 0;
            Int32 num2 = 0; // "System" is not needed because its implicitly used

            int age = 21;

            var letter = 'C';

            decimal cost1 = 18.23M; // Use M suffix so it doesnt assume double type
            var cost2 = 18.23M;

            Assert.Equal("carson", this.name);
            Assert.Equal("carson", name); // Using "this" is optional
        }

        [Fact]
        public void AnotherThing()
        {
            Assert.Equal("carson", name);
        }
    }
}
