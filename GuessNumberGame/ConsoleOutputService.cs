using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Services
{
	public class ConsoleOutputService : IOutputService
	{
		public void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}