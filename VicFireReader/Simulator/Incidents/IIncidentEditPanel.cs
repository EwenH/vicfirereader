using System;


namespace VicFireReader.Simulator.Incidents
{
	public interface IIncidentEditPanel
	{
		void SetGuid(string guid);
		void SetName(string name);
		void SetLocation(string location);
		void SetType(string type);
		void SetStatus(string status);
		void SetSize(string size);
		void SetPublicationTime(DateTime time);
		void SetUpdateTime(DateTime time);
		void SetRegion(short region);
		void SetVehicles(short appliances);
	}
}