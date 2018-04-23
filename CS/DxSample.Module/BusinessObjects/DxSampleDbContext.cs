using System.Data.Common;
using System.Data.Entity;
using DevExpress.ExpressApp.EF.Updating;

namespace  DxSample.Module.BusinessObjects {
	public class DxSampleDbContext : DbContext {
		public DxSampleDbContext(string connectionString)
			: base(connectionString) {
		}
		public DxSampleDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public DxSampleDbContext()
			: base("name=ConnectionString") {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
	}
}