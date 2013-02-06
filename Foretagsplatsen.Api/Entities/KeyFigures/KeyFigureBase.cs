using System;
using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    public abstract class KeyFigureBase<T> : IKeyFigure where T : IKeyFigureEntry
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public PeriodType PeriodType { get; set; }
        public string Type { get; set; }
        public string ValueType { get; set; }

        public List<T> Entries;
    }
}