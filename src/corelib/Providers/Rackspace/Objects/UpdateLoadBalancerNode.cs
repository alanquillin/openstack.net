using Newtonsoft.Json;

namespace net.openstack.Providers.Rackspace.Objects
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateLoadBalancerNode
    {
        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }
    }
}
