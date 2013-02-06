using System;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    public class KeyFigureEntryBase : IKeyFigureEntry
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float? Value { get; set; }
    }
}