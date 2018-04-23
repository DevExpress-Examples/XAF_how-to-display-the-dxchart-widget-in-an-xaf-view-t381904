using System;
using System.IO;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DxSample.Module.BusinessObjects;

namespace DxSample.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }

        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            this.CreateCustomers();
            this.CreateOrders();
        }

        private void CreateObjects<TEntity>(string resourceName, Action<TEntity, string[]> updateEntity) {
            int objectsCnt = this.ObjectSpace.GetObjectsCount(typeof(TEntity), null);
            if(objectsCnt > 0) return;
            Stream stream = typeof(TEntity).Assembly.GetManifestResourceStream(resourceName);
            using(TextReader reader = new StreamReader(stream)) {
                string line = string.Empty;
                while(!string.IsNullOrEmpty(line = reader.ReadLine())) {
                    string[] data = line.Split(';');
                    TEntity entity = this.ObjectSpace.CreateObject<TEntity>();
                    updateEntity(entity, data);
                }
            }
            this.ObjectSpace.CommitChanges();
        }

        private void UpdateCustomer(Customer customer, string[] data) {
            customer.FirstName = data[0];
            customer.LastName = data[1];
            customer.Country = data[2];
        }

        private void UpdateOrder(Order order, Customer customer, string[] data) {
            order.Customer = customer;
            order.OrderDate = DateTime.Parse(data[0]);
            order.UnitPrice = decimal.Parse(data[1]);
        }

        private void CreateCustomers() {
            this.CreateObjects<Customer>("DxSample.Module.Resources.Customers.csv", this.UpdateCustomer);
        }

        private void CreateOrders() {
            var customers = this.ObjectSpace.GetObjects<Customer>();
            Random randomizer = new Random(DateTime.Now.Millisecond);
            this.CreateObjects<Order>("DxSample.Module.Resources.Orders.csv", 
                (order, data) => this.UpdateOrder(order, customers[randomizer.Next(customers.Count)], data));
        }
    }
}
