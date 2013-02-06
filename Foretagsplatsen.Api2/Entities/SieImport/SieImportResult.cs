using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.SieImport
{
    public class SieImportResult
    {
        public bool success { get; set; }
        public IEnumerable<SieImportInfo> errors { get; set; }
        public IEnumerable<SieImportInfo> warnings { get; set; }
        
        public bool hasErrors
        {
            get
            {
                return errors.Any();
            }
        }

        public bool hasWarnings
        {
            get
            {
                return warnings.Any();
            }
        }
    }
}
// ReSharper restore InconsistentNaming