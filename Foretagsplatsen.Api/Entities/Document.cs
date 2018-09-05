using System;
using System.Collections.Generic;

namespace Foretagsplatsen.Api.Entities
{
    /// <summary>
    /// Represents a document in the document archive. It can be a folder or a file
    /// </summary>
    public class Document
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public List<Document> Children { get; set; }

        public Document()
        {
            Children = new List<Document>();
        }
    }
}
