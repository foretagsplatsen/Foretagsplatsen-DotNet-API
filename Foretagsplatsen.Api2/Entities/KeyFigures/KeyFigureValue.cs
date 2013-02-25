// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    /// <summary>
    /// Represents the value of a key figure during a period of time.
    /// </summary>
    public class KeyFigureValue
    {
        /// <summary>
        /// Can be null if it doesn't exist, for example if there is a division by zero or all data doesn't exist.
        /// </summary>
        public decimal? value { get; set; }
        public Period period { get; set; }
    }
}