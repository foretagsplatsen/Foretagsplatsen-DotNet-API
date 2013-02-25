using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    /// <summary>
    /// Holds information about a key figure and the calculated results.
    /// </summary>
    public class KeyFigureResult
    {
        public KeyFigure keyFigure { get; set; }
        public List<KeyFigureValue> keyFigureValues { get; set; }
    }
}