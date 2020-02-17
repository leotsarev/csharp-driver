﻿// 
//       Copyright (C) DataStax, Inc.
// 
//     Please see the license for details:
//     http://www.datastax.com/terms/datastax-dse-driver-license-terms
// 

using Dse.Insights.Schema.StartupMessage;
using Dse.SessionManagement;

namespace Dse.Insights.InfoProviders.StartupMessage
{
    internal class PoolSizeByHostDistanceInfoProvider : IInsightsInfoProvider<PoolSizeByHostDistance>
    {
        public PoolSizeByHostDistance GetInformation(IInternalDseCluster cluster, IInternalDseSession dseSession)
        {
            return new PoolSizeByHostDistance
            {
                Local = cluster
                        .Configuration
                        .CassandraConfiguration
                        .GetOrCreatePoolingOptions(cluster.Metadata.ControlConnection.ProtocolVersion)
                        .GetCoreConnectionsPerHost(HostDistance.Local),
                Remote = cluster
                         .Configuration
                         .CassandraConfiguration
                         .GetOrCreatePoolingOptions(cluster.Metadata.ControlConnection.ProtocolVersion)
                         .GetCoreConnectionsPerHost(HostDistance.Remote)
            };
        }
    }
}