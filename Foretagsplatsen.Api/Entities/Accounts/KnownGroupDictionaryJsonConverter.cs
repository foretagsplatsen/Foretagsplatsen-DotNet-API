using System;
using System.Collections.Generic;
using Foretagsplatsen.Api.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api.Entities.Accounts
{
    public class KnownGroupDictionaryJsonConverter : JsonConverter
    {
        #region Overrides of JsonConverter

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var subSetAccountGroupDictionary = (KnownGroupDictionary)value;

            writer.WriteStartObject();

            foreach (var groupKeyValuePair in subSetAccountGroupDictionary.GetAllKnowGroupsKeyValuePair())
            {
                WriteAccountGroup(writer, groupKeyValuePair);
            } 

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.ReadFrom(reader);

            var subSetAccountGroupDictionary = (KnownGroupDictionary)existingValue;

            foreach (var groupKeyValuePair in subSetAccountGroupDictionary.GetAllKnowGroupsKeyValuePair())
            {
                var knownGroupIdentitifer = groupKeyValuePair.Key;
                var knownGroup = (KnownGroup)groupKeyValuePair.Value;

                if (token[knownGroupIdentitifer] == null)
                {
                    continue; // Undefined known group, do nothing
                }

                // If the token has values, it means that it has a Children object with id's
                if (token[knownGroupIdentitifer].HasValues)
                {
                    if (token[knownGroupIdentitifer]["Id"] != null)
                    {
                        knownGroup.Id = token[knownGroupIdentitifer]["Id"].Value<string>();
                    }

                    if (token[knownGroupIdentitifer]["Name"] != null)
                    {
                        knownGroup.Name = token[knownGroupIdentitifer]["Name"].Value<string>();
                    }

                    var tokenChildren = token[knownGroupIdentitifer]["Children"];

                    if (tokenChildren != null)
                    {
                        foreach (JToken tokenChild in tokenChildren)
                        {
                            string id = tokenChild.Value<string>();

                            var accountGroup = subSetAccountGroupDictionary.ChartOfAccounts.GetChildById(id);
                            if (accountGroup == null)
                            {
                                throw new ApiException(string.Format("Could not find the referenced subset account groupd with id '{0}'", id));
                            }

                            knownGroup.Children.Add(accountGroup);
                        }
                    }

                    subSetAccountGroupDictionary.SetKnownGroup(knownGroupIdentitifer, knownGroup);
                }

                // If the token is a string, it is a direct referens to an account group
                if (token[knownGroupIdentitifer].Type == JTokenType.String)
                {
                    string id = token[knownGroupIdentitifer].Value<string>();

                    var accountGroup = subSetAccountGroupDictionary.ChartOfAccounts.GetChildById(id);
                    if (accountGroup == null)
                    {
                        throw new ApiException(string.Format("Could not find the referenced subset account groupd with id '{0}'", id));
                    }

                    subSetAccountGroupDictionary.SetKnownGroup(knownGroupIdentitifer, (IAccountGroup) accountGroup);
                }
            } 


            return subSetAccountGroupDictionary;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType != typeof(KnownGroupDictionary))
            {
                return false;
            }

            return true;
        }

        #endregion

        private void WriteAccountGroup(JsonWriter writer, KeyValuePair<string, IAccountGroup> groupKeyValuePair)
        {
            string groupIdentifier = groupKeyValuePair.Key;
            IAccountGroup group = groupKeyValuePair.Value;

            if (group.Type == AccountGroup.TypeName)
            {
                writer.WritePropertyName(groupIdentifier);
                writer.WriteValue(group.Id);
            }
            if (group.Type == KnownGroup.TypeName)
            {
                if (group.Children.Count == 0)
                {
                    return; // Do not write any json for "empty" known groups
                }

                writer.WritePropertyName(groupIdentifier);

                writer.WriteStartObject();

                if (!string.IsNullOrEmpty(group.Id))
                {
                    writer.WritePropertyName("Id");
                    writer.WriteValue(group.Name);
                }


                if (!string.IsNullOrEmpty(group.Name))
                {
                    writer.WritePropertyName("Name");
                    writer.WriteValue(group.Name);                    
                }

                if (group.Children.Count > 0)
                {
                    writer.WritePropertyName("Children");
                    writer.WriteStartArray();

                    foreach (var child in group.Children)
                    {
                        writer.WriteValue(child.Id);
                    }

                    writer.WriteEndArray();
                }

                writer.WriteEndObject();
            }
        }
    }
}