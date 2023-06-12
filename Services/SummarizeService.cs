using Azure;
using System;
using Azure.AI.OpenAI;
using ShortKnowledge.Models;

namespace ShortKnowledge.Services;

public static class SummarizeService
{
    private static string ApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? string.Empty; 

    public static async Task<string> Summarize(ShortRequestViewModel model)
    {
        OpenAIClient client = new OpenAIClient(ApiKey);

        string deploymentName = "gpt-3.5-turbo";
        string query = "Fasse mir folgenden Text auf maximal 100 Wörter und auf deutsch zusammen: " + model.Text;
        
        var message = new ChatMessage( ChatRole.User, query);
        List<ChatMessage> messages = new List<ChatMessage> { message };

        ChatCompletionsOptions options = new ChatCompletionsOptions
        {
            MaxTokens = 100,
        };
        options.Messages.Add(message);

        Response<ChatCompletions> completionsResponse = await client.GetChatCompletionsAsync(deploymentName, options);
        string completion = completionsResponse.Value.Choices[0].Message.Content;

        Console.WriteLine($"Chatbot: {completion}");

        return completion;
    }
}
