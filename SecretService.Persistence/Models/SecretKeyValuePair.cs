using System;
using System.Collections.Generic;

namespace SecretService.Persistence.Models
{
    public class SecretKeyValuePair
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public List<string> Group { get; set; }
    }
}
