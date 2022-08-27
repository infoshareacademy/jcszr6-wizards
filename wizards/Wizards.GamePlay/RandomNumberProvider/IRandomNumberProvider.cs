namespace Wizards.GamePlay.RandomNumberProvider;

public interface IRandomNumberProvider
{
    Task<int> GetRandomNumberAsync(int min, int max);
    Task<List<int>> GetManyRandomNumbersAsync(int min, int max, int count);
}