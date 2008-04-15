using System.Xml;


namespace CFAReader.CFA.Incidents.RSS
{
	public interface IIncidentFactory
	{
		IIncident Create(XmlNode incidentNode);
	}
}