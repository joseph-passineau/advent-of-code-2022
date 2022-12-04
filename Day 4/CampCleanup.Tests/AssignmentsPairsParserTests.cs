namespace CampCleanup.Tests;
public class AssignmentsPairsParserTests
{
    [Theory]
    [InlineData("2-4,6-8", new[] {2, 3, 4}, new[] {6, 7 ,8})]
    [InlineData("2-3,4-5", new[] {2, 3}, new[] {4, 5})]
    [InlineData("5-7,7-9", new[] {5, 6, 7}, new[] {7, 8, 9})]
    [InlineData("2-8,3-7", new[] {2, 3, 4, 5, 6, 7, 8}, new[] { 3, 4, 5, 6, 7 })]
    [InlineData("6-6,4-6", new[] {6}, new[] { 4, 5, 6 })]
    [InlineData("2-6,4-8", new[] {2, 3, 4, 5, 6}, new[] { 4, 5, 6, 7, 8 })]
    public void When_ParsingAssignmentsPairs_ShouldParse(
        string line, 
        int[] expectedFirstSectionAssignmentsIds,
        int[] expectedSecondSectionAssignmentsIds
    )
    {
        var parser = new AssignmentsPairsParser(line);

        Assert.Equal(expectedFirstSectionAssignmentsIds, parser.Pair.FirstSectionAssignments.SectionIds);
        Assert.Equal(expectedSecondSectionAssignmentsIds, parser.Pair.SecondSectionAssignments.SectionIds);
    }
}
