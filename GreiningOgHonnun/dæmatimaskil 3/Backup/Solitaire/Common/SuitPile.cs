using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Solitaire.Common
{
	/// <summary>
	/// SuitPile is a special kind of a pile, which ensures that it only contains
	/// one suit, in ascending order (Ace, Two, ... , Queen, King)
	/// </summary>
	public class SuitPile : Pile
	{
		#region Constructor
		/// <summary>
		/// A SuitPile should always be empty at the beginning...
		/// </summary>
		/// <param name="ptLocation"></param>
		public SuitPile( Point ptLocation )
			: base( ptLocation, new CardCollection( ) )
		{
		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// SuitPile overrides the default behaviour of AddCards, since there are 
		/// restrictions to what kind of cards can be added where. 
		/// </summary>
		/// <param name="cards"></param>
		/// <returns></returns>
		public override bool AddCards( CardCollection cards )
		{
			if ( cards.Count > 0
				&& CanAddCard( cards[ 0 ] )
				&& cards.IsAscendingRank( ) )
			{
				return base.AddCards( cards );
			}

			return false;
		}

		/// <summary>
		/// TODO: document
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public override bool AddCard( Card c )
		{
			if ( this.CanAddCard( c ) )
			{
				base.InternalAddCard( c );
				return true;
			}

			return false;
		}
		#endregion

		#region Protected functions
		protected bool CanAddCard( Card c )
		{
			// The behaviour is different if there are no cards
			// yet in our pile:
			if ( this.Count == 0 )
			{
				// In this case we accept any suit,
				// and the first card (Ace) in that suit:
				return ( c.Rank == 1 );
			}
			else
			{
				// Already some cards in our pile, we therefore only 
				// accept cards of the same suit and where the first
				// card in the collection of cards to be added has
				// one higher rank than the topmost card in our pile:
				if ( c.Suit == m_cards[ 0 ].Suit 
					&& c.Rank == m_cards[ m_cards.Count - 1 ].Rank + 1 )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		#endregion
	}
}
