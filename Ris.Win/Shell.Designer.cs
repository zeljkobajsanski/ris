namespace Rs.Dnevnik.Ris.Win
{
    partial class Shell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shell));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNew = new DevExpress.XtraBars.BarButtonItem();
            this.btnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnSektori = new DevExpress.XtraNavBar.NavBarItem();
            this.btnOdeljenja = new DevExpress.XtraNavBar.NavBarItem();
            this.btnRadnici = new DevExpress.XtraNavBar.NavBarItem();
            this.btnPublikacije = new DevExpress.XtraNavBar.NavBarItem();
            this.btnRubrike = new DevExpress.XtraNavBar.NavBarItem();
            this.btnTipoviTekstova = new DevExpress.XtraNavBar.NavBarItem();
            this.btnOcene = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnUnosRadnogNaloga = new DevExpress.XtraNavBar.NavBarItem();
            this.btnPregledRnPoDanima = new DevExpress.XtraNavBar.NavBarItem();
            this.btnPregledRadnihNalogaPoRadnicima = new DevExpress.XtraNavBar.NavBarItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerLeft.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Rs.Dnevnik.Ris.Win.Properties.Resources.newspaper_24x24;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnRefresh,
            this.btnPrint});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1014, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnNew
            // 
            this.btnNew.Caption = "Novi";
            this.btnNew.Glyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.Ribbon_New_16x16;
            this.btnNew.Id = 1;
            this.btnNew.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnNew.LargeGlyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.Ribbon_New_32x32;
            this.btnNew.Name = "btnNew";
            // 
            // btnOpen
            // 
            this.btnOpen.Caption = "Otvori";
            this.btnOpen.Glyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.Ribbon_Open_16x16;
            this.btnOpen.Id = 2;
            this.btnOpen.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O));
            this.btnOpen.LargeGlyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.Ribbon_Open_32x32;
            this.btnOpen.Name = "btnOpen";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Sačuvaj";
            this.btnSave.Glyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.Ribbon_Save_16x16;
            this.btnSave.Id = 3;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.LargeGlyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.Ribbon_Save_32x32;
            this.btnSave.Name = "btnSave";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Osveži";
            this.btnRefresh.Glyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.refresh_16x16;
            this.btnRefresh.Id = 4;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.LargeGlyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources.refresh_32x32;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Štampaj";
            this.btnPrint.Glyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources._007_PrintView_16x16_72;
            this.btnPrint.Id = 5;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.LargeGlyph = global::Rs.Dnevnik.Ris.Win.Properties.Resources._007_PrintView_32x32_72;
            this.btnPrint.Name = "btnPrint";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Datoteka";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnOpen);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPrint);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Dokument";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 736);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1014, 31);
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbon;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerLeft});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerLeft
            // 
            this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerLeft.Controls.Add(this.dockPanel1);
            this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.hideContainerLeft.Location = new System.Drawing.Point(0, 144);
            this.hideContainerLeft.Name = "hideContainerLeft";
            this.hideContainerLeft.Size = new System.Drawing.Size(19, 592);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("e4dda31b-50a9-4640-bedc-2e4ed3b74c1d");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(228, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(228, 592);
            this.dockPanel1.Text = "Meni";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.layoutControl2);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(220, 565);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.navBarControl1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(220, 565);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnUnosRadnogNaloga,
            this.btnPregledRadnihNalogaPoRadnicima,
            this.btnPregledRnPoDanima,
            this.btnSektori,
            this.btnOdeljenja,
            this.btnRadnici,
            this.btnPublikacije,
            this.btnRubrike,
            this.btnTipoviTekstova,
            this.btnOcene});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 216;
            this.navBarControl1.Size = new System.Drawing.Size(216, 561);
            this.navBarControl1.TabIndex = 4;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Šifarnici";
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnSektori),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnOdeljenja),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnRadnici),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnPublikacije),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnRubrike),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnTipoviTekstova),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnOcene)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // btnSektori
            // 
            this.btnSektori.Caption = "Sektori";
            this.btnSektori.Name = "btnSektori";
            // 
            // btnOdeljenja
            // 
            this.btnOdeljenja.Caption = "Odeljenja";
            this.btnOdeljenja.Name = "btnOdeljenja";
            // 
            // btnRadnici
            // 
            this.btnRadnici.Caption = "Radnici";
            this.btnRadnici.Name = "btnRadnici";
            this.btnRadnici.SmallImage = global::Rs.Dnevnik.Ris.Win.Properties.Resources.users_16x16;
            // 
            // btnPublikacije
            // 
            this.btnPublikacije.Caption = "Publikacije";
            this.btnPublikacije.Name = "btnPublikacije";
            this.btnPublikacije.SmallImage = global::Rs.Dnevnik.Ris.Win.Properties.Resources.newspaper_16x16;
            // 
            // btnRubrike
            // 
            this.btnRubrike.Caption = "Rubrike";
            this.btnRubrike.Name = "btnRubrike";
            // 
            // btnTipoviTekstova
            // 
            this.btnTipoviTekstova.Caption = "Tipovi tekstova";
            this.btnTipoviTekstova.Name = "btnTipoviTekstova";
            // 
            // btnOcene
            // 
            this.btnOcene.Caption = "Ocene";
            this.btnOcene.Name = "btnOcene";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Radni nalozi";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnUnosRadnogNaloga),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnPregledRnPoDanima),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnPregledRadnihNalogaPoRadnicima)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // btnUnosRadnogNaloga
            // 
            this.btnUnosRadnogNaloga.Caption = "Unos radnog naloga";
            this.btnUnosRadnogNaloga.Name = "btnUnosRadnogNaloga";
            this.btnUnosRadnogNaloga.SmallImage = global::Rs.Dnevnik.Ris.Win.Properties.Resources.Drafts_16x16;
            // 
            // btnPregledRnPoDanima
            // 
            this.btnPregledRnPoDanima.Caption = "Pregled radnih naloga po danima";
            this.btnPregledRnPoDanima.Name = "btnPregledRnPoDanima";
            this.btnPregledRnPoDanima.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnPregledRnPoDanima.SmallImage")));
            // 
            // btnPregledRadnihNalogaPoRadnicima
            // 
            this.btnPregledRadnihNalogaPoRadnicima.Caption = "Pregled radnih naloga po radnicima";
            this.btnPregledRadnihNalogaPoRadnicima.Name = "btnPregledRadnihNalogaPoRadnicima";
            this.btnPregledRadnihNalogaPoRadnicima.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnPregledRadnihNalogaPoRadnicima.SmallImage")));
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(220, 565);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.navBarControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(220, 565);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Caption = "Operacija u toku";
            this.progressPanel1.CaptionToDescriptionDistance = 4;
            this.progressPanel1.Description = "Molim sačekajte ...";
            this.progressPanel1.Location = new System.Drawing.Point(425, 374);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 66);
            this.progressPanel1.TabIndex = 4;
            this.progressPanel1.Text = "progressPanel1";
            this.progressPanel1.Visible = false;
            // 
            // alertControl1
            // 
            this.alertControl1.AutoFormDelay = 4000;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 767);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.hideContainerLeft);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Shell";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "RIS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerLeft.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnNew;
        private DevExpress.XtraBars.BarButtonItem btnOpen;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem btnPregledRnPoDanima;
        private DevExpress.XtraNavBar.NavBarItem btnPregledRadnihNalogaPoRadnicima;
        private DevExpress.XtraNavBar.NavBarItem btnUnosRadnogNaloga;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraNavBar.NavBarItem btnSektori;
        private DevExpress.XtraNavBar.NavBarItem btnOdeljenja;
        private DevExpress.XtraNavBar.NavBarItem btnRadnici;
        private DevExpress.XtraNavBar.NavBarItem btnPublikacije;
        private DevExpress.XtraNavBar.NavBarItem btnRubrike;
        private DevExpress.XtraNavBar.NavBarItem btnTipoviTekstova;
        private DevExpress.XtraNavBar.NavBarItem btnOcene;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
    }
}