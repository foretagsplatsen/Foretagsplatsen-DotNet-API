using System;
using System.Collections.Generic;
using System.Linq;
using Foretagsplatsen.Api.Entities;
using Foretagsplatsen.Api.Entities.Comments;
using Foretagsplatsen.Api.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Resources
{
    /// <summary>
    /// Comment REST resource:
    /// https://web.foretagsplatsen.se/Api/Company/{businessIdentityCode}/Comment/{id}
    /// </summary>
    public class CommentResource
    {
        private readonly ApiClient client;
        private readonly string businessIdentityCode;

        public CommentResource(ApiClient client, CompanyInfo company)
            : this(client, company.BusinessIdentityCode)
        {
        }

        public CommentResource(ApiClient client, string businessIdentityCode)
        {
            this.client = client;
            this.businessIdentityCode = businessIdentityCode;
        }


        /// <summary>
        /// Url for the comment collection resource
        /// </summary>
        /// <returns>Url.</returns>
        public string GetUrl()
        {
            const string urlFormat = "{0}/Api/Company/{1}/Comment/";
            return string.Format(urlFormat, client.BaseUrl, this.businessIdentityCode);
        }

        /// <summary>
        /// Url for the agency user resource
        /// </summary>
        /// <returns>Url.</returns>
        public string GetUrlWithCommentId(string commentId)
        {
            const string urlFormat = "{0}/Api/Company/{1}/Comment/{2}";
            return string.Format(urlFormat, client.BaseUrl, this.businessIdentityCode, commentId);
        }

        /// <summary>
        /// Get a list of all comments for the company
        /// </summary>
        /// <returns>List of comments</returns>
        public List<IComment> List()
        {
            string url = GetUrl();

            // Execute GET
            string json = client.Get(url);

            // Parse comments
            JArray comments = JArray.Parse(json);

            return comments.Select(CreateComment).ToList();
        }

        /// <summary>
        /// Get a comment
        /// </summary>
        /// <param name="id">Id of the comment</param>
        /// <returns>A comment</returns>
        public IComment Get(string id)
        {
            string url = GetUrlWithCommentId(id);

            // Execute GET
            string body = client.Get(url);

            // Parse comment
            var obj = JObject.Parse(body);

            return CreateComment(obj);
        }


        /// <summary>
        /// Creates a comment
        /// 
        /// Notes:
        /// * All properties in the comment is mandatory except Created and LastModified
        /// * Created and LastModified date will be set by the server
        /// </summary>
        /// <param name="comment">Comment to create</param>
        /// <returns>The newly created comment with updated create date and id (if not supplied)</returns>
        public T Create<T>(T comment) where T : IComment, new()
        {
            if (string.IsNullOrEmpty(comment.Id))
            {
                throw new ApiException("The comment must have an id", ApiErrorType.InvalidArguments);
            }

            string url = GetUrlWithCommentId(comment.Id);

            var json = JsonConvert.SerializeObject(comment);

            return client.Post<T>(url, json);
        }

        /// <summary>
        /// Creates many comments in one request
        /// 
        /// Notes:
        /// * All properties in the comment is mandatory except Created, LastModified and Id
        /// * Created and LastModified date will be set by the server
        /// * Id will be set by the server if null or empty, if not empty it must be uniqe
        /// </summary>
        /// <param name="comments">List of comments to create</param>
        /// <returns>The newly created list of comments with updated create date</returns>
        public List<IComment> Create(List<IComment> comments)
        {
            string url = GetUrl();

            var json = JsonConvert.SerializeObject(comments);

            string jsonResponse = client.Post(url, json);

            // Parse comments
            JArray commentsJArray = JArray.Parse(jsonResponse);

            return commentsJArray.Select(CreateComment).ToList();
        }


        /// <summary>
        /// Creates or updates a comment
        /// 
        /// Notes:
        /// * If the comment doesn't exists on the server, see Create()
        /// * Id must match the comment to update
        /// * All properties (except Id) are optional
        /// * Created and LastModified property cannot be updated
        /// </summary>
        /// <param name="comment">Comment to update</param>
        /// <returns>The newly created or uppdated comment</returns>
        public T Update<T>(T comment) where T : IComment, new()
        {
            if (string.IsNullOrEmpty(comment.Id))
            {
                throw new ApiException("The comment must have an id", ApiErrorType.InvalidArguments);
            }

            string url = GetUrlWithCommentId(comment.Id);

            var json = JsonConvert.SerializeObject(comment);

            return client.Put<T>(url, json);
        }

        /// <summary>
        /// Creates or updates many comments in one request
        /// 
        /// Notes:
        /// * If the comment doesn't exists on the server, see Create()
        /// * Id must match the comment to update
        /// * All properties (except Id) are optional
        /// * Created and LastModified property cannot be updated
        /// </summary>
        /// <param name="comments">List of comments to create</param>
        /// <returns>The newly created or updated list of comments</returns>
        public List<IComment> Update(List<IComment> comments) 
        {
            string url = GetUrl();

            var json = JsonConvert.SerializeObject(comments);

            string jsonResponse = client.Put(url, json);

            // Parse comments
            JArray commentsJArray = JArray.Parse(jsonResponse);

            return commentsJArray.Select(CreateComment).ToList();
        }


        /// <summary>
        /// Deletes a comment
        /// </summary>
        /// <param name="id">Id of the comment to delete</param>
        public void Delete(string id)
        {
            string url = GetUrlWithCommentId(id);

            client.Delete(url);
        }


        /// <summary>
        /// Deletes all comments
        /// </summary>
        public void DeleteAll()
        {
            string url = GetUrl();

            client.Delete(url);
        }

        /// <summary>
        /// Deletes all comments of specified type
        /// </summary>
        /// <param name="commentType">type of the comments to delete</param>
        public void DeleteAll(string commentType)
        {
            string url = GetUrl();

            client.Delete(url, new { type = commentType});
        }


        /// <summary>
        /// Create and return a key figure from a JToken json data
        /// </summary>
        private static IComment CreateComment(JToken obj)
        {
            var type = obj["Type"].Value<string>();

            try
            {
                switch (type)
                {
                    case KeyFigureComment.KeyFigureCommentTypeName:
                        return JsonConvert.DeserializeObject<KeyFigureComment>(obj.ToString());
                    default:
                        throw new ApiException("Comment type not implemented.");
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Could not parse comment type: {0}", type), ex.InnerException);
            }
        }

    }
}