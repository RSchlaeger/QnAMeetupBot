using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicBot.Models
{
    public class SpellCheckModel
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("FlaggedTokens")]
        public Tokens[] FlaggedTokens { get; set; }
    }

    public class Tokens
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("suggestions")]
        public Suggestion[] Suggestions { get; set; }

        [JsonProperty("correctionType")]
        public string CorrectionType { get; set; }
    }

    public class Suggestion
    {
        [JsonProperty("suggestion")]
        public string Correction { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }

}