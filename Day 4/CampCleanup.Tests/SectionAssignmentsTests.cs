namespace CampCleanup.Tests;

public class SectionAssignmentsTests
{
    [Theory]
    [InlineData(2, 4, new[] { 2, 3, 4 } )]
    [InlineData(6, 8, new[] { 6, 7, 8 } )]
    [InlineData(2, 3, new[] { 2, 3 } )]
    [InlineData(4, 5, new[] { 4, 5 } )]
    [InlineData(5, 7, new[] { 5, 6, 7 } )]
    [InlineData(7, 9, new[] { 7, 8, 9 } )]
    [InlineData(2, 8, new[] { 2, 3, 4, 5, 6, 7, 8 } )]
    [InlineData(3, 7, new[] { 3, 4, 5, 6, 7 } )]
    [InlineData(6, 6, new[] { 6 })]
    [InlineData(4, 6, new[] { 4, 5, 6 })]
    [InlineData(2, 6, new[] { 2, 3, 4, 5, 6 })]
    [InlineData(4, 8, new[] { 4, 5, 6, 7, 8 })]
    public void When_CreatingSectionAssignments_ShouldReturnSectionIds(int fromSectionId, int toSectionId, int[] expectedSectionIds)
    {
        var sectionAssignments = new SectionAssignments(fromSectionId, toSectionId);

        Assert.Equal(expectedSectionIds, sectionAssignments.SectionIds);
    }
}