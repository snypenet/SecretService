using System;
using System.Collections.Generic;

namespace SecretService.Persistence.Models
{
    public class SecretsFile
    {
        //public List<SecretGroup> Groups { get; set; } = new List<SecretGroup>();
        public List<SecretKeyValuePair> Pairs { get; set; } = new List<SecretKeyValuePair>();
        //public List<SecretKeyValuePair> PreviousPairs { get; set; } = new List<SecretKeyValuePair>();
    }
}
