using System;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Every Key figure must implement this interface
    /// </summary>
    public interface IKeyFigure
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        PeriodType PeriodType { get; set; }
        string Type { get; set; }
        string ValueType { get; set; }
    }
}