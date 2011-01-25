using System.IO;
using System.Net;

namespace Foretagsplatsen.Api
{
    public static class WebResponseExtension
    {
        public static string ReadBody(this WebResponse webResponse)
        {
            using (Stream responseStream = webResponse.GetResponseStream())
            {
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