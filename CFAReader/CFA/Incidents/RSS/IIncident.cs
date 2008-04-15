using CFAReader.CFA.Data;


namespace CFAReader.CFA.Incidents.RSS
{
	public interface IIncident
	{
		CFADataSet.IncidentsRow Update(CFADataSet.IncidentsDataTable incidents);
	}
}