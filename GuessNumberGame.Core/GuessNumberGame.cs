using GuessNumberGame.Interfaces;

namespace GuessNumberGame.Core
{
	public class GameEngine
	{
		private readonly INumberGenerator _numberGenerator;
		private readonly IInputService _inputService;
		private readonly IOutputService _outputService;
		private readonly GameSettings _settings;

		public GameEngine(INumberGenerator numberGenerator, IInputService inputService,
						  IOutputService outputService, GameSettings settings)
		{
			_numberGenerator = numberGenerator;
			_inputService = inputService;
			_outputService = outputService;
			_settings = settings;
		}

		public void Run()
		{
			int secretNumber = _numberGenerator.Generate(_settings.Min, _settings.Max);
			int attemptsLeft = _settings.MaxAttempts;

			_outputService.ShowMessage($"Угадайте число от {_settings.Min} до {_settings.Max}. У вас {attemptsLeft} попыток.");

			while (attemptsLeft > 0)
			{
				_outputService.ShowMessage("Введите число:");
				int guess = _inputService.ReadGuess();
				attemptsLeft--;

				if (guess == secretNumber)
				{
					_outputService.ShowMessage("Поздравляем! Вы угадали число.");
					return;
				}
				else if (guess < secretNumber)
				{
					_outputService.ShowMessage("Загаданное число больше.");
				}
				else
				{
					_outputService.ShowMessage("Загаданное число меньше.");
				}

				if (attemptsLeft == 0)
				{
					_outputService.ShowMessage($"Попытки закончились. Загаданное число было: {secretNumber}");
				}
			}
		}
	}
}