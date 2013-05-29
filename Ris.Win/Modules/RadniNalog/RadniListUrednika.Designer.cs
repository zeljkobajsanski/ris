namespace Rs.Dnevnik.Ris.Win.Modules.RadniNalog
{
    partial class RadniListUrednika
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.radniListUrednikaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ocena1 = new Rs.Dnevnik.Ris.Win.Editors.Ocena();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.radnik1 = new Rs.Dnevnik.Ris.Win.Editors.Radnik();
            this.rubrika1 = new Rs.Dnevnik.Ris.Win.Editors.Rubrika();
            this.publikacija1 = new Rs.Dnevnik.Ris.Win.Editors.Publikacija();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radniListUrednikaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ocena1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radnik1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubrika1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.publikacija1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.memoEdit1);
            this.layoutControl1.Controls.Add(this.ocena1);
            this.layoutControl1.Controls.Add(this.spinEdit1);
            this.layoutControl1.Controls.Add(this.radnik1);
            this.layoutControl1.Controls.Add(this.rubrika1);
            this.layoutControl1.Controls.Add(this.publikacija1);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(392, 383);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // memoEdit1
            // 
            this.memoEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.radniListUrednikaBindingSource, "Napomena", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.memoEdit1.Location = new System.Drawing.Point(75, 156);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(305, 215);
            this.memoEdit1.StyleController = this.layoutControl1;
            this.memoEdit1.TabIndex = 10;
            // 
            // radniListUrednikaBindingSource
            // 
            this.radniListUrednikaBindingSource.DataSource = typeof(Rs.Dnevnik.Ris.Core.Model.RadniListUrednika);
            // 
            // ocena1
            // 
            this.ocena1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.radniListUrednikaBindingSource, "OcenaID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ocena1.EnterMoveNextControl = true;
            this.ocena1.Location = new System.Drawing.Point(75, 132);
            this.ocena1.Name = "ocena1";
            this.ocena1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ocena1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Opis", "Ocena")});
            this.ocena1.Properties.DisplayMember = "Opis";
            this.ocena1.Properties.NullText = "[Unesite ocenu]";
            this.ocena1.Properties.ValueMember = "ID";
            this.ocena1.Size = new System.Drawing.Size(305, 20);
            this.ocena1.StyleController = this.layoutControl1;
            this.ocena1.TabIndex = 9;
            // 
            // spinEdit1
            // 
            this.spinEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.radniListUrednikaBindingSource, "BrojStranice", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.EnterMoveNextControl = true;
            this.spinEdit1.Location = new System.Drawing.Point(75, 108);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Size = new System.Drawing.Size(305, 20);
            this.spinEdit1.StyleController = this.layoutControl1;
            this.spinEdit1.TabIndex = 8;
            // 
            // radnik1
            // 
            this.radnik1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.radniListUrednikaBindingSource, "RadnikID", true));
            this.radnik1.EnterMoveNextControl = true;
            this.radnik1.Location = new System.Drawing.Point(75, 84);
            this.radnik1.Name = "radnik1";
            this.radnik1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.radnik1.Properties.DisplayMember = "ImeIPrezime";
            this.radnik1.Properties.NullText = "[Izaberite radnika]";
            this.radnik1.Properties.ValueMember = "ID";
            this.radnik1.Size = new System.Drawing.Size(305, 20);
            this.radnik1.StyleController = this.layoutControl1;
            this.radnik1.TabIndex = 7;
            // 
            // rubrika1
            // 
            this.rubrika1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.radniListUrednikaBindingSource, "RubrikaID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rubrika1.EnterMoveNextControl = true;
            this.rubrika1.Location = new System.Drawing.Point(75, 60);
            this.rubrika1.Name = "rubrika1";
            this.rubrika1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rubrika1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Naziv", "Rubrika")});
            this.rubrika1.Properties.DisplayMember = "Naziv";
            this.rubrika1.Properties.IdPublikacije = 0;
            this.rubrika1.Properties.NullText = "[Izaberite rubriku]";
            this.rubrika1.Properties.ValueMember = "ID";
            this.rubrika1.Size = new System.Drawing.Size(305, 20);
            this.rubrika1.StyleController = this.layoutControl1;
            this.rubrika1.TabIndex = 6;
            // 
            // publikacija1
            // 
            this.publikacija1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.radniListUrednikaBindingSource, "PublikacijaID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.publikacija1.EnterMoveNextControl = true;
            this.publikacija1.Location = new System.Drawing.Point(75, 36);
            this.publikacija1.Name = "publikacija1";
            this.publikacija1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.publikacija1.Properties.DisplayMember = "Naziv";
            this.publikacija1.Properties.NullText = "[Izaberite publikaciju]";
            this.publikacija1.Properties.ReadOnly = true;
            this.publikacija1.Properties.ValueMember = "ID";
            this.publikacija1.Size = new System.Drawing.Size(305, 20);
            this.publikacija1.StyleController = this.layoutControl1;
            this.publikacija1.TabIndex = 5;
            // 
            // dateEdit1
            // 
            this.dateEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.radniListUrednikaBindingSource, "Datum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(75, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.ReadOnly = true;
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(102, 20);
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
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(392, 383);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateEdit1;
            this.layoutControlItem1.CustomizationFormText = "Datum";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(169, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(169, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(169, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Datum";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.publikacija1;
            this.layoutControlItem2.CustomizationFormText = "Publikacija";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(372, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Publikacija";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.rubrika1;
            this.layoutControlItem3.CustomizationFormText = "Rubrika";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(372, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Rubrika";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.radnik1;
            this.layoutControlItem4.CustomizationFormText = "Radnik";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(372, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Radnik";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.spinEdit1;
            this.layoutControlItem5.CustomizationFormText = "Broj stranice";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(372, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Broj stranice";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ocena1;
            this.layoutControlItem6.CustomizationFormText = "Ocena";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(372, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(372, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Ocena";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem7.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.layoutControlItem7.Control = this.memoEdit1;
            this.layoutControlItem7.CustomizationFormText = "Napomena";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(372, 219);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(372, 219);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(372, 219);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "Napomena";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(60, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(169, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(203, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            this.dxErrorProvider1.DataSource = this.radniListUrednikaBindingSource;
            // 
            // RadniListUrednika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "RadniListUrednika";
            this.Size = new System.Drawing.Size(392, 383);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radniListUrednikaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ocena1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radnik1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rubrika1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.publikacija1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.Windows.Forms.BindingSource radniListUrednikaBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Editors.Publikacija publikacija1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Editors.Rubrika rubrika1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Editors.Radnik radnik1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private Editors.Ocena ocena1;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
