using System.Text.Json;
using SumCoincidencesLibrary.BusinessLogic;
using SumCoincidencesLibrary.Models;

namespace SumCoincidences;

public class App
{
    private readonly IOperations _operations;

    public App(IOperations operations)
    {
        _operations = operations;
    }

    public void Run(string[] args)
    {
        var data = GetAnalyseSumData(args);
        List<Coincidence> coincidences = _operations.GetSumCoincidences(data);

        foreach (var coincidence in coincidences)
        {
            Console.Write($"- ({coincidence.FirstNumber},{coincidence.SecondNumber})");
            Console.WriteLine();
        }
    }
    
    private AnalyseSumData GetAnalyseSumData(string[] args)
    {
        AnalyseSumData? sumParameters = JsonSerializer
            .Deserialize<AnalyseSumData>(File.ReadAllText("AnalyseSumData.json"));
        return sumParameters;
    }
}