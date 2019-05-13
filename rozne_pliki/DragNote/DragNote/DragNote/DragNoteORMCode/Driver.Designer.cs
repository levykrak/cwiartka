//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace DragNoteApp.DragNote
{

    public partial class Driver : XPLiteObject
    {
        int fid;
        [Key(true)]
        public int id
        {
            get { return fid; }
            set { SetPropertyValue<int>("id", ref fid, value); }
        }
        string fname;
        [Size(150)]
        public string name
        {
            get { return fname; }
            set { SetPropertyValue<string>("name", ref fname, value); }
        }
        string fcar;
        [Size(50)]
        public string car
        {
            get { return fcar; }
            set { SetPropertyValue<string>("car", ref fcar, value); }
        }
        int fcar_no;
        public int car_no
        {
            get { return fcar_no; }
            set { SetPropertyValue<int>("car_no", ref fcar_no, value); }
        }
        [Association(@"RaceReferencesDriver", typeof(Race))]
        public XPCollection<Race> Races { get { return GetCollection<Race>("Races"); } }
    }

}