using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Solitaire.Common;

namespace Solitaire
{
	/// <summary>
	/// SolitaireCtrl is the window (would probably be called Panel in Java) that
	/// takes care of drawing the solitaire, and receiving interaction from the
	/// user. It should know literally nothing about what type of solitaire it
	/// is dealing with, except that it is someone who implements the
	/// ISolitaireController interface.
	/// </summary>
	public partial class SolitaireCtrl : UserControl
	{
		#region Member variables
		private ISolitaireController m_controller   = null;
		private CardCollection       m_draggedCards = null;
		private Point                m_lastPoint    = Point.Empty;
		private ImageManager         m_imageManager = new ImageManager( );
		#endregion

		#region Constructor
		public SolitaireCtrl( )
		{
			InitializeComponent( );

			// Added to avoid flicker during painting. This is necessary
			// because we tend to repaint the window during mouse move
			// for instance.
			SetStyle( ControlStyles.DoubleBuffer, true );
			SetStyle( ControlStyles.UserPaint, true );
			SetStyle( ControlStyles.AllPaintingInWmPaint, true );
		}
		#endregion

		#region Properties
		public ISolitaireController SolitaireController
		{
			get
			{
				return m_controller;
			}
			set
			{
				m_controller = value;
			}
		}
		#endregion

		#region Event handlers
		private void OnDoubleClick( object sender, MouseEventArgs e )
		{
			if ( m_controller != null )
			{
				// Point pt = new Point( e.X, e.Y );
				m_controller.DoubleClick( e.Location );

				// Ensure that the MouseUp event won't interfere with this one:
				m_draggedCards = null;

				this.Invalidate( );
			}
		}

		private void OnMouseClick( object sender, MouseEventArgs e )
		{
			if ( m_controller != null )
			{
				m_controller.Click( e.Location );

				this.Invalidate( );
			}
		}

		private void OnMouseDown( object sender, MouseEventArgs e )
		{
			if ( m_controller != null )
			{
				m_lastPoint = e.Location;

				m_draggedCards = m_controller.StartDragging( m_lastPoint );
				if ( m_draggedCards != null )
				{
					m_draggedCards.StartDragging( );
					this.Capture = true;

					this.Invalidate( );
				}
			}
		}

		private void OnMouseMove( object sender, MouseEventArgs e )
		{
			if ( m_controller != null )
			{
				if ( this.Capture )
				{
					if ( m_draggedCards != null )
					{
						// Inform the dragged cards about their new location:
						Point pt = e.Location;
						int xDiff = pt.X - m_lastPoint.X;
						int yDiff = pt.Y - m_lastPoint.Y;
						m_draggedCards.UpdateLocation( xDiff, yDiff );
						m_lastPoint = pt;

						this.Invalidate( );
					}
				}
			}
		}

		private void OnMouseUp( object sender, MouseEventArgs e )
		{
			if ( m_controller != null )
			{
				if ( m_draggedCards != null )
				{
					Point pt = new Point( e.X, e.Y );
					if ( !m_controller.EndDragging( m_draggedCards, pt ) )
					{
						m_draggedCards.RestoreLocation( );
					}

					m_draggedCards = null;

					this.Invalidate( );
				}
			}
		}

		private void OnPaint( object sender, PaintEventArgs e )
		{
			//Image bkgImg = m_imageManager.CurrentTheme.WindowBackground;
			//if ( bkgImg != null )
			//{
			//    e.Graphics.DrawImage( bkgImg, 0, 0 );
			//}

			if ( m_controller != null )
			{
				m_controller.Draw( e.Graphics );
			}

			// Paint any dragging cards afterwards, to ensure they're
			// drawn on top:
			if ( m_draggedCards != null )
			{
				m_draggedCards.Draw( e.Graphics );
			}
		}
		#endregion
	}
}