namespace Wizards.GamePlay.RandomNumberProvider;

public class RandomNumberProvider : IRandomNumberProvider
{
    private readonly Random _randomizer;

    public RandomNumberProvider()
    {
        _randomizer = new Random(DateTime.Now.Millisecond);
    }

    public Task<int> GetRandomNumberAsync(int min, int max)
    {
        var result = _randomizer.Next(min, max + 1);
        return Task.FromResult(result);
    }

    public Task<Queue<int>> GetManyRandomNumbersAsync(int min, int max, int count)
    {
        var result = new Queue<int>();

        if (count <= 0)
        {
            return Task.FromResult(result);
        }

        for (int i = 0; i < count; i++)
        {
            var number = _randomizer.Next(min, max + 1);
            result.Enqueue(number);
        }

        return Task.FromResult(result);
    }
}