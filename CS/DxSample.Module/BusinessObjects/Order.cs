using System;
using System.ComponentModel;
using DevExpress.Persistent.Base;

namespace DxSample.Module.BusinessObjects {
    [DefaultProperty("ShipName")]
    [NavigationItem]
    public class Order {
        [Browsable(false)]
        public int ID { get; protected set; }
        public DateTime OrderDate { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
