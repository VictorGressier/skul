using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Solitaire.Common;

namespace Solitaire.Solitaires.Klondike
{
	/// <summary>
	/// KlondikeController is the central class in the solitaire Klondike. 
	/// It controls everything that happens, and contains some of the logic.
	/// Most logic is then buried in other classes such as KlondikeFlatPile,
	/// which controls what cards can be added to the flat piles used here,
	/// and SuitPile which controls what cards can be added to the suit piles.
	/// The table will look like this initially:
	/// (diagram drawn using http://www.codeproject.com/KB/applications/codeplotterremoded.aspx)
	/// 
	//{{DIAGRAM_START
	//
	//: Klondike table setup
	//
	// .------. .------.          .------. .------. .------. .------.
	// |Deck  | |Dealt |          |Suit  | |Suit  | |Suit  | |Suit  |
	// |pile  | |pile  |          |pile 1| |pile 2| |pile 3| |pile 4|
	// |      | |      |          |      | |      | |      | |      |
	// |      | |      |          |      | |      | |      | |      |
	// |      | |      |          |      | |      | |      | |      |
	// ·------· ·------·          ·------· ·------· ·------· ·------·
	//
	//
	// .------. .------. .------. .------. .------. .------. .------.
	// |Flat  | |Flat  | |Flat  | |Flat  | |Flat  | |Flat  | |Flat  |
	// |pile 1| |pile 2| |pile 3| |pile 4| |pile 5| |pile 6| |pile 7|
	// |      | |      | |      | |      | |      | |      | |      |
	// |      | |      | |      | |      | |      | |      | |      |
	// ·------· ·------· ·------· ·------· ·------· ·------· ·------·
	//}}DIAGRAM_END
	/// </summary>
	public class KlondikeController : ISolitaireController
	{
		#region Constants
		private const int MARGIN_IN_PIXELS = 25;
		#endregion

		#region Member variables

		/// <summary>
		/// The deck we use. Initially it contains all 52 cards, these are then
		/// all removed from the deck and stored in the piles.
		/// </summary>
		protected Deck              m_deck = null;

		/// <summary>
		/// A collection of all piles, even those which are also stored
		/// in separate member variables.
		/// </summary>
		protected PileCollection    m_piles = null;

		/// <summary>
		/// The 4 piles in the top right corner of the window,
		/// which are empty in the beginning, and then later will contain
		/// separate suits.
		/// </summary>
		protected PileCollection    m_suitPiles = null;

		/// <summary>
		/// All 7 piles on the table.
		/// </summary>
		protected PileCollection    m_flatPiles = null;

		/// <summary>
		/// The pile in the upper left corner, contains initially all
		/// cards which are not dealt to the flat piles.
		/// </summary>
		protected KlondikeDeckPile  m_deckPile  = null;

		/// <summary>
		/// The pile next to the deck pile; contains all cards which have
		/// already been dealt from the deck pile and are ready to be
		/// placed on any other pile (flat pile or suit pile).
		/// </summary>
		protected KlondikeDealtPile m_dealtPile  = null;

		/// <summary>
		/// A reference to the pile which cards are being dragged from.
		/// This is necessary so we can remove the cards from this very
		/// pile in case the drag'n'drop operation turns out to be 
		/// successful.
		/// </summary>
		protected Pile              m_pileDrag  = null;
		#endregion

		#region Constructors
		public KlondikeController( )
		{
			SetUpBoard( );
		}
		#endregion

		#region Protected functions
		protected void CreateSuitPiles( )
		{
			// Suit piles start in the 4th column, so we need space
			// for the left margin, and 3 cards before the first pile.
			int nStartLeft = MARGIN_IN_PIXELS + ( 3 * ( Card.WIDTH + MARGIN_IN_PIXELS ) );

			// 4 suits, so 4 iterations in the loop:
			for ( int i = 0; i < 4; i++ )
			{
				// The suit piles are located in the topmost row. So we only 
				// need to make room for the top margin at the top
				Point pt = new Point( nStartLeft + ( i * ( Card.WIDTH + MARGIN_IN_PIXELS ) ), MARGIN_IN_PIXELS );
				SuitPile suitPile = new SuitPile( pt );

				// Add this suit pile both to our list of suit piles,
				// as well as to the list of all piles:
				m_suitPiles.Add( suitPile );
				m_piles.Add( suitPile );
			}
		}

		protected void CreateFlatPiles( )
		{
			// The flat piles are in the second row, meaning that we must
			// make room for the top margin as well as a single card height,
			// plus the margin between first and second rows.
			int nTopLocation = MARGIN_IN_PIXELS + ( Card.HEIGHT + MARGIN_IN_PIXELS );

			// Create all the flat piles:
			for ( int i = 0; i < 7; i++ )
			{
				// Draw the cards first from the deck. Note that technically 
				// this isn't done according to the rules of the game, usually
				// the first line is laid out completely first, therefore 
				// adding a card to every pile before the second line is laid
				// down. This implementation however will finish each pile 
				// before the next one is started.
				CardCollection cards = new CardCollection( );
				for ( int k = 0; k < ( i + 1 ); k++ )
				{
					Card c = m_deck.RemoveNextCard( );

					// Is this the topmost card in the pile?
					c.FaceUp = ( k == i );

					cards.Add( c );
				}

				Point            ptLocation = new Point( MARGIN_IN_PIXELS + ( i * ( Card.WIDTH + MARGIN_IN_PIXELS ) ), nTopLocation );
				KlondikeFlatPile flatPile   = new KlondikeFlatPile( ptLocation, cards );
				flatPile.Location = ptLocation;

				m_piles.Add( flatPile );
				m_flatPiles.Add( flatPile );
			}
		}

		/// <summary>
		/// Creates the pile in the upper left corner of the window, the one which
		/// stores the undealt cards.
		/// </summary>
		protected void CreateDeckPile( )
		{
			// 28 cards go to the flat piles (7 + 6 + 5 + 4 + 3 + 2 + 1),
			// leaving 24 for us:
			CardCollection closedCards = m_deck.RemoveCards( 24 );
			Point pt   = new Point( MARGIN_IN_PIXELS, MARGIN_IN_PIXELS );
			m_deckPile = new KlondikeDeckPile( pt, closedCards );

			m_piles.Add( m_deckPile );
		}

		/// <summary>
		/// Creates the pile of dealt cards.
		/// </summary>
		protected void CreateDealtPile( )
		{
			Point pt = new Point( MARGIN_IN_PIXELS + Card.WIDTH + MARGIN_IN_PIXELS, MARGIN_IN_PIXELS );
			m_dealtPile = new KlondikeDealtPile( pt );

			m_piles.Add( m_dealtPile );
		}

		#endregion

		#region ISolitaireController Members

		CardCollection ISolitaireController.StartDragging( Point pt )
		{
			// Find a pile that corresponds to the given point:
			m_pileDrag = m_piles.PileFromPoint( pt );
			if ( m_pileDrag != null )
			{
				// The pile might or might not support drag'n'drop.
				// We actually don't care much about that.
				return m_pileDrag.GetCardsToDrag( pt );
			}
			return null;
		}

		bool ISolitaireController.EndDragging( CardCollection cards, Point pt )
		{
			// Find the destination pile:
			Pile p = m_piles.PileFromPoint( pt );

			// We don't support dragging cards from a pile onto itself:
			if (   p != null 
				&& p != m_pileDrag )
			{
				// Check if the pile allows adding these cards:
				bool bCanAdd = p.AddCards( cards );
				if ( bCanAdd )
				{
					// If operation was successful, we must remove the cards
					// from the source pile since they're now a part of the 
					// destination pile.
					m_pileDrag.RemoveCards( cards.Count );

					CheckIfCompleted( );
				}

				return bCanAdd;
			}

			// Remove the reference to the drag pile, just in case...
			m_pileDrag = null;

			return false;
		}

		void ISolitaireController.DoubleClick( Point pt )
		{
			Pile p = m_piles.PileFromPoint( pt );
			if ( p != null )
			{
				// Doubleclicking on an empty pile should have no effect:
				if ( p.Count > 0 )
				{
					// Found a pile that was doubleclicked, lets check if we 
					// can move the topmost card from that pile to any of the
					// suit piles.
					Card c = p.TopCard;

					// Only allow double-click on cards which are face up:
					if ( c.FaceUp )
					{
						foreach ( Pile suitPile in m_suitPiles )
						{
							if ( suitPile.AddCard( c ) )
							{
								// Since the card has been moved to the suit
								// pile, we remove it from its original pile:
								p.RemoveCards( 1 );

								// This might result in the solitaire being
								// completed:
								CheckIfCompleted( );

								break;
							}
						}
					}
				}
			}
		}

		void ISolitaireController.Click( Point pt )
		{
			// Check if the deckpile has been clicked, this is
			// the only pile which supports clicking. Other piles
			// only allow using drag'n'drop
			if ( m_deckPile.Contains( pt ) )
			{
				if ( m_deckPile.Count == 0 )
				{
					// Take all the cards from the dealt pile,
					// and move them back to the deck pile:
					CardCollection dealtCards = m_dealtPile.RemoveAllCards( );
					dealtCards.Reverse( );
					dealtCards.SetFaceUp( false );
					m_deckPile.Cards = dealtCards;

				}
				else
				{
					// Draw X many cards from the closed pile, turn them around
					// and place them on the open pile:
					for ( int i = 0; i < 3; i++ )
					{
						if ( m_deckPile.Count > 0 )
						{
							Card c = m_deckPile.TopCard;
							c.FaceUp = true;
							m_dealtPile.AddCard( c );
							m_deckPile.RemoveCards( 1 );
						}
					}
				}

				CheckIfCompleted( );
			}
		}

		void ISolitaireController.Draw( Graphics g )
		{
			foreach ( Pile p in m_piles )
			{
				p.Draw( g );
			}
		}

		void ISolitaireController.Deal( )
		{
			SetUpBoard( );
		}

		void ISolitaireController.ShowOptions( )
		{
			KlondikeOptionsDialog dlg = new KlondikeOptionsDialog( );

			if ( dlg.ShowDialog( ) == System.Windows.Forms.DialogResult.OK )
			{
				// TODO:

			}
		}

		#endregion

		#region Protected functions

		/// <summary>
		/// CheckIfCompleted
		/// </summary>
		protected void CheckIfCompleted( )
		{
			bool bWon = true;
			foreach ( Pile p in m_suitPiles )
			{
				if ( p.Count != 13 )
				{
					bWon = false;
					break;
				}
			}

			// TODO: if possible, also check if we've lost,
			// i.e. if we cannot make any more moves.

			if ( bWon )
			{
				// Baaad, we should be UI independent!
				System.Windows.Forms.MessageBox.Show( "Kapallinn gekk upp!!!" );
				return;
			}
		}

		/// <summary>
		/// Creates all the piles, puts all the cards in their
		/// correct places, and sets everything up nicely so 
		/// we can start a new game.
		/// </summary>
		protected void SetUpBoard( )
		{
			m_deck = new Deck( );

			m_piles = new PileCollection( );
			m_suitPiles = new PileCollection( );
			m_flatPiles = new PileCollection( );

			// Comment out if we want a consistent deck!
			m_deck.Shuffle( );

			CreateSuitPiles( );
			CreateFlatPiles( );
			CreateDeckPile( );
			CreateDealtPile( );
		}
		#endregion
	}
}
