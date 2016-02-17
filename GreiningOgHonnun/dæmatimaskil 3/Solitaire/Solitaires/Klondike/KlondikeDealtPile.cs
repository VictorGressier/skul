using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Solitaire.Common;

namespace Solitaire.Solitaires.Klondike
{
	/// <summary>
	/// KlondikeDealtPile represents the pile of cards which have been
	/// dealt from the deck.
	/// </summary>
	public class KlondikeDealtPile : Pile
	{
		#region Constructor
		public KlondikeDealtPile( Point pt )
			: base( pt )
		{

		}
		#endregion

		#region Overridden functions
		public override bool AddCard( Card c )
		{
			// If we're dealing 3 cards, we shift
			// the cards to the right so that each
			// deal will be shown:
			return base.AddCard( c );
		}

		public override void Draw( Graphics g )
		{
			// Just draw'em all:
			base.m_cards.Draw( g );
		}

		public CardCollection RemoveAllCards( )
		{
			CardCollection cards = base.m_cards;
			base.m_cards = new CardCollection( );
			return cards;
		}
		#endregion
	}
}
