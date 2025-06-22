namespace Financial_Forecasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double initialValue = 1000;    
            double growthRate = 0.05;      
            int years = 5;

            double futureValue = ForecastValue(initialValue, growthRate, years);
            Console.WriteLine($"Forecasted value after {years} years: ${futureValue:F2}");
        }

        static double ForecastValue(double initial, double rate, int years)
        {
            if (years == 0)
                return initial;

            return ForecastValue(initial, rate, years - 1) * (1 + rate);
        }
    }
}