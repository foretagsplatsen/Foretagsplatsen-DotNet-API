// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.Comments
{
    public class KeyFigureComment : Comment
    {
        public const string keyFigureCommentTypeName = "KeyFigureComment";

        override public string type { get { return keyFigureCommentTypeName; } }
        public string keyFigureType { get; set; }
    }
}
// ReSharper restore InconsistentNaming