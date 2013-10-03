using Newtonsoft.Json;

namespace net.openstack.Providers.Rackspace.Objects
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateLoadBalancer
    {
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("protocol", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Protocol { get; set; }

        [JsonProperty("port", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Port { get; set; }

        [JsonProperty("halfClosed", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? HalfClosed { get; set; }

        [JsonProperty("algorithm", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Algorithm { get; set; }

        [JsonProperty("timeout", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Timeout { get; set; }  
    }
}