﻿using System.Collections.Generic;
using System.Linq;

namespace LiepaLimitedTest.Infrastructure.Dapper.Data
{
    public abstract class CommonHelper
    {
        //(*Field1*, *Field2*) VALUES(*@Value1*, *@Value2*)
        public string GenerateCreateValuesQuery()
        {
            return $"({string.Join(", ", GetFields())}) VALUES({string.Join(", ", GetFields().Select(x => "@" + x))})";
        }

        //*Field1* = *@Value1*, *Field2* = *@Value2*
        public string GenerateUpdateValuesQuery()
        {
            return string.Join(", ", GetFields().Select(x => $"{x} = @{x}"));
        }

        protected abstract IEnumerable<string> GetFields();
    }
}
