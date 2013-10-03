using Newtonsoft.Json;
using net.openstack.Core.Domain.Rackspace;

namespace net.openstack.Providers.Rackspace.Objects.Response
{
    /// <summary>
    /// This models the JSON response used for the Get Load Balancer Node request.
    /// </summary>
    /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/List_Nodes-d1e2218.html">Get Load Balancer Node (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    internal class LoadBalancerNodeResponse
    {
        /// <summary>
        /// Gets the details about the specified load balancer node.
        /// </summary>
        [JsonProperty("node")]
        public LoadBalancerNode Node { get; set; }
    }
}