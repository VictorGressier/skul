using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Solitaire.Common
{
	/// <summary>
	///  Suit represents all possible suits in a deck of cards.
	/// </summary>
	public enum Suit
	{
		Hearts,
		Spades,
		Diamonds,
		Clubs
	}

	/// <summary>
	/// Card represents a single card. It knows how to draw itself, and provides
	/// a few other services (hit-testing etc.)
	/// </summary>
	public class Card
	{
		#region Constants
		// TODO: these values will probably
		// depend on the size of the cards!
		public const int WIDTH  = 90;
		public const int HEIGHT = 135;
		#endregion

		#region Member variables
		// Remember the deck which we're a part of, since it 
		// gives us access to the images and other stuff:
		private Deck  m_deck       = null;

		// This variable is only used during dragging, to 
		// support going back to the previous place if the 
		// drag isn't successful:
		private Point m_ptPrevious = Point.Empty;

		/// <summary>
		/// The rank in question. This could possibly
		/// be an enum, but since we use an int this must
		/// be an explicit member variable, since we validate
		/// the rank in the setter.
		/// </summary>
		private int m_nRank = 1;
		#endregion

		#region Properties
		public int Rank
		{
			get
			{
				return m_nRank;
			}
			set
			{
				if ( value < 1 )
				{
					value = 1;
				}
				else if ( value > 13 )
				{
					value = 13;
				}
				m_nRank = value;
			}
		}
		public Suit Suit { get; set; }
		public bool FaceUp { get; set; }
		public Point Location{ get; set; }
		#endregion

		#region Constructors
		public Card( Suit suit, int rank )
			: this( suit, rank, false, null )
		{
		}

		public Card( Suit suit, int rank, bool bFaceUp, Deck d )
		{
			this.Suit     = suit;
			this.FaceUp   = bFaceUp;
			m_deck        = d;
			this.Location = Point.Empty;
			this.Rank     = rank;
		}
		#endregion

		#region Public functions
		/// <summary>
		/// Draws the card on the canvas. What picture will be drawn depends on
		/// wether the cards faces up or down.
		/// </summary>
		/// <param name="g"></param>
		public void Draw( Graphics g )
		{
			if ( this.FaceUp )
			{
				// Defensive, the image might not have been loaded properly,
				// and in that case we draw a more simple representation of
				// the card:
				Image img = m_deck.ImageManager.CurrentTheme.GetCardImage( this.Suit, this.Rank );
				if ( img != null )
				{
					g.DrawImage( img, this.Location.X, this.Location.Y, Card.WIDTH, Card.HEIGHT );
				}
				else
				{
					// TODO: draw an ASCII card!!!
				}
			}
			else
			{
				Image img = m_deck.ImageManager.CurrentTheme.CardBackground;
				if ( img != null )
				{
					g.DrawImage( img, this.Location.X, this.Location.Y, Card.WIDTH, Card.HEIGHT );
				}
			}
		}

		/// <summary>
		/// Returns true if the given point is contained within the card.
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		public bool Contains( Point pt )
		{
			if ( pt.X >= this.Location.X
				&& pt.X <= ( this.Location.X + WIDTH )
				&& pt.Y >= this.Location.Y
				&& pt.Y <= ( this.Location.Y + HEIGHT ) )
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// This function should get called when the cards starts to be dragged.
		/// </summary>
		public void StartDragging( )
		{
			// We use this opportunity to remember the current location of the card,
			// so we can restore it in case the dragging operation will not be 
			// completed.
			m_ptPrevious = this.Location;
		}

		/// <summary>
		/// Should get called if the dragging operation is cancelled.
		/// </summary>
		public void RestoreLocation( )
		{
			this.Location = m_ptPrevious;
		}

		/// <summary>
		/// Returns true if this is a black card (Clubs or Spades),
		/// false otherwise.
		/// </summary>
		/// <returns></returns>
		public bool IsBlack( )
		{
			return this.Suit == Suit.Clubs || this.Suit == Suit.Spades;
		}

		/// <summary>
		/// Returns true if this is a red card (Hearts or Diamonds),
		/// false otherwise.
		/// </summary>
		/// <returns></returns>
		public bool IsRed( )
		{
			return this.Suit == Suit.Hearts || this.Suit == Suit.Diamonds;
		}

		/// <summary>
		/// Returns true if the color of the current card is the opposite
		/// color of the other card. Red and black are considered opposite
		/// colors in this regard.
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool IsOppositeColor( Card other )
		{
			return ( this.IsBlack( ) && other.IsRed( ) )
				|| ( this.IsRed( ) && other.IsBlack( ) );
		}
		#endregion
	}
}