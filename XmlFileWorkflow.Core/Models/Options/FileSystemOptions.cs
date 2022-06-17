using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlFileWorkflow.Core.Models.Options;
public class FileSystemOptions
{
    public string Extension { get; set; } = string.Empty;
    public string Folder { get; set; } = string.Empty;
    public string Rootname { get; set; } = string.Empty;
}
