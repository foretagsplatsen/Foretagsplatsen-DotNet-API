using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    public class KeyFigurePreset
    {
        public const string equityStructurePresetId = "EquityStructure";
        public const string incomeCostStructurePresetId = "IncomeCostStructure";
        public const string myKeyFiguresPresetId = "MyKeyFigures";
        public const string overviewPresetId = "Overview";
        public const string profitStructurePresetId = "ProfitStructure";
        public const string visibleKeyFiguresPresetId = "VisibleKeyFigures";

        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> keyFigureTypes { get; set; }
    }
}