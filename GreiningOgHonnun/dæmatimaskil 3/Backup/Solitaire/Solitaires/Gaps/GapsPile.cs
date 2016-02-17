using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Solitaire.Common;

namespace Solitaire.Solitaires.Gaps
{
	public class GapsPile : Pile
	{
		public GapsPile( Point pt )
			: base( pt )
		{
			// Initially, we have room for all the cards in one suit,
			// plus a gap:
			base.m_cards = new CardCollection( 14 );
		}

		public void SetAt( int index, Card c )
		{
			base.m_cards[ index ] = c;
		}

		public override void Draw( Graphics g )
		{
			// Draw each card in our collection
			for ( int i = 0; i < 14; i++ )
			{
				Card c = m_cards[ i ];
				if ( c == null )
				{
					// Draw a "gap" rectangle at this location:
					// TODO:
				}
				else
				{
					c.Draw( g );
				}
			}
		}

		// public override 
	}
}
