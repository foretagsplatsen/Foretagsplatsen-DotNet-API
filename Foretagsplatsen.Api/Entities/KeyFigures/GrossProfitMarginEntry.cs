using System;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    /// <summary>
    /// Gross profit margin for a specific period
    /// </summary>
    public class GrossProfitMarginEntry : IKeyFigureEntry
    {
        #region Implementation of IKeyFigureEntry

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Value { get; set; }

        #endregion

        public float NetSale { get; set; }
        public float GoodsForResale { get; set; }
        public float Income { get; set; }
    }
}