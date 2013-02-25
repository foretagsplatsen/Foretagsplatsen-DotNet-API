using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    /// <summary>
    /// Holds information about different presets settings. For example, the list of key figures showed under "My key figures" option.
    /// </summary>
    public class KeyFigurePreset
    {
        public const string equityStructurePresetId = "EquityStructure";
        public const string incomeCostStructurePresetId = "IncomeCostStructure";
        public const string myKeyFiguresPresetId = "MyKeyFigures";
        public const string overviewPresetId = "Overview";
        public const string profitStructurePresetId = "ProfitStructure";
        public const string visibleKeyFiguresPresetId = "VisibleKeyFigures";
        
        /// <summary>
        /// The id of the preset. Can be one of following:
        /// * EquityStructure
        /// * IncomeCostStructure
        /// * MyKeyFigures
        /// * Overview
        /// * ProfitStructure
        /// * VisibleKeyFigures
        /// </summary>
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        /// <summary>
        /// A list of key figure types that the preset contains. See the overview documentation for the different key figure types.
        /// </summary>
        public List<string> keyFigureTypes { get; set; }
    }
}