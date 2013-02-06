using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    public class KeyFigureResult
    {
        public KeyFigure keyFigure { get; set; }
        public List<KeyFigureValue> keyFigureValues { get; set; }
    }
}
// ReSharper restore InconsistentNaming