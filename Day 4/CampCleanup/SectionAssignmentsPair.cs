namespace CampCleanup;
public class SectionAssignmentsPair
{
    public SectionAssignmentsPair(SectionAssignments firstSectionAssignments, SectionAssignments secondSectionAssignments)
	{
        FirstSectionAssignments = firstSectionAssignments;
        SecondSectionAssignments = secondSectionAssignments;
    }

    public SectionAssignments FirstSectionAssignments { get; }

    public SectionAssignments SecondSectionAssignments { get; }

    public bool IsFullyContained => !SmallestSectionAssignments.SectionIds.Except(BiggestSectionAssignments.SectionIds).Any();

    public bool IsOverlapped => FirstSectionAssignments.SectionIds.Intersect(SecondSectionAssignments.SectionIds).Any();

    public SectionAssignments SmallestSectionAssignments => FirstSectionAssignments.SectionIds.Count <= SecondSectionAssignments.SectionIds.Count ? FirstSectionAssignments : SecondSectionAssignments;
    
    public SectionAssignments BiggestSectionAssignments => SmallestSectionAssignments == FirstSectionAssignments ? SecondSectionAssignments : FirstSectionAssignments;
}
