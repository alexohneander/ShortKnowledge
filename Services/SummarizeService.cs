using Azure;
using Azure.AI.OpenAI;
using ShortKnowledge.Models;

namespace ShortKnowledge.Services;

public static class SummarizeService
{
    public static async Task<string> Summarize(ShortRequestViewModel model)
    {
        string query = "Fasse mir folgenden Text auf maximal 50 Wörter und auf deutsch zusammen: " + model.Text;

        OpenAIClient client = new OpenAIClient("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");

        string deploymentName = "text-davinci-003";
        string prompt = query;
        Response<Completions> completionsResponse = await client.GetCompletionsAsync(deploymentName, prompt);
        string completion = completionsResponse.Value.Choices[0].Text;

        Console.WriteLine($"Chatbot: {completion}");

        return completion;
    }
}