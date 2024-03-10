namespace TibiHouses
{
  partial class Main
  {
    /// <summary>
    /// Variable del diseñador necesaria.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpiar los recursos que se estén usando.
    /// </summary>
    /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>
    /// Método necesario para admitir el Diseñador. No se puede modificar
    /// el contenido de este método con el editor de código.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Fav1");
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Server1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Nodo1");
      System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Nodo2");
      System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Nodo3");
      this.housesList = new System.Windows.Forms.TreeView();
      this.worldList = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnBuscar = new System.Windows.Forms.Button();
      this.chAuctioned = new System.Windows.Forms.CheckBox();
      this.houseImg = new System.Windows.Forms.WebBrowser();
      this.geoupHouseInfo = new System.Windows.Forms.GroupBox();
      this.lblStatusInfo = new System.Windows.Forms.Label();
      this.lblHouseStatus = new System.Windows.Forms.Label();
      this.lblRent = new System.Windows.Forms.Label();
      this.lblSize = new System.Windows.Forms.Label();
      this.lblBeds = new System.Windows.Forms.Label();
      this.radHouses = new System.Windows.Forms.RadioButton();
      this.groupType = new System.Windows.Forms.GroupBox();
      this.radGuildHalls = new System.Windows.Forms.RadioButton();
      this.btnRefreshAll = new System.Windows.Forms.Button();
      this.chServerFav = new System.Windows.Forms.CheckBox();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.tsProgressStatus = new System.Windows.Forms.ToolStripProgressBar();
      this.tsLblLoadStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.timerToolStripReset = new System.Windows.Forms.Timer(this.components);
      this.favoriteList = new System.Windows.Forms.TreeView();
      this.nodeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsBtnFav = new System.Windows.Forms.ToolStripMenuItem();
      this.geoupHouseInfo.SuspendLayout();
      this.groupType.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.nodeMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // housesList
      // 
      this.housesList.Location = new System.Drawing.Point(211, 15);
      this.housesList.Name = "housesList";
      this.housesList.ShowNodeToolTips = true;
      this.housesList.Size = new System.Drawing.Size(236, 405);
      this.housesList.TabIndex = 0;
      this.housesList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.housesList_AfterSelect);
      // 
      // worldList
      // 
      this.worldList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
      this.worldList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.worldList.Enabled = false;
      this.worldList.FormattingEnabled = true;
      this.worldList.Location = new System.Drawing.Point(61, 12);
      this.worldList.Name = "worldList";
      this.worldList.Size = new System.Drawing.Size(121, 21);
      this.worldList.TabIndex = 2;
      this.worldList.SelectedIndexChanged += new System.EventHandler(this.worldList_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Worlds:";
      // 
      // btnBuscar
      // 
      this.btnBuscar.Location = new System.Drawing.Point(18, 184);
      this.btnBuscar.Name = "btnBuscar";
      this.btnBuscar.Size = new System.Drawing.Size(75, 23);
      this.btnBuscar.TabIndex = 4;
      this.btnBuscar.Text = "Buscar";
      this.btnBuscar.UseVisualStyleBackColor = true;
      this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
      // 
      // chAuctioned
      // 
      this.chAuctioned.AutoSize = true;
      this.chAuctioned.Location = new System.Drawing.Point(15, 147);
      this.chAuctioned.Name = "chAuctioned";
      this.chAuctioned.Size = new System.Drawing.Size(113, 17);
      this.chAuctioned.TabIndex = 5;
      this.chAuctioned.Text = "Auctioned Houses";
      this.chAuctioned.UseVisualStyleBackColor = true;
      // 
      // houseImg
      // 
      this.houseImg.IsWebBrowserContextMenuEnabled = false;
      this.houseImg.Location = new System.Drawing.Point(10, 20);
      this.houseImg.MinimumSize = new System.Drawing.Size(20, 20);
      this.houseImg.Name = "houseImg";
      this.houseImg.ScrollBarsEnabled = false;
      this.houseImg.Size = new System.Drawing.Size(150, 150);
      this.houseImg.TabIndex = 6;
      // 
      // geoupHouseInfo
      // 
      this.geoupHouseInfo.Controls.Add(this.lblStatusInfo);
      this.geoupHouseInfo.Controls.Add(this.lblHouseStatus);
      this.geoupHouseInfo.Controls.Add(this.lblRent);
      this.geoupHouseInfo.Controls.Add(this.lblSize);
      this.geoupHouseInfo.Controls.Add(this.lblBeds);
      this.geoupHouseInfo.Controls.Add(this.houseImg);
      this.geoupHouseInfo.Location = new System.Drawing.Point(453, 15);
      this.geoupHouseInfo.Name = "geoupHouseInfo";
      this.geoupHouseInfo.Size = new System.Drawing.Size(296, 405);
      this.geoupHouseInfo.TabIndex = 8;
      this.geoupHouseInfo.TabStop = false;
      this.geoupHouseInfo.Text = "House Info";
      // 
      // lblStatusInfo
      // 
      this.lblStatusInfo.AutoSize = true;
      this.lblStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.lblStatusInfo.Location = new System.Drawing.Point(12, 243);
      this.lblStatusInfo.Name = "lblStatusInfo";
      this.lblStatusInfo.Size = new System.Drawing.Size(0, 17);
      this.lblStatusInfo.TabIndex = 11;
      // 
      // lblHouseStatus
      // 
      this.lblHouseStatus.AutoSize = true;
      this.lblHouseStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.lblHouseStatus.Location = new System.Drawing.Point(10, 226);
      this.lblHouseStatus.Name = "lblHouseStatus";
      this.lblHouseStatus.Size = new System.Drawing.Size(97, 17);
      this.lblHouseStatus.TabIndex = 10;
      this.lblHouseStatus.Text = "House Status:";
      // 
      // lblRent
      // 
      this.lblRent.AutoSize = true;
      this.lblRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.lblRent.Location = new System.Drawing.Point(10, 209);
      this.lblRent.Name = "lblRent";
      this.lblRent.Size = new System.Drawing.Size(42, 17);
      this.lblRent.TabIndex = 9;
      this.lblRent.Text = "Rent:";
      // 
      // lblSize
      // 
      this.lblSize.AutoSize = true;
      this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.lblSize.Location = new System.Drawing.Point(10, 192);
      this.lblSize.Name = "lblSize";
      this.lblSize.Size = new System.Drawing.Size(39, 17);
      this.lblSize.TabIndex = 8;
      this.lblSize.Text = "Size:";
      // 
      // lblBeds
      // 
      this.lblBeds.AutoSize = true;
      this.lblBeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.lblBeds.Location = new System.Drawing.Point(10, 175);
      this.lblBeds.Name = "lblBeds";
      this.lblBeds.Size = new System.Drawing.Size(44, 17);
      this.lblBeds.TabIndex = 7;
      this.lblBeds.Text = "Beds:";
      // 
      // radHouses
      // 
      this.radHouses.AutoSize = true;
      this.radHouses.Checked = true;
      this.radHouses.Location = new System.Drawing.Point(6, 19);
      this.radHouses.Name = "radHouses";
      this.radHouses.Size = new System.Drawing.Size(61, 17);
      this.radHouses.TabIndex = 9;
      this.radHouses.TabStop = true;
      this.radHouses.Text = "Houses";
      this.radHouses.UseVisualStyleBackColor = true;
      // 
      // groupType
      // 
      this.groupType.Controls.Add(this.radGuildHalls);
      this.groupType.Controls.Add(this.radHouses);
      this.groupType.Location = new System.Drawing.Point(12, 70);
      this.groupType.Name = "groupType";
      this.groupType.Size = new System.Drawing.Size(116, 71);
      this.groupType.TabIndex = 10;
      this.groupType.TabStop = false;
      this.groupType.Text = "Tipo";
      // 
      // radGuildHalls
      // 
      this.radGuildHalls.AutoSize = true;
      this.radGuildHalls.Location = new System.Drawing.Point(6, 42);
      this.radGuildHalls.Name = "radGuildHalls";
      this.radGuildHalls.Size = new System.Drawing.Size(75, 17);
      this.radGuildHalls.TabIndex = 10;
      this.radGuildHalls.Text = "Guild Halls";
      this.radGuildHalls.UseVisualStyleBackColor = true;
      // 
      // btnRefreshAll
      // 
      this.btnRefreshAll.Location = new System.Drawing.Point(99, 184);
      this.btnRefreshAll.Name = "btnRefreshAll";
      this.btnRefreshAll.Size = new System.Drawing.Size(75, 23);
      this.btnRefreshAll.TabIndex = 11;
      this.btnRefreshAll.Text = "Actualizar Todo";
      this.btnRefreshAll.UseVisualStyleBackColor = true;
      this.btnRefreshAll.Click += new System.EventHandler(this.btnRefreshAll_Click);
      // 
      // chServerFav
      // 
      this.chServerFav.AutoSize = true;
      this.chServerFav.Location = new System.Drawing.Point(61, 39);
      this.chServerFav.Name = "chServerFav";
      this.chServerFav.Size = new System.Drawing.Size(98, 17);
      this.chServerFav.TabIndex = 11;
      this.chServerFav.Text = "Server Favorito";
      this.chServerFav.UseVisualStyleBackColor = true;
      this.chServerFav.CheckedChanged += new System.EventHandler(this.chServerFav_CheckedChanged);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressStatus,
            this.tsLblLoadStatus});
      this.statusStrip1.Location = new System.Drawing.Point(0, 515);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(773, 22);
      this.statusStrip1.TabIndex = 12;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // tsProgressStatus
      // 
      this.tsProgressStatus.Name = "tsProgressStatus";
      this.tsProgressStatus.Size = new System.Drawing.Size(100, 16);
      // 
      // tsLblLoadStatus
      // 
      this.tsLblLoadStatus.Name = "tsLblLoadStatus";
      this.tsLblLoadStatus.Size = new System.Drawing.Size(27, 17);
      this.tsLblLoadStatus.Text = "Test";
      // 
      // timerToolStripReset
      // 
      this.timerToolStripReset.Interval = 2000;
      this.timerToolStripReset.Tick += new System.EventHandler(this.timerToolStripReset_Tick);
      // 
      // favoriteList
      // 
      this.favoriteList.Location = new System.Drawing.Point(12, 241);
      this.favoriteList.Name = "favoriteList";
      treeNode1.Name = "Nodo4";
      treeNode1.Text = "Fav1";
      treeNode2.Name = "Nodo0";
      treeNode2.Text = "Server1";
      treeNode3.Name = "Nodo1";
      treeNode3.Text = "Nodo1";
      treeNode4.Name = "Nodo2";
      treeNode4.Text = "Nodo2";
      treeNode5.Name = "Nodo3";
      treeNode5.Text = "Nodo3";
      this.favoriteList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
      this.favoriteList.Size = new System.Drawing.Size(147, 179);
      this.favoriteList.TabIndex = 13;
      this.favoriteList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.housesList_AfterSelect);
      // 
      // nodeMenuStrip
      // 
      this.nodeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnFav});
      this.nodeMenuStrip.Name = "nodeMenuStrip";
      this.nodeMenuStrip.Size = new System.Drawing.Size(181, 48);
      // 
      // tsBtnFav
      // 
      this.tsBtnFav.Name = "tsBtnFav";
      this.tsBtnFav.Size = new System.Drawing.Size(180, 22);
      this.tsBtnFav.Text = "Favorito";
      this.tsBtnFav.Click += new System.EventHandler(this.tsBtnFav_Click);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(773, 537);
      this.Controls.Add(this.favoriteList);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.chServerFav);
      this.Controls.Add(this.btnRefreshAll);
      this.Controls.Add(this.groupType);
      this.Controls.Add(this.geoupHouseInfo);
      this.Controls.Add(this.chAuctioned);
      this.Controls.Add(this.btnBuscar);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.worldList);
      this.Controls.Add(this.housesList);
      this.Name = "Main";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Tibia Houses";
      this.Load += new System.EventHandler(this.Main_Load);
      this.geoupHouseInfo.ResumeLayout(false);
      this.geoupHouseInfo.PerformLayout();
      this.groupType.ResumeLayout(false);
      this.groupType.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.nodeMenuStrip.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView housesList;
    private System.Windows.Forms.ComboBox worldList;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnBuscar;
    private System.Windows.Forms.CheckBox chAuctioned;
    private System.Windows.Forms.WebBrowser houseImg;
    private System.Windows.Forms.GroupBox geoupHouseInfo;
    private System.Windows.Forms.Label lblHouseStatus;
    private System.Windows.Forms.Label lblRent;
    private System.Windows.Forms.Label lblSize;
    private System.Windows.Forms.Label lblBeds;
    private System.Windows.Forms.Label lblStatusInfo;
    private System.Windows.Forms.RadioButton radHouses;
    private System.Windows.Forms.GroupBox groupType;
    private System.Windows.Forms.RadioButton radGuildHalls;
    private System.Windows.Forms.Button btnRefreshAll;
    private System.Windows.Forms.CheckBox chServerFav;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel tsLblLoadStatus;
    private System.Windows.Forms.ToolStripProgressBar tsProgressStatus;
    private System.Windows.Forms.Timer timerToolStripReset;
    private System.Windows.Forms.TreeView favoriteList;
    private System.Windows.Forms.ContextMenuStrip nodeMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem tsBtnFav;
  }
}

