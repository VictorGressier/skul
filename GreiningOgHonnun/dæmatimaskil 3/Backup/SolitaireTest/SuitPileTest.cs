using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Solitaire;
using Solitaire.Common;

namespace SolitaireTest
{
	[TestFixture]
	public class SuitPileTest
	{
		[Test]
		public void TestAddCards( )
		{
			// Create a pile, location is irrelevant in this case:
			SuitPile suitPile = new SuitPile( new Point( 0, 0 ) );

			Card tenOfSpades = new Card( Suit.Spades, 10 );
			Card aceOfHearts = new Card( Suit.Hearts, 1 );
			Card twoOfSpades = new Card( Suit.Spades, 2 );
			Card twoOfHearts = new Card( Suit.Hearts, 2 );

			//Assert.AreEqual( suitPile.AddCard( tenOfSpades ), false, "SuitPile should only accept an ace as a first card" );
			//Assert.AreEqual( suitPile.AddCard( aceOfHearts ), true,  "SuitPile should accept an ace as a first card" );
			//Assert.AreEqual( suitPile.AddCard( twoOfSpades ), false, "SuitPile should only accept cards in ascending order" );
			//Assert.AreEqual( suitPile.AddCard( twoOfHearts ), true, "SuitPile should accept cards in ascending order and of same suit" );
		}
	}
}
