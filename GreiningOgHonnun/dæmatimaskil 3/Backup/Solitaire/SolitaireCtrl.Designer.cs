﻿namespace Solitaire
{
	partial class SolitaireCtrl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( )
		{
			this.SuspendLayout( );
			// 
			// SolitaireCtrl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LimeGreen;
			this.Name = "SolitaireCtrl";
			this.Size = new System.Drawing.Size( 691, 441 );
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.OnPaint );
			this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.OnMouseMove );
			this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler( this.OnDoubleClick );
			this.MouseClick += new System.Windows.Forms.MouseEventHandler( this.OnMouseClick );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.OnMouseDown );
			this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.OnMouseUp );
			this.ResumeLayout( false );

		}

		#endregion
	}
}
