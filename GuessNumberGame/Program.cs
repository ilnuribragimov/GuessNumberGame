using GuessNumberGame.Core;
using GuessNumberGame.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = CreateHostBuilder(args).Build();
host.Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                _ = hostContext.Configuration
                .GetSection(nameof(GameSettingsOptions))
                .Get<GameSettingsOptions>() ?? throw new ArgumentException("Missing GameSettingsOptions configuration section");

                services.Configure<GameSettingsOptions>(hostContext.Configuration.GetSection(nameof(GameSettingsOptions)));
                services.AddHostedService<GuessNumberGameService>();
            });
