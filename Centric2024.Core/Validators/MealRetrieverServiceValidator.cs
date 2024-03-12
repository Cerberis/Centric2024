namespace Centric2024.Core.Validators
{
    public class MealRetrieverServiceValidator : IMealRetrieverServiceValidator
    {
        const int MinimumMealNameLength = 3;
        public void ValidateInput(ref string mealName)
        {
            mealName = mealName?.Trim();

            if (string.IsNullOrWhiteSpace(mealName))
                throw new ArgumentNullException();

            if (mealName.Length < MinimumMealNameLength)
                throw new ArgumentException($"Name must consist of more than {MinimumMealNameLength - 1} symbols");
        }
    }
}
