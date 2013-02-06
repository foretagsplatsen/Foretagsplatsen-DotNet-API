using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    public class ChartOfAccountChildJsonConverter : JsonConverter
    {
        #region Overrides of JsonConverter

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(JsonConvert.SerializeObject(value));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenArray = JToken.ReadFrom(reader);

            var children = new List<IChartOfAccountChild>();

            foreach (var token in tokenArray)
            {
                string type = token["Type"].Value<string>();

                if (type == AccountGroup.TypeName)
                {
                    var accountGroup = JsonConvert.DeserializeObject<AccountGroup>(token.ToString());
                    children.Add(accountGroup);
                }

                if (type == AccountIntervalGroup.TypeName)
                {
                    var accountIntervalGroup = JsonConvert.DeserializeObject<AccountIntervalGroup>(token.ToString());
                    children.Add(accountIntervalGroup);
                }
            }

            return children;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType != typeof(List<IChartOfAccountChild>))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}