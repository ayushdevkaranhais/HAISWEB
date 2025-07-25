using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System;
using HAIS.Backend.Services;

namespace HAIS.Backend.BackgroundServices
{
    public class UserStoriesFetchService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public UserStoriesFetchService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var openProjectService = scope.ServiceProvider.GetRequiredService<OpenProjectService>();
                var isAuthenticated = await openProjectService.AuthenticateAsync();
                if (!isAuthenticated)
                {
                    Console.WriteLine("[UserStoriesFetchService] Authentication failed.");
                    return;
                }
                var stories = await openProjectService.FetchUserStoriesAsync();
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "user_stories");
                Directory.CreateDirectory(folderPath);
                int count = 0;
                foreach (var story in stories)
                {
                    string fileName = $"story-{count + 1}.md";
                    string path = Path.Combine(folderPath, fileName);
                    await File.WriteAllTextAsync(path, story);
                    count++;
                }
                Console.WriteLine($"[UserStoriesFetchService] ✅ {count} user stories saved.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}