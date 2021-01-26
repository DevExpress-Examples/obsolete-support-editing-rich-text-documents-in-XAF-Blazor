using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace RichText.Module.Blazor.Components.Models {
    public class RichTextEditorComponentModel : ComponentModelBase {
        public string Value {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }
        public bool ReadOnly {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }
        public void SetValueFromUI(string value) {
            SetPropertyValue(value, notify: false, nameof(Value));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }
}
