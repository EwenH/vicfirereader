using NoeticTools.PlugIns;


namespace VicFireReader.CFA.Incidents.View
{
    public interface IIncidentsViewController
    {
        void Show(IPluginHostServices services);
        void Close();
    }
}