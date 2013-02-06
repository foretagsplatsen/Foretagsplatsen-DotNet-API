using System.Collections.Generic;

// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.KeyFigures
{
    public enum KeyFigurePresetId
    {
        EquityStructure, 
        IncomeCostStructure, 
        MyKeyFigures, 
        Overview, 
        ProfitStructure, 
        VisibleKeyFigures
    }

    public class KeyFigurePreset
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> keyFigureTypes { get; set; }
    }
}
// ReSharper restore InconsistentNaming