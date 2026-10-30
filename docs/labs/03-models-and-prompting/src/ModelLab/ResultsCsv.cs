using System.Globalization;

public static class ResultsCsv
{
    private const string Header =
        "experiment,model,variant,temperature,total,valid_json,floor_accuracy,elevator_accuracy,exact_match,avg_ms";

    public static string FilePath { get; } =
        Path.Combine(Directory.GetCurrentDirectory(), "results", "results.csv");

    public static void Append(
        string experiment,
        string model,
        string variant,
        double temperature,
        Metrics metrics)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);

        if (!File.Exists(FilePath))
            File.WriteAllText(FilePath, Header + Environment.NewLine);

        var line = string.Join(",",
            experiment,
            model,
            variant,
            Format(temperature),
            metrics.Total,
            metrics.ValidJson,
            Format(Math.Round(metrics.FloorAccuracy, 2)),
            Format(Math.Round(metrics.ElevatorAccuracy, 2)),
            Format(Math.Round(metrics.ExactMatchRate, 2)),
            Format(Math.Round(metrics.AvgMs)));

        File.AppendAllText(FilePath, line + Environment.NewLine);
    }

    private static string Format(double value) =>
        value.ToString(CultureInfo.InvariantCulture);
}
