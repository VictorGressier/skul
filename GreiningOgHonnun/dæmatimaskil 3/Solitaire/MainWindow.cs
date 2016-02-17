using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Solitaire
{
	public partial class MainWindow : Form
	{
		public MainWindow( )
		{
			InitializeComponent( );

			// TODO: Load all classes which implement the ISolitaire interface, and 
			// plug them into the menu!

			Solitaire.Solitaires.Klondike.KlondikeController c = new Solitaire.Solitaires.Klondike.KlondikeController( );

			m_solitaireCtrl.SolitaireController = c;
		}

		private void OnGameDeal( object sender, EventArgs e )
		{
			m_solitaireCtrl.SolitaireController.Deal( );
			m_solitaireCtrl.Invalidate( );
		}

		private void OnGameDeck( object sender, EventArgs e )
		{
			DeckDialog dlg = new DeckDialog( );

			if ( dlg.ShowDialog( ) == DialogResult.OK )
			{
				// TODO: save the current deck,
				// notify the image manager,
				// and redraw!
				m_solitaireCtrl.Invalidate( );
			}
		}

		private void OnGameOptions( object sender, EventArgs e )
		{
			m_solitaireCtrl.SolitaireController.ShowOptions( );
		}

		private void OnFileExit( object sender, EventArgs e )
		{
			this.Close( );
		}

		private void OnHelpAbout( object sender, EventArgs e )
		{
			AboutDialog dlg = new AboutDialog( );
			dlg.ShowDialog( );
		}
	}
}
