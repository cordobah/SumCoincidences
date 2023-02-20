using System.Text.Json;
using Microsoft.Extensions.Logging;
using SumCoincidencesLibrary.Models;

namespace SumCoincidencesLibrary.BusinessLogic;

public class Operations: IOperations
{
    private readonly ILogger<Operations> _logger;

    public Operations(ILogger<Operations> logger)
    {
        _logger = logger;
    }

    public List<Coincidence> GetSumCoincidences(AnalyseSumData analyseSumData)
    {

        if (analyseSumData is null)
        {
            throw new NullReferenceException("There are not values in the json file. Please add some values in it.");
        }
        if (analyseSumData.Numbers?.Count < 2)
        {
            _logger.LogWarning("There are not enough values to find coincidence");
        }
        
        return CalculateCoincidences(analyseSumData);
    }


    private List<Coincidence> CalculateCoincidences(AnalyseSumData analyseSumData)
    {
        var coincidences = new List<Coincidence>();
        var seenNumbers = new HashSet<int>();

        foreach (int num in analyseSumData.Numbers)
        {
            int complement = analyseSumData.TargetSum - num;
            if (seenNumbers.Contains(complement))
            {
                coincidences.Add(new Coincidence() { FirstNumber = complement, SecondNumber = num });
            }
            seenNumbers.Add(num);
        }

        return coincidences;
    }

    private AnalyseSumData GetAnalyseSumData()
    {
         AnalyseSumData? sumParameters = JsonSerializer
             .Deserialize<AnalyseSumData>(File.ReadAllText("AnalyseSumData.json"));
         return sumParameters;
    }
}