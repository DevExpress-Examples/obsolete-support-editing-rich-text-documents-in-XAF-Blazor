using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Office;
using DevExpress.ExpressApp.Updating;
using RichText.Module.Blazor.Editors;
using System;
using System.Collections.Generic;
using System.Text;

namespace RichText.Module.Blazor {
    public sealed class RichTextBlazorModule : ModuleBase {
		protected override ModuleTypeList GetRequiredModuleTypesCore() {
			ModuleTypeList requiredModules = base.GetRequiredModuleTypesCore();
			requiredModules.Add(typeof(OfficeModule));
			return requiredModules;
		}
		public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
			return ModuleUpdater.EmptyModuleUpdaters;
		}
		protected override IEnumerable<Type> GetRegularTypes() {
			return Type.EmptyTypes;
		}
		protected override IEnumerable<Type> GetDeclaredExportedTypes() {
			return Type.EmptyTypes;
		}
		protected override IEnumerable<Type> GetDeclaredControllerTypes() {
			return Type.EmptyTypes;
		}
        protected override void RegisterEditorDescriptors(EditorDescriptorsFactory editorDescriptorsFactory) {
			editorDescriptorsFactory.RegisterPropertyEditor(EditorAliases.RichTextPropertyEditor, typeof(byte[]), typeof(RichTextPropertyEditor), false);
		}
    }
}
