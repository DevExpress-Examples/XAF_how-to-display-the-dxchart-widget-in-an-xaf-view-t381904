using System.ComponentModel;
using System.Globalization;
using DevExpress.Persistent.Base;

namespace DxSample.Module.BusinessObjects {
    [DefaultProperty("FullName")]
    [NavigationItem]
    public class Customer {
        [Browsable(false)]
        public int ID { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        [EditorAlias("TagEditor")]
        public string Tag { get; set; }

        public string FullName {
            get {
                return string.Format(CultureInfo.CurrentUICulture,
                    "{0} {1}",
                    this.FirstName, this.LastName);
            }
        }
    }
}
