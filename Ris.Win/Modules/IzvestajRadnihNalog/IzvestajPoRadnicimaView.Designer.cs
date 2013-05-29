namespace Rs.Dnevnik.Ris.Win.Modules.IzvestajRadnihNalog
{
    partial class IzvestajPoRadnicimaView
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.publikacija1 = new Rs.Dnevnik.Ris.Win.Editors.Publikacija();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.ostvarenjejRadnogNalogaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldRadnikID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldRadnik1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTipTekstaID1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTipTeksta1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDatum1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldBrojTekstova1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.f = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnPrikazi = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.publikacija1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ostvarenjejRadnogNalogaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrikazi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.publikacija1);
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.dateEdit2);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(666, 405, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(934, 603);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // publikacija1
            // 
            this.publikacija1.EnterMoveNextControl = true;
            this.publikacija1.Location = new System.Drawing.Point(68, 12);
            this.publikacija1.Name = "publikacija1";
            this.publikacija1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.publikacija1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Naziv", "Publikacija")});
            this.publikacija1.Properties.DisplayMember = "Naziv";
            this.publikacija1.Properties.NullText = "[Izaberite publikaciju]";
            this.publikacija1.Properties.ValueMember = "ID";
            this.publikacija1.Size = new System.Drawing.Size(268, 20);
            this.publikacija1.StyleController = this.layoutControl1;
            this.publikacija1.TabIndex = 8;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.ostvarenjejRadnogNalogaBindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldRadnikID1,
            this.fieldRadnik1,
            this.fieldTipTekstaID1,
            this.fieldTipTeksta1,
            this.fieldDatum1,
            this.fieldBrojTekstova1});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 94);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(910, 497);
            this.pivotGridControl1.TabIndex = 7;
            // 
            // ostvarenjejRadnogNalogaBindingSource
            // 
            this.ostvarenjejRadnogNalogaBindingSource.DataSource = typeof(Rs.Dnevnik.Ris.Core.Model.OstvarenjejRadnogNaloga);
            // 
            // fieldRadnikID1
            // 
            this.fieldRadnikID1.AreaIndex = 0;
            this.fieldRadnikID1.Caption = "Radnik ID";
            this.fieldRadnikID1.FieldName = "RadnikID";
            this.fieldRadnikID1.Name = "fieldRadnikID1";
            // 
            // fieldRadnik1
            // 
            this.fieldRadnik1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldRadnik1.AreaIndex = 0;
            this.fieldRadnik1.Caption = "Radnik";
            this.fieldRadnik1.FieldName = "Radnik";
            this.fieldRadnik1.Name = "fieldRadnik1";
            // 
            // fieldTipTekstaID1
            // 
            this.fieldTipTekstaID1.AreaIndex = 1;
            this.fieldTipTekstaID1.Caption = "Tip Teksta ID";
            this.fieldTipTekstaID1.FieldName = "TipTekstaID";
            this.fieldTipTekstaID1.Name = "fieldTipTekstaID1";
            // 
            // fieldTipTeksta1
            // 
            this.fieldTipTeksta1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldTipTeksta1.AreaIndex = 0;
            this.fieldTipTeksta1.Caption = "Tip Teksta";
            this.fieldTipTeksta1.FieldName = "TipTeksta";
            this.fieldTipTeksta1.Name = "fieldTipTeksta1";
            // 
            // fieldDatum1
            // 
            this.fieldDatum1.AreaIndex = 2;
            this.fieldDatum1.Caption = "Datum";
            this.fieldDatum1.FieldName = "Datum";
            this.fieldDatum1.Name = "fieldDatum1";
            // 
            // fieldBrojTekstova1
            // 
            this.fieldBrojTekstova1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldBrojTekstova1.AreaIndex = 0;
            this.fieldBrojTekstova1.Caption = "Broj Tekstova";
            this.fieldBrojTekstova1.FieldName = "BrojTekstova";
            this.fieldBrojTekstova1.Name = "fieldBrojTekstova1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::Rs.Dnevnik.Ris.Win.Properties.Resources.prikazi;
            this.simpleButton1.Location = new System.Drawing.Point(256, 60);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 30);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Prikaži";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(229, 36);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(107, 20);
            this.dateEdit2.StyleController = this.layoutControl1;
            this.dateEdit2.TabIndex = 5;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(68, 36);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(101, 20);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.f,
            this.btnPrikazi,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(934, 603);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateEdit1;
            this.layoutControlItem1.CustomizationFormText = "Od datuma";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(161, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(161, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(161, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Od datuma";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateEdit2;
            this.layoutControlItem2.CustomizationFormText = "do";
            this.layoutControlItem2.Location = new System.Drawing.Point(161, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(167, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(167, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "do";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.pivotGridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(914, 501);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // f
            // 
            this.f.AllowHotTrack = false;
            this.f.CustomizationFormText = "f";
            this.f.Location = new System.Drawing.Point(328, 0);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(586, 82);
            this.f.Text = "f";
            this.f.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Control = this.simpleButton1;
            this.btnPrikazi.CustomizationFormText = "ffffffff";
            this.btnPrikazi.Location = new System.Drawing.Point(244, 48);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(84, 34);
            this.btnPrikazi.Text = "btnPrikazi";
            this.btnPrikazi.TextSize = new System.Drawing.Size(0, 0);
            this.btnPrikazi.TextToControlDistance = 0;
            this.btnPrikazi.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(161, 34);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(161, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(83, 34);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.publikacija1;
            this.layoutControlItem3.CustomizationFormText = "Publkacija";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(328, 24);
            this.layoutControlItem3.Text = "Publikacija";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(53, 13);
            // 
            // IzvestajPoRadnicimaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 603);
            this.Controls.Add(this.layoutControl1);
            this.Name = "IzvestajPoRadnicimaView";
            this.Text = "Izveštaj radnih naloga po radnicima";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.publikacija1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ostvarenjejRadnogNalogaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrikazi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private System.Windows.Forms.BindingSource ostvarenjejRadnogNalogaBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldRadnikID1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldRadnik1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTipTekstaID1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTipTeksta1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDatum1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldBrojTekstova1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem btnPrikazi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem f;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private Editors.Publikacija publikacija1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}