using System.Xml.Serialization;

namespace XmlFileWorkflow.Core.Models.Xml;

public class Header
{
    public string InstitutionCode { get; init; } = string.Empty;
    public string InstitutionName { get; set; } = string.Empty;

    [XmlElement(DataType = "date")]
    public DateTime RunDate { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public int StatementCount { get; init; } = 0;
    public string GeneratedByApp { get; set; } = "XmlFileWorkflow";
    public string GeneratedByVersion { get; set; } = "1.0.0.1";
}