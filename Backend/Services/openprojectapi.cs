using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

public class OpenProjectApi
{
    private readonly HttpClient _httpClient;
    private readonly string apiToken = "d4a8577d2036f84f408aeb35bfface46117d0c47321db72deeede80b5c40bd07";
    private readonly string baseUrl = "https://project.highaltsolutions.in";
    private readonly string projectIdentifier = "hais-admin-v2-1";

    public OpenProjectApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"apikey:{apiToken}")));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<UserStory>> GetUserStoriesAsync()
    {
        var stories = new List<UserStory>();
        var url = $"{baseUrl}/api/v3/projects/{projectIdentifier}/work_packages";

        var response = await _httpClient.GetAsync(url);
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

            stories.Add(new UserStory
            {
                Id = id,
                Subject = subject,
                Description = description
            });
        }

        return stories;
    }
}

public class UserStory
{
    public string? Id { get; set; }
    public string? Subject { get; set; }
    public string? Description { get; set; }
}