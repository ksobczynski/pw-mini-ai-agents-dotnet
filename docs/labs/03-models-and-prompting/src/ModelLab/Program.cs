using var http = new HttpClient
{
    Timeout = TimeSpan.FromMinutes(5)
};

var client = new OllamaClient(http);

var experiment = args.FirstOrDefault();

// --model można podać wielokrotnie lub jako listę po przecinku:
// --model gemma3:4b --model qwen3:4b  albo  --model gemma3:4b,qwen3:4b
var models = new List<string>();

for (var i = 1; i < args.Length; i++)
{
    if (args[i] != "--model")
        continue;

    if (i + 1 >= args.Length)
    {
        Console.WriteLine("Po --model podaj nazwę modelu");
        return;
    }

    models.AddRange(args[++i].Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));
}

// EXP-02 ... EXP-04 uruchamiamy kolejno dla każdego podanego modelu
// (bez --model: null, czyli model domyślny eksperymentu)
string?[] runModels = models.Count > 0 ? [.. models] : [null];

switch (experiment)
{
    case "EXP-01":
        await ModelComparison.RunAsync(client, models);
        break;

    case "EXP-02":
        foreach (var model in runModels)
            await Prompting.RunAsync(client, model);
        break;

    case "EXP-03":
        foreach (var model in runModels)
            await Temperature.RunAsync(client, model);
        break;

    case "EXP-04":
        foreach (var model in runModels)
            await StructuredOutput.RunAsync(client, model);
        break;

    default:
        Console.WriteLine("Wybierz EXP-01 ... EXP-04 [--model nazwa]");
        return;
}

Console.WriteLine($"\nWyniki zapisano w {ResultsCsv.FilePath}");
