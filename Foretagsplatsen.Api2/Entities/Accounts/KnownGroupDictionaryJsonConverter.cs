using System;
using System.Collections.Generic;
using Foretagsplatsen.Api2.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Foretagsplatsen.Api2.Entities.Accounts
{
    public class KnownGroupDictionaryJsonConverter : JsonConverter
    {
        #region Overrides of JsonConverter

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var knownGroupDictionary = (KnownGroupDictionary)value;

            writer.WriteStartObject();

            foreach (var groupKeyValuePair in knownGroupDictionary.getAllKnowGroupsKeyValuePair())
            {
                WriteAccountGroup(writer, groupKeyValuePair);
            } 

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.ReadFrom(reader);

            var knownGroupDictionary = (KnownGroupDictionary)existingValue;

            foreach (var groupKeyValuePair in knownGroupDictionary.getAllKnowGroupsKeyValuePair())
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
                    if (token[knownGroupIdentitifer]["id"] != null)
                    {
                        knownGroup.id = token[knownGroupIdentitifer]["id"].Value<string>();
                    }

                    if (token[knownGroupIdentitifer]["name"] != null)
                    {
                        knownGroup.name = token[knownGroupIdentitifer]["name"].Value<string>();
                    }

                    var tokenChildren = token[knownGroupIdentitifer]["children"];

                    if (tokenChildren != null)
                    {
                        foreach (var tokenChild in tokenChildren)
                        {
                            var id = tokenChild.Value<string>();

                            var accountGroup = knownGroupDictionary.chartOfAccounts.getChildById(id);
                            if (accountGroup == null)
                            {
                                throw new ApiException(string.Format("Could not find the referenced subset account groupd with id '{0}'", id));
                            }

                            knownGroup.children.Add(accountGroup);
                        }
                    }

                    knownGroupDictionary.setKnownGroup(knownGroupIdentitifer, knownGroup);
                }

                // If the token is a string, it is a direct referens to an account group
                if (token[knownGroupIdentitifer].Type == JTokenType.String)
                {
                    var id = token[knownGroupIdentitifer].Value<string>();

                    var accountGroup = knownGroupDictionary.chartOfAccounts.getChildById(id);
                    if (accountGroup == null)
                    {
                        throw new ApiException(string.Format("Could not find the referenced subset account groupd with id '{0}'", id));
                    }

                    knownGroupDictionary.setKnownGroup(knownGroupIdentitifer, (IAccountGroup) accountGroup);
                }
            } 


            return knownGroupDictionary;
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
            var groupIdentifier = groupKeyValuePair.Key;
            var group = groupKeyValuePair.Value;

            if (group.type == AccountGroup.typeName)
            {
                writer.WritePropertyName(groupIdentifier);
                writer.WriteValue(group.id);
            }
            if (group.type == KnownGroup.typeName)
            {
                if (group.children.Count == 0)
                {
                    return; // Do not write any json for "empty" known groups
                }

                writer.WritePropertyName(groupIdentifier);

                writer.WriteStartObject();

                if (!string.IsNullOrEmpty(group.id))
                {
                    writer.WritePropertyName("id");
                    writer.WriteValue(group.id);
                }


                if (!string.IsNullOrEmpty(group.name))
                {
                    writer.WritePropertyName("name");
                    writer.WriteValue(group.name);                    
                }

                if (group.children.Count > 0)
                {
                    writer.WritePropertyName("children");
                    writer.WriteStartArray();

                    foreach (var child in group.children)
                    {
                        writer.WriteValue(child.id);
                    }

                    writer.WriteEndArray();
                }

                writer.WriteEndObject();
            }
        }
    }
}