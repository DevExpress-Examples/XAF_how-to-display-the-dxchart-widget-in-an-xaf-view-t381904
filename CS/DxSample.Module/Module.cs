using System;
using System.Collections.Generic;
using System.Data.Entity;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DxSample.Module.BusinessObjects;

namespace DxSample.Module {
    public sealed partial class DxSampleModule : ModuleBase {
        static DxSampleModule() {
            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = typeof(System.Data.Entity.SqlServer.SqlFunctions);
			DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = typeof(System.Data.Entity.DbFunctions);
#if DEBUG
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DxSampleDbContext>());
#endif 
        }

        public DxSampleModule() {
            InitializeComponent();
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater };
        }
    }
}
