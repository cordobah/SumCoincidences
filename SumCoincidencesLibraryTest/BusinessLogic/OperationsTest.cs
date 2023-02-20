
using Castle.Core.Logging;
using Fare;
using Microsoft.Extensions.Logging;
using Moq;
using SumCoincidencesLibrary.BusinessLogic;
using SumCoincidencesLibrary.Models;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace SumCoincidencesLibraryTest.BusinessLogic;

public class OperationsTests
{
    
    [Fact]
    public void GetSumCoincidences_NullAnalyseSumData_ThrowsNullReferenceException()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<Operations>>();
        var operations = new Operations(loggerMock.Object);
        
        // Act & Assert
        Assert.ThrowsException<NullReferenceException>(() => operations.GetSumCoincidences(null));
    }
    
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 9, 1)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 7, 2)]
    public void GetSumCoincidences_ReturnsExpectedResult(int[] numbers, int targetSum, int expectedCount)
    {
        // Arrange
        var loggerMock = new Mock<ILogger<Operations>>();
        var operations = new Operations(loggerMock.Object);
        var analyseSumData = new AnalyseSumData { Numbers = numbers.ToList(), TargetSum = targetSum };
        
        // Act
        var result = operations.GetSumCoincidences(analyseSumData);
        
        // Assert
        Assert.AreEqual(expectedCount, result.Count);
    }
    
    [Fact]
    public void GetSumCoincidences_FewerThanTwoNumbers_LogsError()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<Operations>>();
        var operations = new Operations(loggerMock.Object);
        var analyseSumData = new AnalyseSumData { Numbers = new List<int> { 1 }, TargetSum = 1 };
        
        // Act
        var result = operations.GetSumCoincidences(analyseSumData);
        
        // Assert

        loggerMock.VerifyLog(l => l.LogWarning(It.IsAny<ArgumentException>(), It.IsAny<string>()));

    }
}