// System.Management.Automation.Internal.AlternateDataStreamUtilities
using System.IO;

internal static void DeleteFileStream(string path, string streamName)
{
 if (path == null)
 {
  throw new ArgumentNullException("path");
 }
 if (streamName == null)
 {
  throw new ArgumentNullException("streamName");
 }
 string text = streamName.Trim();
 if (text.IndexOf(':') != 0)
 {
  text = ":" + text;
 }
 File.Delete(path + text);
}