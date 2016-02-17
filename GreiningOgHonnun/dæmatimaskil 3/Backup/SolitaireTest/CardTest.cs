using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Solitaire;
using Solitaire.Common;

namespace SolitaireTest
{
	[TestFixture]
	public class CardTest
	{
		[Test]
		public void TestCardConstructor( )
		{
			Card c = new Card( Suit.Hearts, 1, true, null );

			Assert.AreEqual( c.Suit,   Suit.Hearts, "Suit is not stored correctly" );
			Assert.AreEqual( c.Rank,   1,           "Rank is not stored correctly" );
			Assert.AreEqual( c.FaceUp, true,        "FaceUp is not stored correctly" );
		}

		[Test]
		public void TestRedBlack( )
		{
			Card heart = new Card( Suit.Hearts, 1, true, null );
			Card spade = new Card( Suit.Spades, 2, true, null );
			Card diamond = new Card( Suit.Diamonds, 5, true, null );
			Card club = new Card( Suit.Clubs, 12, true, null );

			Assert.AreEqual( heart.IsRed( ), true );
			Assert.AreEqual( diamond.IsRed( ), true );
			Assert.AreEqual( spade.IsBlack( ), true );
			Assert.AreEqual( club.IsBlack( ), true );

			Assert.AreEqual( heart.IsOppositeColor( spade ), true );
			Assert.AreEqual( heart.IsOppositeColor( club ), true );
			Assert.AreEqual( heart.IsOppositeColor( diamond ), false );
			Assert.AreEqual( heart.IsOppositeColor( heart ), false );

			Assert.AreEqual( spade.IsOppositeColor( heart ), true );
			Assert.AreEqual( spade.IsOppositeColor( diamond ), true );
			Assert.AreEqual( spade.IsOppositeColor( club ), false );
			Assert.AreEqual( spade.IsOppositeColor( spade ), false );

			Assert.AreEqual( diamond.IsOppositeColor( spade ), true );
			Assert.AreEqual( diamond.IsOppositeColor( club ), true );
			Assert.AreEqual( diamond.IsOppositeColor( heart ), false );
			Assert.AreEqual( diamond.IsOppositeColor( diamond ), false );

			Assert.AreEqual( club.IsOppositeColor( heart ), true );
			Assert.AreEqual( club.IsOppositeColor( diamond ), true );
			Assert.AreEqual( club.IsOppositeColor( spade ), false );
			Assert.AreEqual( club.IsOppositeColor( club ), false );
		}

		[Test]
		public void TestHitTesting( )
		{
			// TODO: test Card.Contains( )!!!
		}

		// TODO: test other functionality...

	}
}
