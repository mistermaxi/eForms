using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace eForms.Domain.Resources
{
    public class ResourceHelper
    {
        #region Embedded Resources Tools

        public static Stream GetStaticResourceStream(string path) => Assembly.GetExecutingAssembly().GetManifestResourceStream(path);

        public static byte[] GetStaticResource(string path)
        {
            using (Stream stream = GetStaticResourceStream(path))
            {
                int bytes = (int)stream.Length;
                var content = new byte[bytes];
                stream.Read(content, 0, bytes);
                return content;
            }
        }

        public static string GetStaticTextResource(string path)
        {
            using (Stream stream = GetStaticResourceStream(path))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion
    }
}
