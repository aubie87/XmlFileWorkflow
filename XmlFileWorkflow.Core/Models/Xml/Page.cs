using System.Xml.Serialization;

namespace XmlFileWorkflow.Core.Models.Xml;

public class Page
{
    [XmlElement("Line")]
    public List<Line> Lines { get; set; } = new List<Line>();
}