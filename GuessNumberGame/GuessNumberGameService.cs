using GuessNumberGame.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GuessNumberGame.Services
{
	public class GuessNumberGameService : IHostedService
	{
		private readonly ILogger<GuessNumberGameService> _logger;
		private readonly IConfiguration _configuration;

		public GuessNumberGameService(ILogger<GuessNumberGameService> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation($"{nameof(GuessNumberGameService)}.{nameof(StartAsync)}() -> Game is starting.");

			var gameSettings = _configuration.GetSection(nameof(GameSettingsOptions)).Get<GameSettingsOptions>();

			var settings = new GameSettings(min: gameSettings.Min, max: gameSettings.Max, maxAttempts: gameSettings.MaxAttempts);
			var numberGenerator = new RandomNumberGenerator();
			var inputService = new ConsoleInputService();
			var outputService = new ConsoleOutputService();

			var game = new GameEngine(numberGenerator, inputService, outputService, settings);
			game.Run();

			Console.WriteLine();

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_logger.LogInformation($"{nameof(GuessNumberGameService)}.{nameof(StartAsync)}() -> Game is stooped.");

			return Task.CompletedTask;
		}
	}
}
