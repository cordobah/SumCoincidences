using SumCoincidencesLibrary.Models;

namespace SumCoincidencesLibrary.BusinessLogic;

public interface IOperations
{
    List<Coincidence> GetSumCoincidences(AnalyseSumData analyseSumData);
}