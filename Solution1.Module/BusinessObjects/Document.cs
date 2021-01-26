using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.Module.BusinessObjects {
    [DefaultClassOptions]
    [XafDefaultProperty(nameof(Subject))]
    public class Document : BaseObject {
        public Document(Session session) : base(session) { }


        byte[] text;
        string subject;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Subject {
            get => subject;
            set => SetPropertyValue(nameof(Subject), ref subject, value);
        }
        [EditorAlias(EditorAliases.RichTextPropertyEditor)]
        [Size(SizeAttribute.Unlimited)]
        public byte[] Text {
            get => text;
            set => SetPropertyValue(nameof(Text), ref text, value);
        }
    }
}
