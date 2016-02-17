using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Solitaire.Common
{
	/// <summary>
	/// FlatPile is a specific version of a pile of cards, i.e. it represents a pile of
	/// cards that are laid out on top of each other, where a new card is not placed
	/// directly on top of the previous one, but slightly lower so each card can be
	/// seen a little. Example:
	/// 
	///		 ____________________________
	///		|                            |  \
	///		|      1st card              |   >  SPACE_BETWEEN_CARDS
	///		| ___________________________|  /
	///		||                            |
	///		||       2nd card             |
	///		|| ___________________________|
	///		|||                            |
	///		|||        3rd card            |
	///		||| ___________________________|
	///		||||                            |
	///		||||           etc.             |
	///		||||                            |
	///		
	/// Note: the cards will be drawn with the same X coordinates, but
	/// the drawing above shifts each card to the right.
	/// Also note that this class will not enforce any kind of rules 
	/// about what kind of cards could be placed on top of each other,
	/// since these rules could be quite different between various
	/// solitaires.
	/// </summary>
	public class FlatPile : Pile
	{
		#region Constants
		// Number of pixels between
		private const int SPACE_BETWEEN_CARDS = 30;
		#endregion

		#region Properties
		public override Point Location
		{
			get
			{
				return m_ptLocation;
			}
			set
			{
				m_ptLocation = value;

				for ( int i = 0; i < m_cards.Count; i++ )
				{
					Point pt = TranslatePoint( value, i );
					m_cards[i].Location = pt;
				}
			}
		}
		#endregion

		#region Constructor
		public FlatPile( Point ptLocation, CardCollection initialCards )
			: base( ptLocation, initialCards )
		{
		}
		#endregion

		#region Overridden functions

		public override bool AddCards( CardCollection cards )
		{
			foreach ( Card c in cards )
			{
				base.m_cards.Add( c );

				// First card should be placed exactly where the pile is located,
				// but next cards should be lowered accordingly
				c.Location = TranslatePoint( this.Location );
			}

			return true;
		}

		public override void Draw( Graphics g )
		{
			// Draw all cards. We could probably optimize this somewhat,
			// since only the topmost card must draw itself completely,
			// and the cards below only need to draw the first
			// SPACE_BETWEEN_CARDS pixels. However, there doesn't seem
			// to be any compelling reason for us to do this - yet.
			base.m_cards.Draw( g );
		}

		/// <summary>
		/// Since we're changing the height of the pile, we must override
		/// this function.
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		public override bool Contains( Point pt )
		{
			return ( pt.X >= this.Location.X && pt.X <= this.Location.X + Card.WIDTH )
				&& ( pt.Y >= this.Location.Y && pt.Y <= this.Location.Y + Card.HEIGHT + ( ( this.Count - 1 ) * SPACE_BETWEEN_CARDS ) );
		}
		#endregion

		#region Protected functions
		protected Point TranslatePoint( Point pt )
		{
			return TranslatePoint( pt, this.Count - 1 );
		}

		protected Point TranslatePoint( Point pt, int index )
		{
			return new Point( pt.X, pt.Y + ( SPACE_BETWEEN_CARDS * index ) );
		}
		#endregion
	}
}
