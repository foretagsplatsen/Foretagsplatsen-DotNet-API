using System;
using System.Collections.Generic;
using System.Linq;
using Foretagsplatsen.Api2.Entities;
using Foretagsplatsen.Api2.Entities.Comments;
using Foretagsplatsen.Api2.Entities.Company;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Resources
{
    public class CompanyCommentResource
    {
        private readonly ApiClient client;
        private readonly string companyId;

        public CompanyCommentResource(ApiClient client, CompanyInfo company) : this(client, company.id)
        {
        }

        public CompanyCommentResource(ApiClient client, string companyId)
        {
            this.client = client;
            this.companyId = companyId;
        }

        public List<Comment> List()
        {
            var url = GetUrl();
            var json = client.Get(url);

            var jsonComments = JArray.Parse(json);

            return jsonComments.Select(CreateComment).ToList();
        }

        public Comment Get(Comment comment)
        {
            return Get(comment.id);
        }

        public Comment Get(string commentId) 
        {
            var url = GetUrl(commentId);
            var json = client.Get(url);
            var jsonComment = JObject.Parse(json);
            return CreateComment(jsonComment);
        }

        public Comment Create(Comment comment)
        {
            var url = GetUrl();
            var json = client.Post(url, JObject.FromObject(comment).ToString());
            var jsonComment = JObject.Parse(json);
            return CreateComment(jsonComment);

        }

        public Comment Update(Comment comment)
        {
            var url = GetUrl();
            var json = client.Put(url, JObject.FromObject(comment).ToString());
            var jsonComment = JObject.Parse(json);
            return CreateComment(jsonComment);
        }

        public void Delete(Comment comment)
        {
            Delete(comment.id);
        }

        public void Delete(string commentId)
        {
            var url = GetUrl(commentId);
            client.Delete(url);
        }

        #region Private methods

        private string GetUrl(string commentId = "")
        {
            const string urlFormat = "{0}/Api/v2/Company/{1}/Comment/{2}";
            return string.Format(urlFormat, client.BaseUrl, companyId, commentId);
        }

        private Comment CreateComment(JToken obj)
        {

            if (obj["type"] == null)
            {
                throw new ApiException("Invalid json. No comment type found.", ApiErrorType.Unknown);
            }

            var type = obj["type"].Value<string>();

            try
            {
                switch (type)
                {
                    case KeyFigureComment.keyFigureCommentTypeName:
                        return JsonConvert.DeserializeObject<KeyFigureComment>(obj.ToString());
                    default:
                        throw new ApiException("Comment type not implemented.", ApiErrorType.Unknown);
                }
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Could not parse comment type: {0}", type), ApiErrorType.Unknown, ex.InnerException);
            }

        }

        #endregion
    }
}
