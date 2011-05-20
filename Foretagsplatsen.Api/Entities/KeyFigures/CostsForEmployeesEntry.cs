using System;

namespace Foretagsplatsen.Api.Entities.KeyFigures
{
    public class CostsForEmployeesEntry : IKeyFigureEntry
    {
        #region Implementation of IKeyFigureEntry

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public float Value { get; set; }

        #endregion

        public float Income { get; set; }
        public float EmployeeBenefitsAndExpense { get; set; }
    }
}