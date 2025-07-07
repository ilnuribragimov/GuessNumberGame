using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Services
{
	public class ConsoleInputService : IInputService
	{
		public int ReadGuess()
		{
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out int number))
					return number;
				Console.WriteLine("Введите корректное число.");
			}
		}
	}
}