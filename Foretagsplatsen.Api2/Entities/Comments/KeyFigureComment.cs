// ReSharper disable InconsistentNaming
namespace Foretagsplatsen.Api2.Entities.Comments
{
    public class KeyFigureComment : Comment
    {
        public const string KeyFigureCommentTypeName = "KeyFigureComment";

        override public string type { get { return KeyFigureCommentTypeName; } }
        public string keyFigureType { get; set; }
    }
}
// ReSharper restore InconsistentNaming