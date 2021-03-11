﻿using Newtonsoft.Json;

namespace MyJetWallet.BitGo.Models.Address
{
    public class AddressInfoList
    {
        [JsonProperty("coin")]
        public string Coin { get; internal set; }
        
        [JsonProperty("totalAddressCount")]
        public int TotalAddressCount { get; internal set; }
        
        [JsonProperty("pendingAddressCount")]
        public int PendingAddressCount { get; internal set; }
        
        [JsonProperty("nextBatchPrevId")]
        public string NextBatchPrevId { get; internal set; }
        
        [JsonProperty("addresses")]
        public AddressInfo[] Addresses { get; internal set; }
        
        [JsonProperty("count")]
        public int Count { get; internal set; }
    }
}
