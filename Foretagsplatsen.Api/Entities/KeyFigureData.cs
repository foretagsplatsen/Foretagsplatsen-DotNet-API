namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Result from Api-client for key figure data
    /// </summary>
    public class KeyFigureData
    {
        public string KeyFigureInfoId { get; set; }
        public Period Period { get; set; }
        public decimal Value { get; set; }
    }
}