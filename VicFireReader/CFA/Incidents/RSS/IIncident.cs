using VicFireReader.CFA.Data;


namespace VicFireReader.CFA.Incidents.RSS
{
	public interface IIncident
	{
		CFADataSet.IncidentsRow Update(CFADataSet.IncidentsDataTable incidents);
	}
}