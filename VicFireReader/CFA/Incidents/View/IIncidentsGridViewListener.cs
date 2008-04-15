using CFAReader.CFA.Data;


namespace CFAReader.CFA.Incidents.View
{
	public interface IIncidentsGridViewListener
	{
		void OnDoubleClick(CFADataSet.IncidentsRow row);
	}
}