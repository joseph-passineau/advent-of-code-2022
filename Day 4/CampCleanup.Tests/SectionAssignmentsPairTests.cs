namespace CampCleanup.Tests;

public class SectionAssignmentsPairTests
{
    [Theory]
    [InlineData(2, 4, 6, 8, false)]
    [InlineData(2, 3, 4, 5, false)]
    [InlineData(5, 7, 7, 9, false)]
    [InlineData(2, 8, 3, 7, true)]
    [InlineData(6, 6, 4, 6, true)]
    [InlineData(2, 6, 4, 8, false)]
    public void When_CheckingIfIsFullyContained_Should_ReturnProperResult(
        int firstSectionAssignmentsFrom,
        int firstSectionAssignmentsTo,
        int secondSectionAssignmentsFrom,
        int secondSectionAssignmentsTo,
        bool expectedResult
        )
    {
        var firstSectionAssignments = new SectionAssignments(firstSectionAssignmentsFrom, firstSectionAssignmentsTo);
        var secondSectionAssignments = new SectionAssignments(secondSectionAssignmentsFrom, secondSectionAssignmentsTo);

        var sectionAssignmentsPair = new SectionAssignmentsPair(firstSectionAssignments, secondSectionAssignments);

        Assert.Equal(expectedResult, sectionAssignmentsPair.IsFullyContained);
    }

    [Theory]
    [InlineData(2, 4, 6, 8, false)]
    [InlineData(2, 3, 4, 5, false)]
    [InlineData(5, 7, 7, 9, true)]
    [InlineData(2, 8, 3, 7, true)]
    [InlineData(6, 6, 4, 6, true)]
    [InlineData(2, 6, 4, 8, true)]
    public void When_CheckingIfIsOverLapped_Should_ReturnProperResult(
    int firstSectionAssignmentsFrom,
    int firstSectionAssignmentsTo,
    int secondSectionAssignmentsFrom,
    int secondSectionAssignmentsTo,
    bool expectedResult
    )
    {
        var firstSectionAssignments = new SectionAssignments(firstSectionAssignmentsFrom, firstSectionAssignmentsTo);
        var secondSectionAssignments = new SectionAssignments(secondSectionAssignmentsFrom, secondSectionAssignmentsTo);

        var sectionAssignmentsPair = new SectionAssignmentsPair(firstSectionAssignments, secondSectionAssignments);

        Assert.Equal(expectedResult, sectionAssignmentsPair.IsOverlapped);
    }
}
