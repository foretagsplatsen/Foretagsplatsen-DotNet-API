using System.IO;
using System.Net;

namespace Foretagsplatsen.Api2
{
    public static class WebResponseExtension
    {
        public static string ReadBody(this WebResponse webResponse)
        {
            using (var responseStream = webResponse.GetResponseStream())
            {
                if (responseStream == null)
                {
                    return null;
                }
                if (responseStream.CanSeek)
                {
                    responseStream.Seek(0, SeekOrigin.Begin);
                }
                using (var reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}