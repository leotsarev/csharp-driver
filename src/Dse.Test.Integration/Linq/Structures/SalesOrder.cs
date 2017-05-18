//
//  Copyright (C) 2017 DataStax, Inc.
//
//  Please see the license for details:
//  http://www.datastax.com/terms/datastax-dse-driver-license-terms
//

using System;
using Dse.Data.Linq;
#pragma warning disable 618

namespace Dse.Test.Integration.Linq
{
    [AllowFiltering]
    [Table("sales")]
    public class SalesOrder
    {
        [PartitionKey]
        [Column("order_number")]
        public string OrderNumber { get; set; }

        [ClusteringKey(1)]
        [Column("customer")]
        public string Customer { get; set; }

        [Column("sales_person")]
        public string SalesPerson { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("ship_date")]
        public DateTime ShipDate { get; set; }

        //[Column("line_items")]
        //public List<LineItem> LineItems = new List<LineItem>();
        //[Column("shipping_address")]
        //public Address ShippingAddress { get; set; }
        //        [Column("billing_address")]
        //        public Address BillingAddress { get; set; }
    }
}