using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;
using System.IO;

namespace FluentMigrator.SourceControl
{
    public class Svn : ISourceControl
    {
        #region ISourceControl Members

        public string BasePath { get; set; }

        public string GetTextFile(string path, int revision)
        {
            using (SvnClient client = new SvnClient())
            using (var stream = new MemoryStream())
            {
                // get the svn repo info
                Uri repos = new Uri(this.BasePath);
                client.Write(new SvnUriTarget(
                        string.Format("{0}/{1}", this.BasePath, path), revision), stream);
                stream.Position = 0;
                // write the target to text 
                StreamReader reader = new StreamReader(stream);
                string text = reader.ReadToEnd();
                stream.Position = 0;
                return text;
            }
        }

        #endregion
    }
}
