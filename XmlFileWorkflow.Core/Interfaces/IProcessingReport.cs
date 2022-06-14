namespace XmlFileWorkflow.Core.Interfaces;

public interface IProcessingReport
{
    void Finish();

    string GetSummary();
}