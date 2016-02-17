using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Drawing.Imaging;

namespace Solitaire.Common
{
	/// <summary>
	/// Deck represents a typical 52 card deck. Initially it will contain the cards
	/// in order (Hearts from 1 to 13, Spades from 1 to 13 etc.), but the deck
	/// can then be shuffled.
	/// </summary>
	public class Deck
	{
		#region Member variables
		private CardCollection m_cards  = new CardCollection( );
		private ImageManager   m_imgMgr = null;
		#endregion

		#region Properties
		public ImageManager ImageManager
		{
			get
			{
				return m_imgMgr;
			}
		}
		public int Count
		{
			get
			{
				return m_cards.Count;
			}
		}
		#endregion

		#region Constructors
		public Deck( )
			: this( null )
		{
		}

		/// <summary>
		/// Constructor. Creates all the cards and stores them. Cards are initially
		/// created face down. Accepts an (optional) ImageManager.
		/// </summary>
		public Deck( ImageManager imgMgr )
		{
			// Create a default image manager if none is provided:
			if ( imgMgr == null )
			{
				imgMgr = new ImageManager( );
			}
			m_imgMgr = imgMgr;

			// Create all 52 cards:
			Suit[] arrSuits = { Suit.Hearts, Suit.Spades, Suit.Diamonds, Suit.Clubs };
			foreach ( Suit s in arrSuits )
			{
				for ( int i = 1; i <= 13; i++ )
				{
					Card c = new Card( s, i, false, this );

					m_cards.Add( c );
				}
			}
		}
		#endregion

		#region Public functions
		/// <summary>
		/// Shuffles the deck.
		/// </summary>
		public void Shuffle( )
		{
			System.Random rand = new Random( DateTime.Now.Millisecond );

			// We must use a regular for-loop, since we'll be modifying
			// the collection, while a foreach statement is readonly.
			for ( int i = 0; i < m_cards.Count; i++ )
			{
				int r = rand.Next( 0, m_cards.Count );

				// Swap the current card with a random card in the collection:
				Card c = m_cards[ i ];
				m_cards[ i ] = m_cards[ r ];
				m_cards[ r ] = c;
			}
		}

		/// <summary>
		/// Removes the first card and returns it.
		/// </summary>
		/// <returns></returns>
		public Card RemoveNextCard( )
		{
			Card c = m_cards[ 0 ];
			m_cards.RemoveAt( 0 );

			return c;
		}

		/// <summary>
		/// Removes the first count cards and returns them.
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public CardCollection RemoveCards( int count )
		{
			CardCollection cards = new CardCollection( );

			cards.AddRange( m_cards.GetRange( 0, count ) );
			m_cards.RemoveRange( 0, count );

			return cards;
		}
		#endregion
	}
}
