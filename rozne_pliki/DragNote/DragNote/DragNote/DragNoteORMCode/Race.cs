using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace DragNoteApp.DragNote
{

    public partial class Race
    {
        public Race(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
