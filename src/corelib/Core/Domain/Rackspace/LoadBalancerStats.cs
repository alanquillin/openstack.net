using Newtonsoft.Json;

namespace net.openstack.Core.Domain.Rackspace
{
    /// <summary>
    /// Detailed stats for a specified load balancer.
    /// </summary>
    /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/List_Load_Balancer_Stats-d1e1524.html">List Load Balancer Stats (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [JsonObject(MemberSerialization.OptIn)]
    public class LoadBalancerStats
    {
        /// <summary>
        /// Connections closed by this load balancer because the 'connect_timeout' interval was exceeded.
        /// </summary>
        [JsonProperty("connectTimeOut")]
        public int ConnectionTimeOutCount { get; set; }

        /// <summary>
        /// Number of transaction or protocol errors in this load balancer.
        /// </summary>
        [JsonProperty("connectError")]
        public int ErrorCount { get; set; }

        /// <summary>
        /// Number of connection failures in this load balancer.
        /// </summary>
        [JsonProperty("connectFailure")]
        public int FailureCount { get; set; }

        /// <summary>
        /// Connections closed by this load balancer because the 'timeout' interval was exceeded.
        /// </summary>
        [JsonProperty("dataTimedOut")]
        public int TimeOutCount { get; set; }

        /// <summary>
        /// Connections closed by this load balancer because the 'keepalive_timeout' interval was exceeded.
        /// </summary>
        [JsonProperty("keepAliveTimedOut")]
        public int KeepAliveTimeOutCount { get; set; }

        /// <summary>
        /// Maximum number of simultaneous TCP connections this load balancer has processed at any one time.
        /// </summary>
        [JsonProperty("maxConn")]
        public int MaximumConnections { get; set; }
    }
}
