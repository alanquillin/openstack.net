using Newtonsoft.Json;

namespace net.openstack.Providers.Rackspace.Objects.Request
{
    /// <summary>
    /// This models the JSON request used for the Update Load Balancer Nodes request.
    /// </summary>
    /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Modify_Nodes-d1e2503.html">Update Load Balancer Nodes (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class UpdateLoadBalancerNodeRequest
    {
        /// <summary>
        /// Gets information about the load balancer node.
        /// </summary>
        [JsonProperty("nodes")]
        public UpdateLoadBalancerNode Node { get; set; }
    }
}