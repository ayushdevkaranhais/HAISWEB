using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using HAIS.Backend.Models; // Make sure you have this model created

namespace HAIS.Backend.Services
{
    public class OpenProjectService
    {
        private readonly HttpClient httpClient;
        private readonly OpenProjectOptions options;

        public OpenProjectService(HttpClient client, IOptions<OpenProjectOptions> optionsAccessor)
        {
            httpClient = client;
            options = optionsAccessor.Value;

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                    Encoding.ASCII.GetBytes($"apikey:{options.ApiToken}")));

            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> AuthenticateAsync()
        {
            var url = $"{options.BaseUrl}/api/v3/users/me";
            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<string>> FetchUserStoriesAsync()
        {
            var result = new List<string>();
            var url = $"{options.BaseUrl}/api/v3/projects/{options.ProjectIdentifier}/work_packages";

            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var workPackages = doc.RootElement
                    .GetProperty("_embedded")
                    .GetProperty("elements")
                    .EnumerateArray();

                foreach (var wp in workPackages)
                {
                    if (!wp.TryGetProperty("_links", out var links)) continue;
                    if (!links.TryGetProperty("type", out var typeLink)) continue;
                    if (!typeLink.TryGetProperty("title", out var titleProp)) continue;

                    string typeTitle = titleProp.GetString()?.ToLowerInvariant() ?? "";
                    if (!typeTitle.Contains("user story")) continue;

                    string subject = wp.GetProperty("subject").GetString() ?? "No Subject";
                    string id = wp.GetProperty("id").ToString();
                    string description = wp.GetProperty("description").GetProperty("raw").GetString() ?? "No description.";

                    string content = $"# {subject}\n\n{description}";
                    result.Add(content);
                }

                return result;
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}
