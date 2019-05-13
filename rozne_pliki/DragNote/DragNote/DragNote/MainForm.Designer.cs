namespace DragNoteApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.xpCollection1 = new DevExpress.Xpo.XPCollection(this.components);
            this.session1 = new DevExpress.Xpo.Session(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcar_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.z = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.labelComponent1 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.gaugeControl2 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.digitalGauge2 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent2 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.labelComponent2 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.btnLeftTrackStart = new System.Windows.Forms.Button();
            this.btnLeftTrackStop = new System.Windows.Forms.Button();
            this.timLeftTrack = new System.Windows.Forms.Timer(this.components);
            this.btnLeftTrackReset = new System.Windows.Forms.Button();
            this.spLevy = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblLDriver = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblL_Id = new System.Windows.Forms.Label();
            this.btnLSaveTime = new System.Windows.Forms.Button();
            this.lblL_RT = new System.Windows.Forms.Label();
            this.lblL_ET = new System.Windows.Forms.Label();
            this.lblL_Time14 = new System.Windows.Forms.Label();
            this.lblLCar = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblR_Id = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lblR_RT = new System.Windows.Forms.Label();
            this.lblR_ET = new System.Windows.Forms.Label();
            this.lblR_Time14 = new System.Windows.Forms.Label();
            this.lblRCar = new System.Windows.Forms.Label();
            this.lblRDriver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpCollection1
            // 
            this.xpCollection1.ObjectType = typeof(DragNoteApp.DragNote.Driver);
            this.xpCollection1.Session = this.session1;
            // 
            // session1
            // 
            this.session1.IsObjectModifiedOnNonPersistentPropertyChange = null;
            this.session1.TrackPropertiesModifications = false;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.xpCollection1;
            this.gridControl1.Location = new System.Drawing.Point(296, 246);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(433, 400);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colname,
            this.colcar,
            this.colcar_no});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colname
            // 
            this.colname.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colname.AppearanceHeader.Options.UseFont = true;
            this.colname.Caption = "Name";
            this.colname.FieldName = "name";
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            // 
            // colcar
            // 
            this.colcar.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colcar.AppearanceHeader.Options.UseFont = true;
            this.colcar.Caption = "Car";
            this.colcar.FieldName = "car";
            this.colcar.Name = "colcar";
            this.colcar.Visible = true;
            this.colcar.VisibleIndex = 1;
            // 
            // colcar_no
            // 
            this.colcar_no.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.colcar_no.AppearanceHeader.Options.UseFont = true;
            this.colcar_no.Caption = "Car Number";
            this.colcar_no.FieldName = "car_no";
            this.colcar_no.Name = "colcar_no";
            this.colcar_no.Visible = true;
            this.colcar_no.VisibleIndex = 2;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.Size = new System.Drawing.Size(1015, 155);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Drag Race 1/4 Mile";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Drivers";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Events";
            this.barButtonItem3.Id = 4;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Race Type";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Race Type";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Settings";
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.z});
            this.gaugeControl1.Location = new System.Drawing.Point(10, 161);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(280, 160);
            this.gaugeControl1.TabIndex = 1;
            // 
            // z
            // 
            this.z.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#00FFFFFF");
            this.z.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:WhiteSmoke");
            this.z.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent1});
            this.z.Bounds = new System.Drawing.Rectangle(6, 6, 268, 148);
            this.z.DigitCount = 6;
            this.z.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent1});
            this.z.Name = "z";
            this.z.Text = "0:00:000";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(307.775F, 99.9625F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent7";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style7;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(20F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // labelComponent1
            // 
            this.labelComponent1.AppearanceText.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelComponent1.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent1.Name = "digitalGauge1_Label1";
            this.labelComponent1.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(60F, -10F);
            this.labelComponent1.Size = new System.Drawing.SizeF(305F, 25F);
            this.labelComponent1.Text = "Left Track";
            this.labelComponent1.ZOrder = -1001;
            // 
            // gaugeControl2
            // 
            this.gaugeControl2.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.digitalGauge2});
            this.gaugeControl2.Location = new System.Drawing.Point(735, 161);
            this.gaugeControl2.Name = "gaugeControl2";
            this.gaugeControl2.Size = new System.Drawing.Size(280, 160);
            this.gaugeControl2.TabIndex = 2;
            // 
            // digitalGauge2
            // 
            this.digitalGauge2.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#00FFFFFF");
            this.digitalGauge2.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:WhiteSmoke");
            this.digitalGauge2.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent2});
            this.digitalGauge2.Bounds = new System.Drawing.Rectangle(6, 6, 268, 148);
            this.digitalGauge2.DigitCount = 6;
            this.digitalGauge2.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent2});
            this.digitalGauge2.Name = "digitalGauge2";
            this.digitalGauge2.Text = "0:00:000";
            // 
            // digitalBackgroundLayerComponent2
            // 
            this.digitalBackgroundLayerComponent2.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(307.775F, 99.9625F);
            this.digitalBackgroundLayerComponent2.Name = "digitalBackgroundLayerComponent7";
            this.digitalBackgroundLayerComponent2.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style7;
            this.digitalBackgroundLayerComponent2.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(20F, 0F);
            this.digitalBackgroundLayerComponent2.ZOrder = 1000;
            // 
            // labelComponent2
            // 
            this.labelComponent2.AppearanceText.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelComponent2.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.labelComponent2.Name = "digitalGauge1_Label1";
            this.labelComponent2.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(70F, -10F);
            this.labelComponent2.Size = new System.Drawing.SizeF(305F, 25F);
            this.labelComponent2.Text = "Right Track";
            this.labelComponent2.ZOrder = -1001;
            // 
            // btnLeftTrackStart
            // 
            this.btnLeftTrackStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLeftTrackStart.Image = global::DragNote.Properties.Resources.nav_plain_green;
            this.btnLeftTrackStart.Location = new System.Drawing.Point(437, 159);
            this.btnLeftTrackStart.Name = "btnLeftTrackStart";
            this.btnLeftTrackStart.Size = new System.Drawing.Size(151, 80);
            this.btnLeftTrackStart.TabIndex = 4;
            this.btnLeftTrackStart.Text = "Start Race";
            this.btnLeftTrackStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLeftTrackStart.UseVisualStyleBackColor = true;
            this.btnLeftTrackStart.Click += new System.EventHandler(this.btnLeftTrackStart_Click);
            // 
            // btnLeftTrackStop
            // 
            this.btnLeftTrackStop.Image = global::DragNote.Properties.Resources.nav_plain_red;
            this.btnLeftTrackStop.Location = new System.Drawing.Point(296, 159);
            this.btnLeftTrackStop.Name = "btnLeftTrackStop";
            this.btnLeftTrackStop.Size = new System.Drawing.Size(135, 80);
            this.btnLeftTrackStop.TabIndex = 6;
            this.btnLeftTrackStop.Text = "Stop";
            this.btnLeftTrackStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLeftTrackStop.UseVisualStyleBackColor = true;
            this.btnLeftTrackStop.Click += new System.EventHandler(this.btnLeftTrackStop_Click);
            // 
            // timLeftTrack
            // 
            this.timLeftTrack.Interval = 25;
            this.timLeftTrack.Tick += new System.EventHandler(this.timLeftTrack_Tick);
            // 
            // btnLeftTrackReset
            // 
            this.btnLeftTrackReset.Image = global::DragNote.Properties.Resources.nav_refresh_blue;
            this.btnLeftTrackReset.Location = new System.Drawing.Point(594, 160);
            this.btnLeftTrackReset.Name = "btnLeftTrackReset";
            this.btnLeftTrackReset.Size = new System.Drawing.Size(135, 80);
            this.btnLeftTrackReset.TabIndex = 8;
            this.btnLeftTrackReset.Text = "Reset";
            this.btnLeftTrackReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLeftTrackReset.UseVisualStyleBackColor = true;
            this.btnLeftTrackReset.Click += new System.EventHandler(this.btnLeftTrackReset_Click);
            // 
            // spLevy
            // 
            this.spLevy.PortName = "COM7";
            this.spLevy.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spLevy_DataReceived);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(10, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(280, 49);
            this.button1.TabIndex = 12;
            this.button1.Text = "Select Left Driver";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(735, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(280, 49);
            this.button2.TabIndex = 13;
            this.button2.Text = "Select Right Driver";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblLDriver
            // 
            this.lblLDriver.AutoSize = true;
            this.lblLDriver.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblLDriver.Location = new System.Drawing.Point(6, 28);
            this.lblLDriver.Name = "lblLDriver";
            this.lblLDriver.Size = new System.Drawing.Size(84, 13);
            this.lblLDriver.TabIndex = 14;
            this.lblLDriver.Text = "Selected Driver:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblL_Id);
            this.groupBox1.Controls.Add(this.btnLSaveTime);
            this.groupBox1.Controls.Add(this.lblL_RT);
            this.groupBox1.Controls.Add(this.lblL_ET);
            this.groupBox1.Controls.Add(this.lblL_Time14);
            this.groupBox1.Controls.Add(this.lblLCar);
            this.groupBox1.Controls.Add(this.lblLDriver);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(10, 382);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 264);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summary";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblL_Id
            // 
            this.lblL_Id.AutoSize = true;
            this.lblL_Id.Location = new System.Drawing.Point(233, 28);
            this.lblL_Id.Name = "lblL_Id";
            this.lblL_Id.Size = new System.Drawing.Size(0, 13);
            this.lblL_Id.TabIndex = 19;
            // 
            // btnLSaveTime
            // 
            this.btnLSaveTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLSaveTime.Image = global::DragNote.Properties.Resources.floppy_disk_ok;
            this.btnLSaveTime.Location = new System.Drawing.Point(9, 178);
            this.btnLSaveTime.Name = "btnLSaveTime";
            this.btnLSaveTime.Size = new System.Drawing.Size(265, 80);
            this.btnLSaveTime.TabIndex = 16;
            this.btnLSaveTime.Text = "Save Time";
            this.btnLSaveTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLSaveTime.UseVisualStyleBackColor = true;
            this.btnLSaveTime.Click += new System.EventHandler(this.btnLSaveTime_Click);
            // 
            // lblL_RT
            // 
            this.lblL_RT.AutoSize = true;
            this.lblL_RT.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblL_RT.Location = new System.Drawing.Point(6, 145);
            this.lblL_RT.Name = "lblL_RT";
            this.lblL_RT.Size = new System.Drawing.Size(24, 13);
            this.lblL_RT.TabIndex = 18;
            this.lblL_RT.Text = "RT:";
            // 
            // lblL_ET
            // 
            this.lblL_ET.AutoSize = true;
            this.lblL_ET.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblL_ET.Location = new System.Drawing.Point(6, 119);
            this.lblL_ET.Name = "lblL_ET";
            this.lblL_ET.Size = new System.Drawing.Size(23, 13);
            this.lblL_ET.TabIndex = 17;
            this.lblL_ET.Text = "ET:";
            // 
            // lblL_Time14
            // 
            this.lblL_Time14.AutoSize = true;
            this.lblL_Time14.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblL_Time14.Location = new System.Drawing.Point(6, 91);
            this.lblL_Time14.Name = "lblL_Time14";
            this.lblL_Time14.Size = new System.Drawing.Size(73, 13);
            this.lblL_Time14.TabIndex = 16;
            this.lblL_Time14.Text = "Time 1/4 Mile:";
            // 
            // lblLCar
            // 
            this.lblLCar.AutoSize = true;
            this.lblLCar.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblLCar.Location = new System.Drawing.Point(6, 55);
            this.lblLCar.Name = "lblLCar";
            this.lblLCar.Size = new System.Drawing.Size(28, 13);
            this.lblLCar.TabIndex = 15;
            this.lblLCar.Text = "Car:";
            this.lblLCar.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblR_Id);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.lblR_RT);
            this.groupBox2.Controls.Add(this.lblR_ET);
            this.groupBox2.Controls.Add(this.lblR_Time14);
            this.groupBox2.Controls.Add(this.lblRCar);
            this.groupBox2.Controls.Add(this.lblRDriver);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(735, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 264);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Summary";
            // 
            // lblR_Id
            // 
            this.lblR_Id.AutoSize = true;
            this.lblR_Id.Location = new System.Drawing.Point(233, 28);
            this.lblR_Id.Name = "lblR_Id";
            this.lblR_Id.Size = new System.Drawing.Size(0, 13);
            this.lblR_Id.TabIndex = 20;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Image = global::DragNote.Properties.Resources.floppy_disk_ok;
            this.button4.Location = new System.Drawing.Point(9, 178);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(265, 80);
            this.button4.TabIndex = 16;
            this.button4.Text = "Save Time";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // lblR_RT
            // 
            this.lblR_RT.AutoSize = true;
            this.lblR_RT.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblR_RT.Location = new System.Drawing.Point(6, 145);
            this.lblR_RT.Name = "lblR_RT";
            this.lblR_RT.Size = new System.Drawing.Size(24, 13);
            this.lblR_RT.TabIndex = 18;
            this.lblR_RT.Text = "RT:";
            // 
            // lblR_ET
            // 
            this.lblR_ET.AutoSize = true;
            this.lblR_ET.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblR_ET.Location = new System.Drawing.Point(6, 119);
            this.lblR_ET.Name = "lblR_ET";
            this.lblR_ET.Size = new System.Drawing.Size(23, 13);
            this.lblR_ET.TabIndex = 17;
            this.lblR_ET.Text = "ET:";
            // 
            // lblR_Time14
            // 
            this.lblR_Time14.AutoSize = true;
            this.lblR_Time14.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblR_Time14.Location = new System.Drawing.Point(6, 91);
            this.lblR_Time14.Name = "lblR_Time14";
            this.lblR_Time14.Size = new System.Drawing.Size(73, 13);
            this.lblR_Time14.TabIndex = 16;
            this.lblR_Time14.Text = "Time 1/4 Mile:";
            // 
            // lblRCar
            // 
            this.lblRCar.AutoSize = true;
            this.lblRCar.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblRCar.Location = new System.Drawing.Point(6, 55);
            this.lblRCar.Name = "lblRCar";
            this.lblRCar.Size = new System.Drawing.Size(28, 13);
            this.lblRCar.TabIndex = 15;
            this.lblRCar.Text = "Car:";
            // 
            // lblRDriver
            // 
            this.lblRDriver.AutoSize = true;
            this.lblRDriver.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblRDriver.Location = new System.Drawing.Point(6, 28);
            this.lblRDriver.Name = "lblRDriver";
            this.lblRDriver.Size = new System.Drawing.Size(84, 13);
            this.lblRDriver.TabIndex = 14;
            this.lblRDriver.Text = "Selected Driver:";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1015, 658);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLeftTrackStop);
            this.Controls.Add(this.btnLeftTrackReset);
            this.Controls.Add(this.btnLeftTrackStart);
            this.Controls.Add(this.gaugeControl2);
            this.Controls.Add(this.gaugeControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "DragNote 1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xpCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.session1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Xpo.XPCollection xpCollection1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Xpo.Session session1;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private DevExpress.XtraGrid.Columns.GridColumn colcar;
        private DevExpress.XtraGrid.Columns.GridColumn colcar_no;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl2;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge digitalGauge2;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent2;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Button btnLeftTrackStart;
        private System.Windows.Forms.Button btnLeftTrackStop;
        private System.Windows.Forms.Timer timLeftTrack;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge z;
        private System.Windows.Forms.Button btnLeftTrackReset;
        private System.IO.Ports.SerialPort spLevy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblLDriver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLCar;
        private System.Windows.Forms.Label lblL_RT;
        private System.Windows.Forms.Label lblL_ET;
        private System.Windows.Forms.Label lblL_Time14;
        private System.Windows.Forms.Button btnLSaveTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblR_RT;
        private System.Windows.Forms.Label lblR_ET;
        private System.Windows.Forms.Label lblR_Time14;
        private System.Windows.Forms.Label lblRCar;
        private System.Windows.Forms.Label lblRDriver;
        private System.Windows.Forms.Label lblL_Id;
        private System.Windows.Forms.Label lblR_Id;
    }
}

