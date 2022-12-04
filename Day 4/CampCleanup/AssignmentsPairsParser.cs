namespace CampCleanup;
public class AssignmentsPairsParser
{
	public AssignmentsPairsParser(string line)
	{
		var pairs = line.Split(',');
		
		var firstSectionAssignments = ParseSectionAssignment(pairs[0]);
		var secondSectionAssignments = ParseSectionAssignment(pairs[1]);

		Pair = new SectionAssignmentsPair(firstSectionAssignments, secondSectionAssignments);
	}

	public SectionAssignmentsPair Pair { get; set; }

	private SectionAssignments ParseSectionAssignment(string sectionAssignmentsIds)
	{
        var fromTo = sectionAssignmentsIds.Split('-');
		return new SectionAssignments(int.Parse(fromTo[0]), int.Parse(fromTo[1]));
    }
}
