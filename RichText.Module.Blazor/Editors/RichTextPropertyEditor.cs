using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Model;
using RichText.Module.Blazor.Components.Models;
using RichText.Module.Blazor.Editors.Adapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace RichText.Module.Blazor.Editors {
    public class RichTextPropertyEditor : BlazorPropertyEditorBase {
        public RichTextPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() => new RichTextEditorComponentAdapter(new RichTextEditorComponentModel());
    }
}