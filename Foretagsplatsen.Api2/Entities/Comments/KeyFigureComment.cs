// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Comments
{
    /// <summary>
    /// A comment on a key figure during a certain period.
    /// </summary>
    public class KeyFigureComment : Comment
    {
        public const string keyFigureCommentTypeName = "KeyFigureComment";

        /// <summary>
        /// The type of comment, is "KeyFigureComment" for key figure comments
        /// </summary>
        public override string type { get { return keyFigureCommentTypeName; } }

        /// <summary>
        /// The type of the key figure the comment applies to. See the overview documentation for more information.
        /// </summary>
        public string keyFigureType { get; set; }
    }
}