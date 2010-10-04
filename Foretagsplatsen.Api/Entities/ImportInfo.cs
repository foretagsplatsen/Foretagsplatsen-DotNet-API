namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Wrning/Error in SIE-import <see cref="ImportSieResult"/>.  
    /// </summary>
    public class ImportInfo
    {
        public string LineNo;
        public string LinePos;
        public string Label;
        public string Line;
        public string Explanation;
    }
}