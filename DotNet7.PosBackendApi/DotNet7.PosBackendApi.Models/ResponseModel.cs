﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotNet7.PosBackendApi.Models
{
    public class ResponseModel
    {
        public object ReturnCommand(bool isSuccess, string message,
            EnumPos enumPos, object? item = null)
        {
            JObject jsonObject = new JObject(
                new JProperty("message", message),
                new JProperty("isSuccess", isSuccess),
                new JProperty("data", item is null ? item :
                    new JObject(
                        new JProperty(enumPos.ToString(), JToken.FromObject(item))
                    )
                )
            );
            return jsonObject;
        }

        public object ReturnById(string message, EnumPos enumPos, bool isSuccess, object item)
        {
            JObject jsonObject = new JObject(
                new JProperty("message", message),
                new JProperty("isSuccess", isSuccess),
                new JProperty("data", new JObject(
                        new JProperty(enumPos.ToString(), JToken.FromObject(item))
                    )
                )
            );
            return jsonObject;
        }

        public object ReturnGet(string message,int count, EnumPos enumPos, bool isSuccess, object item)
        {
            JObject jsonObject = new JObject(
                new JProperty("message", message),
                new JProperty("isSuccess", isSuccess),
                new JProperty("result", count),
                new JProperty("data", new JObject(
                        new JProperty(enumPos.ToString(), JToken.FromObject(item))
                    )
                )
            );
            return jsonObject;
        }
    }
}
