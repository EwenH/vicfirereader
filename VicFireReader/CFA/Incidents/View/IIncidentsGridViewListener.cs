using VicFireReader.CFA.Data;


namespace VicFireReader.CFA.Incidents.View
{
	public interface IIncidentsGridViewListener
	{
		void OnDoubleClick(CFADataSet.IncidentsRow row);
	}
}