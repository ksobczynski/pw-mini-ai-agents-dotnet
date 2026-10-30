// EXP-01: porównanie dwóch modeli w ekstrakcji piętra i windy
public static class ModelComparison
{
    private static readonly string[] DefaultModels =
    [
        "gemma3:4b",
        "mistral:latest",
        "deepseek-r1:14b"
    ];

    public static async Task RunAsync(OllamaClient client, IReadOnlyList<string> models)
    {
        if (models.Count == 0)
            models = DefaultModels;

        foreach (var model in models)
        {
            Console.WriteLine($"\nModel: {model}");

            var metrics = await Extraction.EvaluateAsync(
                client,
                model,
                TestData.Examples,
                note => Extraction.Prompt(note));

            ResultsCsv.Append("EXP-01", model, "zero-shot", 0, metrics);
        }
    }
}
