using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Newtonsoft.Json;

namespace G3.Core.Utils.JsonExt
{
    /// <summary>
    /// This json converter allows WebAPI to construct Interfaces without needing to define a concrete class.
    /// </summary>
    public class InterfaceJsonConverter : JsonConverter
    {
        private readonly IMapper mapper;
        private readonly IEnumerable<Type> interfaces;

        public InterfaceJsonConverter(IEnumerable<Type> interfaces)
        {
            this.interfaces = interfaces;

            // Create a Mapping for each interface, which generates an internal proxy type for each.
            var cfg = new MapperConfigurationExpression();
            foreach (var i in interfaces)
            {
                cfg.CreateMap(typeof(ExpandoObject), i);
            }

            var mapperConfig = new MapperConfiguration(cfg);
            mapper = new Mapper(mapperConfig);
        }


        public override bool CanConvert(Type objectType)
        {
            return (interfaces.Contains(objectType));
        }
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }
        public override bool CanWrite
        {
            get
            {
                // We arn't overriding the Write Json functionality. That works fine with interfaces.
                return false;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // We arn't overriding the Write Json functionality. That works fine with interfaces.
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // We are using AutoMapper here purely to create a dynamic type. It will have null values for all the properties.
            var returnObj = mapper.Map(new ExpandoObject(), typeof(ExpandoObject), objectType);

            // We then use Json.Net to populate all those properties.
            serializer.Populate(reader, returnObj);

            return returnObj;

        }
    }

}
