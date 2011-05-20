using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FluentMigrator
{
    public interface ISourceControl
    {
        string BasePath { get; set; }
        string GetTextFile(string path, int revision);
    }
}
