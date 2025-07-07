using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Services
{
	public class RandomNumberGenerator : INumberGenerator
	{
		private readonly Random _random = new Random();

		public int Generate(int min, int max)
		{
			return _random.Next(min, max + 1);
		}
	}
}