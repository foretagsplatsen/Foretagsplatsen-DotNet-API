using System;

namespace Foretagsplatsen.Api.Entities.Comments
{
    public interface IComment
    {
        string Id { get; set; }
        string Message { get; set; }
        DateTime Created { get; set; }
        DateTime LastModified { get; set; }
        string Author { get; set; }
        Period Period { get; set; }
        string Type { get; }
    }
}