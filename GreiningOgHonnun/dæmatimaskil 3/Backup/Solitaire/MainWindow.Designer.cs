namespace Solitaire
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip( );
			this.statusStrip1 = new System.Windows.Forms.StatusStrip( );
			this.toolStrip1 = new System.Windows.Forms.ToolStrip( );
			this.m_gameMenuRoot = new System.Windows.Forms.ToolStripMenuItem( );
			this.m_helpMenuRoot = new System.Windows.Forms.ToolStripMenuItem( );
			this.m_helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
			this.m_gameDealMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
			this.m_gameExitMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator( );
			this.m_gameOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator( );
			this.m_gameDeckMenuItem = new System.Windows.Forms.ToolStripMenuItem( );
			this.m_solitaireCtrl = new Solitaire.SolitaireCtrl( );
			this.menuStrip1.SuspendLayout( );
			this.SuspendLayout( );
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.m_gameMenuRoot,
            this.m_helpMenuRoot} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 1117, 24 );
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point( 0, 666 );
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size( 1117, 22 );
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Location = new System.Drawing.Point( 0, 24 );
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size( 1117, 25 );
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// m_gameMenuRoot
			// 
			this.m_gameMenuRoot.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.m_gameDealMenuItem,
            this.toolStripSeparator2,
            this.m_gameDeckMenuItem,
            this.m_gameOptionsMenuItem,
            this.toolStripSeparator1,
            this.m_gameExitMenuItem} );
			this.m_gameMenuRoot.Name = "m_gameMenuRoot";
			this.m_gameMenuRoot.Size = new System.Drawing.Size( 46, 20 );
			this.m_gameMenuRoot.Text = "&Game";
			// 
			// m_helpMenuRoot
			// 
			this.m_helpMenuRoot.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.m_helpAboutMenuItem} );
			this.m_helpMenuRoot.Name = "m_helpMenuRoot";
			this.m_helpMenuRoot.Size = new System.Drawing.Size( 40, 20 );
			this.m_helpMenuRoot.Text = "&Help";
			// 
			// m_helpAboutMenuItem
			// 
			this.m_helpAboutMenuItem.Name = "m_helpAboutMenuItem";
			this.m_helpAboutMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.m_helpAboutMenuItem.Text = "&About";
			this.m_helpAboutMenuItem.Click += new System.EventHandler( this.OnHelpAbout );
			// 
			// m_gameDealMenuItem
			// 
			this.m_gameDealMenuItem.Name = "m_gameDealMenuItem";
			this.m_gameDealMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.m_gameDealMenuItem.Text = "&Deal";
			this.m_gameDealMenuItem.Click += new System.EventHandler( this.OnGameDeal );
			// 
			// m_gameExitMenuItem
			// 
			this.m_gameExitMenuItem.Name = "m_gameExitMenuItem";
			this.m_gameExitMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.m_gameExitMenuItem.Text = "Exit";
			this.m_gameExitMenuItem.Click += new System.EventHandler( this.OnFileExit );
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size( 149, 6 );
			// 
			// m_gameOptionsMenuItem
			// 
			this.m_gameOptionsMenuItem.Name = "m_gameOptionsMenuItem";
			this.m_gameOptionsMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.m_gameOptionsMenuItem.Text = "&Options";
			this.m_gameOptionsMenuItem.Click += new System.EventHandler( this.OnGameOptions );
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size( 149, 6 );
			// 
			// m_gameDeckMenuItem
			// 
			this.m_gameDeckMenuItem.Name = "m_gameDeckMenuItem";
			this.m_gameDeckMenuItem.Size = new System.Drawing.Size( 152, 22 );
			this.m_gameDeckMenuItem.Text = "De&ck...";
			this.m_gameDeckMenuItem.Click += new System.EventHandler( this.OnGameDeck );
			// 
			// m_solitaireCtrl
			// 
			this.m_solitaireCtrl.BackColor = System.Drawing.Color.LimeGreen;
			this.m_solitaireCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_solitaireCtrl.Location = new System.Drawing.Point( 0, 49 );
			this.m_solitaireCtrl.Name = "m_solitaireCtrl";
			this.m_solitaireCtrl.Size = new System.Drawing.Size( 1117, 617 );
			this.m_solitaireCtrl.TabIndex = 3;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 1117, 688 );
			this.Controls.Add( this.m_solitaireCtrl );
			this.Controls.Add( this.toolStrip1 );
			this.Controls.Add( this.statusStrip1 );
			this.Controls.Add( this.menuStrip1 );
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainWindow";
			this.Text = "Solitaire";
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout( );
			this.ResumeLayout( false );
			this.PerformLayout( );

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private SolitaireCtrl m_solitaireCtrl;
		private System.Windows.Forms.ToolStripMenuItem m_gameMenuRoot;
		private System.Windows.Forms.ToolStripMenuItem m_gameDealMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem m_gameExitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_helpMenuRoot;
		private System.Windows.Forms.ToolStripMenuItem m_helpAboutMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_gameOptionsMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem m_gameDeckMenuItem;
	}
}

