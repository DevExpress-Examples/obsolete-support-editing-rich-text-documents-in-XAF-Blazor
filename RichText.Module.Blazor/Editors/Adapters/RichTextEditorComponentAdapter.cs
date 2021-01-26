using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;
using RichText.Module.Blazor.Components;
using RichText.Module.Blazor.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RichText.Module.Blazor.Editors.Adapters {
    public class RichTextEditorComponentAdapter : ComponentAdapterBase {
        public RichTextEditorComponentAdapter(RichTextEditorComponentModel componentModel) {
            ComponentModel = componentModel ?? throw new ArgumentNullException(nameof(componentModel));
            ComponentModel.ValueChanged += ComponentModel_ValueChanged;
        }
        public RichTextEditorComponentModel ComponentModel { get; }
        public override void SetAllowEdit(bool allowEdit) {
            ComponentModel.ReadOnly = !allowEdit;
        }
        public override object GetValue() {
            return ComponentModel.Value is null ? null : Convert.FromBase64String(ComponentModel.Value);
        }
        public override void SetValue(object value) {
            ComponentModel.Value = value is null ? null : Convert.ToBase64String((byte[])value);
        }
        protected override RenderFragment CreateComponent() {
            return ComponentModelObserver.Create(ComponentModel, RichTextEditorComponent.Create(ComponentModel));
        }
        private void ComponentModel_ValueChanged(object sender, EventArgs e) => RaiseValueChanged();
        public override void SetAllowNull(bool allowNull) { /* ...*/ }
        public override void SetDisplayFormat(string displayFormat) { /* ...*/ }
        public override void SetEditMask(string editMask) { /* ...*/ }
        public override void SetEditMaskType(EditMaskType editMaskType) { /* ...*/ }
        public override void SetErrorIcon(ImageInfo errorIcon) { /* ...*/ }
        public override void SetErrorMessage(string errorMessage) { /* ...*/ }
        public override void SetIsPassword(bool isPassword) { /* ...*/ }
        public override void SetMaxLength(int maxLength) { /* ...*/ }
        public override void SetNullText(string nullText) { /* ...*/ }
    }
}
