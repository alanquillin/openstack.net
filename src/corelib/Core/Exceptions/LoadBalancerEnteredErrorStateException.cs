using System;
using System.Runtime.Serialization;
using net.openstack.Core.Domain;
using net.openstack.Core.Domain.Rackspace;

namespace net.openstack.Core.Exceptions
{
    /// <summary>
    /// The exception that is thrown when the load balancer enters an error state during a
    /// call to <see cref="O:IComputeProvider.WaitForServerState"/>.
    /// </summary>
    /// <threadsafety static="true" instance="false"/>
    [Serializable]
    public class LoadBalancerEnteredErrorStateException : Exception
    {
        [NonSerialized]
        private ExceptionData _state;

        /// <summary>
        /// Gets the error state the load balancer entered.
        /// </summary>
        /// <seealso cref="ServerState"/>
        public LoadBalancerState Status
        {
            get
            {
                return LoadBalancerState.FromName(_state.Status);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadBalancerEnteredErrorStateException"/> class
        /// with the specified error state.
        /// </summary>
        /// <param name="status">The error state entered by the load balancer.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="status"/> is <c>null</c>.</exception>
        public LoadBalancerEnteredErrorStateException(LoadBalancerState status)
            : base(string.Format("The server entered an error state: '{0}'", status))
        {
            if (status == null)
                throw new ArgumentNullException("status");

            _state.Status = status.Name;
#if !NET35
            SerializeObjectState += (ex, args) => args.AddSerializedState(_state);
#endif
        }

        [Serializable]
        private struct ExceptionData : ISafeSerializationData
        {
            public string Status
            {
                get;
                set;
            }

            void ISafeSerializationData.CompleteDeserialization(object deserialized)
            {
                ((LoadBalancerEnteredErrorStateException)deserialized)._state = this;
            }
        }
    }
}