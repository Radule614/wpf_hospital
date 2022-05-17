﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZdravoCorpAppTim22.Model;

namespace ZdravoCorpAppTim22.Repository.FileHandlers.Serialization
{
    internal class RequestForAbsenceToIDConverter : JsonConverter<RequestForAbsence>
    {
        public override RequestForAbsence Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return RequestForAbsenceRepository.Instance.GetByID(reader.GetInt32());
        }

        public override void Write(Utf8JsonWriter writer, RequestForAbsence value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Id);
        }
    }
}
