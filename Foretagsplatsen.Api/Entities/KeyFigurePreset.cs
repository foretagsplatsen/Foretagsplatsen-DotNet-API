using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities
{
    public class KeyFigurePreset
    {
        public static string EquityStructureId = "EquityStructure";
        public static string IncomeCostStructureId = "IncomeCostStructure";
        public static string MyKeyFiguresId = "MyKeyFigures";
        public static string OverviewId = "Overview";
        public static string ProfitStructureId = "ProfitStructure";
        public static string VisibleKeyFiguresId = "VisibleKeyFigures";

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> KeyFigureTypes { get; set; }
    }
}
