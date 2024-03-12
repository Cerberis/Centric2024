using Centric2024.Core.Validators;

namespace Centric2024.Core.Tests
{
    public class MealRetrieverServiceValidatorTests
    {
        IMealRetrieverServiceValidator _sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _sut = new MealRetrieverServiceValidator();
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public async Task ValidateInput_WithEmptyInput_ThrowsArgumentNullException(string input)
        {
            Should.Throw<ArgumentNullException>(() =>
            {
                _sut.ValidateInput(ref input);
            });
        }

        [TestCase("a")]
        [TestCase("bc")]
        [TestCase("s  ")]
        public async Task ValidateInput_WithIncorrectLengthInput_ThrowsArgumentNullException(string input)
        {
            Should.Throw<ArgumentException>(() =>
            {
                _sut.ValidateInput(ref input);
            }).Message.ShouldStartWith("Name must consist of more than");
        }

        [TestCase("123")]
        [TestCase("asd    ")]
        public async Task ValidateInput_ValidInput_ShouldNotThrowException(string input)
        {
            Should.NotThrow(() =>
            {
                _sut.ValidateInput(ref input);
            });
        }
    }
}