using System;

namespace Foretagsplatsen.Api.Entities.Comments
{
    public class KeyFigureComment : IComment
    {
        public const string KeyFigureCommentTypeName = "KeyFigureComment";

        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string Author { get; set; }
        public Period Period { get; set; }
        public string Type { get { return KeyFigureCommentTypeName; } }

        public string KeyFigureType { get; set; }

        public KeyFigureComment()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}