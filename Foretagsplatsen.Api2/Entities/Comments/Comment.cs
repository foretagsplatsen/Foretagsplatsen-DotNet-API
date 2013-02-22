using System;

// ReSharper disable InconsistentNaming

namespace Foretagsplatsen.Api2.Entities.Comments
{
    public abstract class Comment
    {
        protected Comment()
        {
            id = Guid.NewGuid().ToString();
        }

        public string id { get; set; }
        public string message { get; set; }
        public DateTime created { get; set; }
        public DateTime lastModified { get; set; }
        public string author { get; set; }
        public Period period { get; set; }
        public abstract string type { get; }

        public bool IsKeyFigureComment { get { return type == KeyFigureComment.keyFigureCommentTypeName; } }
    }
}