using System;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Every key figure entry must implement this.
    /// It is used for setting the start and end of key figures' span over a period
    /// </summary>
    public interface IKeyFigureEntry
    {
        DateTime Start { get; set; }
        DateTime End { get; set; }
        float Value { get; set; }
    }
}