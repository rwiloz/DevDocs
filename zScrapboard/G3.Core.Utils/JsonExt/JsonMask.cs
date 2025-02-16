using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace G3.Core.Utils.JsonExt
{
    //https://github.com/ThiagoBarradas/jsonmasking/blob/master/JsonMasking/JsonMasking.cs
    public static class JsonMask
    {
        /// <summary>
        /// Mask fields
        /// </summary>
        /// <param name="json">json to mask properties</param>
        /// <param name="blackListPath">insensitive property array</param>
        /// <param name="maskValues">values regex array</param>
        /// <param name="mask">mask to replace property value</param>
        /// <returns></returns>
        public static string JsonMaskFields(this string json, string[] blackListPath, string[] maskValues, string mask)
        {
            if (string.IsNullOrWhiteSpace(json) == true)
            {
                throw new ArgumentNullException(nameof(json));
            }

            if (blackListPath == null)
            {
                throw new ArgumentNullException(nameof(blackListPath));
            }

            if (maskValues == null)
            {
                throw new ArgumentNullException(nameof(maskValues));
            }

            var jsonObject = (JObject) JsonConvert.DeserializeObject(json);
            MaskFieldsFromJToken(jsonObject, blackListPath, maskValues, mask);

            return jsonObject?.ToString(Formatting.None);
        }

        /// <summary>
        /// Mask fields from JToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="blackListPath">insensitive property array</param>
        /// <param name="maskValues">values regex array</param>
        /// <param name="mask"></param>
        private static void MaskFieldsFromJToken(JToken token, string[] blackListPath, string[] maskValues, string mask)
            {
                JContainer container = token as JContainer;
                if (container == null)
                {
                    return; // abort recursive
                }

                List<JToken> removeList = new List<JToken>();
                foreach (JToken jtoken in container.Children())
                {
                    if (jtoken is JProperty prop)
                    {
                        if (prop.Value.Type != JTokenType.Array && prop.Value.Type != JTokenType.Object)
                        {
                            var matching = blackListPath.Any(item => Regex.IsMatch(prop.Path, item,
                                               RegexOptions.IgnoreCase |
                                               RegexOptions.CultureInvariant))
                                           ||
                                           maskValues.Any(item =>
                                               Regex.IsMatch(prop.Value.ToString(), item,
                                                   RegexOptions.IgnoreCase |
                                                   RegexOptions.CultureInvariant));

                            if (matching)
                            {
                                removeList.Add(jtoken);
                            }
                        }
                    }

                    // call recursive 
                    MaskFieldsFromJToken(jtoken, blackListPath, maskValues, mask);
                }

                // replace 
                foreach (JToken el in removeList)
                {
                    var prop = (JProperty)el;
                    prop.Value = mask;
                }
            }

            //private static string WildCardToRegular(string value)
            //{
            //    return "^" + Regex.Escape(value).Replace("\\*", ".*") + "$";
            //}
        }
    }
