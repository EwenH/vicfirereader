using System.Xml;


namespace VicFireReader.CFA.Incidents.RSS
{
	public interface IIncidentFactory
	{
		IIncident Create(XmlNode incidentNode);
	}
}