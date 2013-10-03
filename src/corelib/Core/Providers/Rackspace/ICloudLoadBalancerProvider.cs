using System;
using System.Collections.Generic;
using net.openstack.Core.Domain;
using net.openstack.Core.Domain.Rackspace;
using net.openstack.Core.Exceptions;
using net.openstack.Core.Exceptions.Response;

namespace net.openstack.Core.Providers.Rackspace
{
    /// <summary>
    /// Describes the available Cloud Load Balancer actions and services
    /// </summary>
    public interface ICloudLoadBalancerProvider
    {

        /// <summary>
        /// Retrieves a list of basic information for load balancers in the account
        /// </summary>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A collection of <see cref="SimpleLoadBalancer"/> objects describing the requested load balancers.</returns>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/List_Load_Balancers-d1e1367.html">List Load Balancers (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        IEnumerable<SimpleLoadBalancer> ListLoadBalancers(string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Get the details of the specified load balancer.
        /// </summary>
        /// <param name="id">The Id of the specified Load Balancer</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancer"/> instance for the specified load balancer</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="id"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="id"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/List_Load_Balancer_Details-d1e1522.html">Get Load Balancer Details (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        LoadBalancer GetLoadBalancer(string id, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Creates a new Load Balancer.
        /// </summary>
        /// <param name="name">Name of the load balancer to create. The name must be 128 characters or less in length, and all UTF-8 characters are valid. Refer to http://www.utf8-chartable.de/ for information about the UTF-8 character set. Refer to the request examples in this section for the required xml/json format.</param>
        /// <param name="protocol">Protocol of the service which is being load balanced. Refer to Section 4.15, “Protocols” for a table of available protocols.</param>
        /// <param name="virtualIps">Type of virtualIp to add along with the creation of a load balancer.<remarks>Available values: [PUBLIC,SERVICENET]</remarks></param>
        /// <param name="nodes">Type of virtualIp to add along with the creation of a load balancer.<remarks>Available values: [PUBLIC,SERVICENET]</remarks></param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancer"/> instance containing the details for the newly created load balancer</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="name"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <para><paramref name="protocol"/> is <c>null</c>.</para>
        /// <para>-or-</para>
        /// <para><paramref name="virtualIps"/> is <c>null</c>.</para>
        /// <para>-or-</para>
        /// <para><paramref name="nodes"/> is <c>null</c>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="name"/> is empty.
        /// <para>-or-</para>
        /// <para><paramref name="protocol.Name"/> is empty.</para>
        /// <para>-or-</para>
        /// <para><paramref name="virtualIps"/> does not conatin at least one item.</para>
        /// <para>-or-</para>
        /// <para><paramref name="nodes"/> does not conatin at least one item with an ENABLED condition</para>
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Create_Load_Balancer-d1e1635.html">Create Load Balancer (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        LoadBalancer CreateLoadBalancer(string name, LoadBalancerProtocol protocol, IEnumerable<VirtualIPType> virtualIps, IEnumerable<LoadBalancerNode> nodes, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Remove a single or batch of load balancers from the account.
        /// </summary>
        /// <param name="id">The id of the load balancer to remove.</param>
        /// <param name="name">Name of the load balancer to update. The name must be 128 characters or less in length, and all UTF-8 characters are valid. Refer to http://www.utf8-chartable.de/ for information about the UTF-8 character set. Refer to the request examples in this section for the required xml/json format.</param>
        /// <param name="protocol">Protocol of the service which is being load balanced.</param>
        /// <param name="algorithm">Algorithm that defines how traffic should be directed between back-end nodes.</param>
        /// <param name="timeout">The timeout value for the load balancer and communications with its nodes. Defaults to 30 seconds with a max 120 seconds.</param>
        /// <param name="halfClosed">Enable or Disable Half-Closed support for the load balancer.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="id"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="id"/> does not contain any items.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="timeout"/> has a value greater than 120.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Update_Load_Balancer_Attributes-d1e1812.html">Update Load Balancer (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        LoadBalancer UpdateLoadBalancer(string id, string name = null, LoadBalancerProtocol protocol = null, LoadBalancerAlgorithm algorithm = null, TimeSpan? timeout = null, bool? halfClosed = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Remove a load balancer from the account.
        /// </summary>
        /// <param name="id">The id of the load balancer.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="id"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="id"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Remove_Load_Balancer-d1e2093.html">Remove Load Balancer (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        void RemoveLoadBalancer(string id, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Remove a single or batch of load balancers from the account.
        /// </summary>
        /// <param name="ids">The id(s) of the load balancer(s) to remove.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="ids"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="ids"/> does not contain any items.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Remove_Load_Balancer-d1e2093.html">Remove Load Balancers (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        void RemoveLoadBalancers(IEnumerable<string> ids, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Waits for the load balancer to enter a specified state.
        /// </summary>
        /// <remarks>
        /// <note type="caller">
        /// This is a blocking operation and will not return until the server enters either an expected state, an error state, or the retry count is exceeded.
        /// </note>
        /// </remarks>
        /// <param name="loadBalancerId">The load balancer ID. This is obtained from <see cref="LoadBalancer.Id">LoadBalancer.Id</see>.</param>
        /// <param name="expectedState">The expected state.</param>
        /// <param name="errorStates">The error state(s) in which to throw an exception if the load balancer enters.</param>
        /// <param name="refreshCount">Number of times to poll the load balancer's status.</param>
        /// <param name="refreshDelay">The time to wait between polling requests for the load balancer status. If this value is <c>null</c>, the default is 2.4 seconds.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancer"/> object containing the server details, including the final <see cref="LoadBalancer.Status"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="loadBalancerId"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <para>If <paramref name="expectedState"/> is <c>null</c>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="errorStates"/> is <c>null</c>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="loadBalancerId"/> is empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="refreshCount"/> is less than 0.
        /// <para>-or-</para>
        /// <para>If <paramref name="refreshDelay"/> is negative.</para>
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ServerEnteredErrorStateException">If the method returned due to the load balancer entering one of the <paramref name="errorStates"/>.</exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        LoadBalancer WaitForLoadBalancerState(string loadBalancerId, LoadBalancerState expectedState, LoadBalancerState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Waits for the load balancer to enter any one of a set of specified states.
        /// </summary>
        /// <remarks>
        /// <note type="caller">
        /// This is a blocking operation and will not return until the server enters either an expected state, an error state, or the retry count is exceeded.
        /// </note>
        /// </remarks>
        /// <param name="loadBalancerId">The load balancer ID. This is obtained from <see cref="LoadBalancer.Id">LoadBalancer.Id</see>.</param>
        /// <param name="expectedStates">The expected state(s).</param>
        /// <param name="errorStates">The error state(s) in which to throw an exception if the load balancer enters.</param>
        /// <param name="refreshCount">Number of times to poll the load balancer's status.</param>
        /// <param name="refreshDelay">The time to wait between polling requests for the load balancer status. If this value is <c>null</c>, the default is 2.4 seconds.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancer"/> object containing the server details, including the final <see cref="LoadBalancer.Status"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="loadBalancerId"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <para>If <paramref name="expectedStates"/> is <c>null</c>.</para>
        /// <para>-or-</para>
        /// <para>If <paramref name="errorStates"/> is <c>null</c>.</para>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="loadBalancerId"/> is empty.
        /// <para>-or-</para>
        /// <para>If <paramref name="expectedStates"/> is empty.</para>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="refreshCount"/> is less than 0.
        /// <para>-or-</para>
        /// <para>If <paramref name="refreshDelay"/> is negative.</para>
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ServerEnteredErrorStateException">If the method returned due to the load balancer entering one of the <paramref name="errorStates"/>.</exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        LoadBalancer WaitForLoadBalancerState(string loadBalancerId, LoadBalancerState[] expectedStates, LoadBalancerState[] errorStates, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Waits for the load balancer to enter the <see cref="LoadBalancerState.Active"/> state.
        /// </summary>
        /// <remarks>
        /// <note type="caller">
        /// This is a blocking operation and will not return until the server enters the <see cref="LoadBalancerState.Active"/> state, an error state, or the retry count is exceeded.
        /// </note>
        /// </remarks>
        /// <param name="loadBalancerId">The load balancer ID. This is obtained from <see cref="LoadBalancer.Id">LoadBalancer.Id</see>.</param>
        /// <param name="refreshCount">Number of times to poll the load balancer's status.</param>
        /// <param name="refreshDelay">The time to wait between polling requests for the load balancer status. If this value is <c>null</c>, the default is 2.4 seconds.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancer"/> object containing the server details, including the final <see cref="LoadBalancer.Status"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="loadBalancerId"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="loadBalancerId"/> is empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="refreshCount"/> is less than 0.
        /// <para>-or-</para>
        /// <para>If <paramref name="refreshDelay"/> is negative.</para>
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        LoadBalancer WaitForLoadBalancerActive(string loadBalancerId, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Waits for the load balancer to enter the <see cref="LoadBalancerState.Deleted"/> state.
        /// </summary>
        /// <remarks>
        /// <note type="caller">
        /// This is a blocking operation and will not return until the server enters the <see cref="LoadBalancerState.Deleted"/> state, an error state, or the retry count is exceeded.
        /// </note>
        /// </remarks>
        /// <param name="loadBalancerId">The load balancer ID. This is obtained from <see cref="LoadBalancer.Id">LoadBalancer.Id</see>.</param>
        /// <param name="refreshCount">Number of times to poll the load balancer's status.</param>
        /// <param name="refreshDelay">The time to wait between polling requests for the load balancer status. If this value is <c>null</c>, the default is 2.4 seconds.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancer"/> object containing the server details, including the final <see cref="LoadBalancer.Status"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="loadBalancerId"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="loadBalancerId"/> is empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="refreshCount"/> is less than 0.
        /// <para>-or-</para>
        /// <para>If <paramref name="refreshDelay"/> is negative.</para>
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        void WaitForLoadBalancerDeleted(string loadBalancerId, int refreshCount = 600, TimeSpan? refreshDelay = null, string region = null, CloudIdentity identity = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The load balancer ID. This is obtained from <see cref="LoadBalancer.Id">LoadBalancer.Id</see>.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancer"/> object containing the server details, including the final <see cref="LoadBalancer.Status"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="id"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="id"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/List_Load_Balancer_Stats-d1e1524.html">Get Load Balancer Stats (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        LoadBalancerStats GetLoadBalancerStats(string id, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// List node(s) configured for the load balancer.
        /// </summary>
        /// <param name="loadBalancerId">The id of the load balancer.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A collection of <see cref="LoadBalancerNode"/> objects describing the requested load balancer nodes.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="loadBalancerId"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="loadBalancerId"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/List_Nodes-d1e2218.html">List Load Balancer Nodes (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        IEnumerable<LoadBalancerNode> ListLoadBalancerNodes(string loadBalancerId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// Get the details for the specified load balancer node.
        /// </summary>
        /// <param name="loadBalancerId">The id of the load balancer.</param>
        /// <param name="nodeId">The id of the load balancer node.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancerNode"/> instance for the specified load balancer node</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="loadBalancerId"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <paramref name="nodeId"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="loadBalancerId"/> is empty.
        /// <para>-or-</para>
        /// <paramref name="nodeId"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/List_Nodes-d1e2218.html">Get Load Balancer Node (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        LoadBalancerNode GetLoadBalancerNode(string loadBalancerId, string nodeId, string region = null, CloudIdentity identity = null);

        /// <summary>
        /// List node(s) configured for the load balancer.
        /// </summary>
        /// <param name="loadBalancerId">The id of the load balancer.</param>
        /// <param name="ipAddress">IP address or domain name for the node.</param>
        /// <param name="condition">Condition for the node, which determines its role within the load balancer.</param>
        /// <param name="port">Port number for the service you are load balancing.</param>
        /// <param name="type">Type of node to add.</param>
        /// <param name="weight">Weight of node to add. If the specified load balancer is in the <see cref="LoadBalancerAlgorithm.WeightedRoundRobin"/> mode, then the user should assign the relevant weight to the node using the weight attribute for the node. Must be an integer from 1 to 100.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancerNode"/>  instance containing the details for the newly added load balancer node</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="loadBalancerId"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <paramref name="ipAddress"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <paramref name="condition"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <paramref name="type"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="loadBalancerId"/> is empty.
        /// <para>-or-</para>
        /// <paramref name="ipAddress"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Add_Nodes-d1e2379.html">Add Load Balancer Node (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        LoadBalancerNode AddLoadBalancerNode(string loadBalancerId, string ipAddress, LoadBalancerNodeCondition condition, int port, LoadBalancerNodeType type, int? weight = null, string region = null, CloudIdentity identity = null);
        
        /// <summary>
        /// Updates ther details for a specified load balancer node
        /// </summary>
        /// <param name="loadBalancerId">The id of the load balancer.</param>
        /// <param name="nodeId">The id of the load balancer node.</param>
        /// <param name="condition"></param>
        /// <param name="type"></param>
        /// <param name="weight"></param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A <see cref="LoadBalancerNode"/> instance for the specified load balancer node</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="loadBalancerId"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <paramref name="nodeId"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="loadBalancerId"/> is empty.
        /// <para>-or-</para>
        /// <paramref name="nodeId"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Modify_Nodes-d1e2503.html">Modify Load Balancer Node (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        LoadBalancerNode UpdateLoadBalancerNode(string loadBalancerId, string nodeId, LoadBalancerNodeCondition condition = null, LoadBalancerNodeType type = null, int? weight = null, string region = null, CloudIdentity identity = null);
        
        /// <summary>
        /// Removes the specified load balancer node from the account.
        /// </summary>
        /// <param name="loadBalancerId">The id of the load balancer.</param>
        /// <param name="nodeId">The id of the load balancer node.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="loadBalancerId"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <paramref name="nodeId"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="loadBalancerId"/> is empty.
        /// <para>-or-</para>
        /// <paramref name="nodeId"/> is empty.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Remove_Nodes-d1e2675.html">Remove Load Balancer Node (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        void RemoveLoadBalancerNode(string loadBalancerId, string nodeId, string region = null, CloudIdentity identity = null);
        
        /// <summary>
        /// Removes a batch of load balancer nodes from the account.
        /// </summary>
        /// <param name="loadBalancerId">The id of the load balancer.</param>
        /// <param name="nodeId">The id of the load balancer node.</param>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="loadBalancerId"/> is <c>null</c>.
        /// <para>-or-</para>
        /// <paramref name="nodeIds"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="loadBalancerId"/> is empty.
        /// <para>-or-</para>
        /// <paramref name="nodeIds"/> contains no items.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <c>null</c> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <c>null</c> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.rackspace.com/loadbalancers/api/v1.0/clb-devguide/content/Remove_Nodes-d1e2675.html">Remove Load Balancer Nodes (Rackspace Cloud Load Balancers Developer Guide - API v1.0)</seealso>
        void RemoveLoadBalancerNodes(string loadBalancerId, IEnumerable<string> nodeIds, string region = null, CloudIdentity identity = null);

        //IEnumerable<LoadBalancerNodeServiceEvent> ListLoadBalancerNodeServiceEvents(string loadBalancerId, string nodeId, string region = null, CloudIdentity identity = null);

        //IEnumerable<VirtualIP> ListLoadBalancerVirtualIPs(string loadBalancerId, string region = null, CloudIdentity identity = null);

        //IEnumerable<AllowedDomain> ListAllowedDomains(string region = null, CloudIdentity identity = null); 
    }
}
