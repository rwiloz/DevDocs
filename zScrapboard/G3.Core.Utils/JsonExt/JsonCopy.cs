using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.JsonExt
{
    public static class JsonCopy
    {
        public static TDest Copy<TDest>(object src)
            where TDest :  class
        {
            var serlized = JsonConvert.SerializeObject(src, JsonUtils.JsonSettings);
            return JsonConvert.DeserializeObject<TDest>(serlized, JsonUtils.JsonSettings);
        }
    }
}
