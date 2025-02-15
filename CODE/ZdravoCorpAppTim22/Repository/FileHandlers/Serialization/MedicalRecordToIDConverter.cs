﻿using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZdravoCorpAppTim22.Repository.FileHandlers.Serialization
{
    internal class MedicalRecordToIDConverter : JsonConverter<MedicalRecord>
    {
        public override MedicalRecord Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return MedicalRecordRepository.Instance.GetByID(reader.GetInt32());
        }

        public override void Write(Utf8JsonWriter writer, MedicalRecord value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Id);
        }
    }
}
