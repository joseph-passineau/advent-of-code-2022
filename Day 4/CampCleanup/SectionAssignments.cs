using System.Collections.ObjectModel;

namespace CampCleanup;
public class SectionAssignments
{
	public SectionAssignments(int fromSectionId, int toSectionId)
	{
        var sectionIds = new List<int>();
		var sectionIdsCount = (toSectionId - fromSectionId) +1;

        sectionIds.AddRange(Enumerable.Range(fromSectionId, sectionIdsCount));
		SectionIds = new ReadOnlyCollection<int>(sectionIds);
    }

	public ReadOnlyCollection<int> SectionIds { get; }
}
