using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Solitaire.Common;

namespace Solitaire.Solitaires.Klondike
{
	/// <summary>
	/// KlondikeFlatPile represents a pile in the Klondike solitaire, i.e.
	/// one of the piles 
	/// </summary>
	public class KlondikeFlatPile : FlatPile
	{
		#region Constructor
		public KlondikeFlatPile( Point pt, CardCollection cards )
			: base( pt, cards )
		{

		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// 
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		public override CardCollection GetCardsToDrag( Point pt )
		{
			// Loop backwards through all cards in this collection
			// and when we find a card that fits the bill, we return
			// that card and all cards on top of that card.
			// Also note that we don't allow dragging cards which are
			// face down.

			int i = base.Count - 1; 

			for ( ; i >= 0; i-- )
			{
				Card c = base.m_cards[ i ];
				if ( c.Contains( pt ) && c.FaceUp )
				{
					break;
				}
			}

			if ( i != -1 )
			{
				CardCollection cards = new CardCollection( );
				cards.AddRange( base.m_cards.GetRange( i, base.Count - i ) );
				return cards;
			}
			return null;
		}

		/// <summary>
		/// Override this to ensure we don't add cards to the pile 
		/// which are not allowed there.
		/// </summary>
		/// <param name="cards"></param>
		/// <returns></returns>
		public override bool AddCards( CardCollection cards )
		{
			if ( cards.Count > 0 )
			{
				if ( base.Count == 0 )
				{
					// If there are currently no cards in this pile,
					// we only allow adding a collection of cards
					// that starts with a king:
					if ( cards[ 0 ].Rank != 13 )
					{
						return false;
					}
				}
				else
				{
					// Otherwise, if there are cards on this pile,
					// only allow a collection of cards to be added
					// if the first card there has rank one lower
					// than our topmost card (6 can go on 7 etc.)
					if ( base.TopCard.Rank != cards[0].Rank + 1 )
					{
						return false;
					}

					// Also, the cards must not both be red/black:
					if ( !base.TopCard.IsOppositeColor( cards[ 0 ] ) )
					{
						return false;
					}
				}

				// And now to the final condition:
				if ( cards.IsAlternatingColors( ) )
				{
					return base.AddCards( cards );
				}
			}
			return false;
		}

		/// <summary>
		/// This function is overridden so we can turn the topmost
		/// card if it is face down.
		/// </summary>
		/// <param name="count"></param>
		public override void RemoveCards( int count )
		{
			base.RemoveCards( count );

			if ( base.Count > 0
				&& base.TopCard.FaceUp == false )
			{
				// Turn the topmost card over:
				base.TopCard.FaceUp = true;
			}
		}
		#endregion
	}
}
