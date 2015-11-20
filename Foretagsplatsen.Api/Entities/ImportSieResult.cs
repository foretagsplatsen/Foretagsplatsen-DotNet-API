using System;
using System.Collections.Generic;
using System.Linq;

namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Result from <see cref="ApiClient"/> on SIE-import.  
    /// </summary>
    public class ImportSieResult
    {
        public bool Success { get; set; }
        public List<ImportInfo> Errors { get; set; }
        public List<ImportInfo> Warnings { get; set; }
        
        public bool HasErrors
        {
            get
            {
                return Errors.Any();
            }
        }

        public bool HasWarnings
        {
            get
            {
                return Warnings.Any();
            }
        }

        public string FormatErrors()
        {
            return "Errors:\n " + String.Join(Environment.NewLine, Errors.Select(e => e.Explanation).ToArray());
        }

        public string FormatWarnings()
        {
            return "Warnings:\n " + String.Join(Environment.NewLine, Warnings.Select(e => e.Explanation).ToArray());
        }
    }
}