namespace BigHomework_1.Classes
{
    public static class LoanCalculator
    {
        public static double Calculate(double summ, int months, double percent)
        {
            var intToPercent = percent / 100 / 12;
            return summ * (intToPercent + (intToPercent / (Math.Pow(1 + intToPercent, months) - 1)));
        }
    }
}
