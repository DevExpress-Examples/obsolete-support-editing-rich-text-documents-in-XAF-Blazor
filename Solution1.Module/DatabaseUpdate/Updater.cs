using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using Solution1.Module.BusinessObjects;
using System.IO;
using System.Reflection;

namespace Solution1.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            string documentName = "Demo Document";
            Document richText = ObjectSpace.FindObject<Document>(CriteriaOperator.Parse("Subject = ?", documentName));
            if (richText == null) {
                richText = ObjectSpace.CreateObject<Document>();
                richText.Subject = documentName;
                byte[] document = GetDemoDocument("DemoDocument");
                richText.Text = document;
            }
            ObjectSpace.CommitChanges(); //This line persists created object(s).
        }
        private byte[] GetDemoDocument(string name) {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames();
            var resourceName = resourceNames.FirstOrDefault(p => p.Contains(name));
            byte[] buffer = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName)) {
                buffer = new byte[stream.Length];
                stream.Read(buffer, 0, (int)stream.Length);
            }
            return buffer;
        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
