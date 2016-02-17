using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Solitaire.Common
{
	/// <summary>
	/// A simple Exception class to represent when a pile is empty.
	/// </summary>
	public class EmptyPileException : Exception
	{
	}

	/// <summary>
	/// A pile is a generic pile of cards. It is not specific for any kind of
	/// a solitaire, it basically knows where it is located on the screen,
	/// knows how to draw itself, allows adding cards, supports hit-testing etc.
	/// Derived classes then override certain behaviour, for instance if they
	/// would like to control what cards can be added to the pile, they would
	/// override the AddCard(s) function and add their logic there. However, 
	/// certain piles might not want to enforce these rules right away (such
	/// as the regular piles in Klondike, which initially contain random 
	/// cards). Therefore it is possible to create a pile and supply a collection
	/// of initial cards in the constructor.
	/// </summary>
	public class Pile
	{
		#region Member variables
		protected CardCollection m_cards      = null;
		protected Point          m_ptLocation = Point.Empty;
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the location of the pile. The loc
		/// </summary>
		public virtual Point Location 
		{
			get
			{
				return m_ptLocation;
			}
			set
			{
				m_ptLocation = value;

				foreach ( Card c in m_cards )
				{
					c.Location = value;
				}
			}
		}

		/// <summary>
		/// Returns the number of cards in the pile.
		/// </summary>
		public int Count
		{
			get
			{
				return m_cards.Count;
			}
		}

		/// <summary>
		/// Returns the topmost card from the pile, throws an exception if the pile
		/// is empty.
		/// </summary>
		public Card TopCard
		{
			get
			{
				if ( m_cards.Count == 0 )
				{
					throw new EmptyPileException( );
				}
				return m_cards[ m_cards.Count - 1 ];
			}
		}
		#endregion

		#region Constructors
		
		/// <summary>
		/// Constructs a pile from a location and a collection of initial
		/// cards to be placed on the pile.
		/// </summary>
		/// <param name="ptLocation"></param>
		/// <param name="initialCards"></param>
		public Pile( Point ptLocation, CardCollection initialCards )
		{
			// Order is important here, set the cards collection before
			// we set the location since changing our location might
			// result in changing the location of the cards as well...
			m_cards = initialCards;

			Location = ptLocation;
		}

		/// <summary>
		/// It is also possible to create an empty pile, and just supplying
		/// the location.
		/// </summary>
		/// <param name="ptLocation"></param>
		public Pile( Point ptLocation )
			: this( ptLocation, new CardCollection( ) )
		{
		}
		#endregion

		#region Public overridable functions

		/// <summary>
		/// Adds a collection of cards to the pile. The default implementation 
		/// imposes no restrictions on what cards can be added, but this
		/// behaviour can be overridden.
		/// </summary>
		/// <param name="cards"></param>
		/// <returns></returns>
		public virtual bool AddCards( CardCollection cards )
		{
			foreach ( Card c in cards )
			{
				InternalAddCard( c );
				// NOTE: no validation of the card takes place here. Subclasses
				// implement different behaviour according to their own rules.
			}

			return true;
		}

		/// <summary>
		/// Adds just a single card.
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public virtual bool AddCard( Card c )
		{
			InternalAddCard( c );

			return true;
		}

		/// <summary>
		/// Draws the pile to the canvas.
		/// </summary>
		/// <param name="g"></param>
		public virtual void Draw( Graphics g )
		{
			// The general implementation of drawing a pile
			// is to draw a rectangle if the pile is empty (to represent an
			// empty pile graphically), but the topmost card otherwise.

			if ( m_cards.Count == 0 )
			{
				using ( Pen p = new Pen( Color.Black, 1.0f ) )
				{
					g.DrawRectangle( p, this.Location.X, this.Location.Y, Card.WIDTH, Card.HEIGHT );
				}
			}
			else
			{
				Card c = m_cards[ m_cards.Count - 1 ];
				c.Draw( g );
			}
		}

		/// <summary>
		/// Hit-testing: Returns true if the given point is within the bounds of the pile,
		/// or false otherwise.
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		public virtual bool Contains( Point pt )
		{
			// Default implementation simply assumes that the cards
			// are on top of each other, so this implementation is similar to
			// as if there were at least one card in the pile, and we would
			// simply ask this card if it contains the point.
			return ( pt.X >= this.Location.X && pt.X <= this.Location.X + Card.WIDTH )
				&& ( pt.Y >= this.Location.Y && pt.Y <= this.Location.Y + Card.HEIGHT );
		}

		/// <summary>
		/// Returns a collection of cards that correspond to the point given.
		/// PRECONDITION: the point should be within the bounds of this pile!
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		public virtual CardCollection GetCardsToDrag( Point pt )
		{
			System.Diagnostics.Debug.Assert( this.Contains( pt ) );

			// By default, we just return the topmost card:
			CardCollection cards = new CardCollection( );
			cards.Add( TopCard );
			return cards;

		}

		/// <summary>
		/// Removes the topmost cards from the pile.
		/// </summary>
		/// <param name="cards"></param>
		public virtual void RemoveCards( int count )
		{
			m_cards.RemoveRange( m_cards.Count - count, count );
		}
		#endregion

		#region Protected functions

		/// <summary>
		/// When we add a card, we assume that the location of the card
		/// should be the same 
		/// </summary>
		/// <param name="c"></param>
		protected void InternalAddCard( Card c )
		{
			c.Location = this.Location;
			m_cards.Add( c );
		}
		#endregion
	}

	public class PileCollection : List<Pile>
	{
		#region Public functions
		public Pile PileFromPoint( Point pt )
		{
			foreach ( Pile p in this )
			{
				if ( p.Contains( pt ) )
				{
					return p;
				}
			}

			return null;
		}
		#endregion
	}
}
