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
	public class CardCollectionTest
	{
		[Test]
		public void TestUpdateLocation( )
		{
			CardCollection coll = new CardCollection( );

			coll.Add( new Card( Suit.Clubs, 10, true, null ) );
			coll.Add( new Card( Suit.Diamonds, 11, true, null ) );
			coll.Add( new Card( Suit.Diamonds, 7, true, null ) );

			coll.UpdateLocation( 10, 7 );

			// This test does in fact rely on the fact that a card
			// will by default initialize its location to 0,0. 
			Assert.AreEqual( coll[ 0 ].Location.X, 10 );
		}

		[Test]
		public void TestAlternatingColors( )
		{
			CardCollection coll = new CardCollection( );

			// An empty one is also alternating:
			Assert.AreEqual( coll.IsAlternatingColors( ), true );
			coll.Add( new Card( Suit.Clubs, 10, true, null ) );

			// So is a collection of only one element:
			Assert.AreEqual( coll.IsAlternatingColors( ), true );

			// Then, add a few cards of alternating colors:
			coll.Add( new Card( Suit.Diamonds, 11, true, null ) );
			coll.Add( new Card( Suit.Clubs, 7, true, null ) );
			coll.Add( new Card( Suit.Diamonds, 11, true, null ) );
			coll.Add( new Card( Suit.Spades, 7, true, null ) );
			coll.Add( new Card( Suit.Hearts, 11, true, null ) );
			coll.Add( new Card( Suit.Clubs, 7, true, null ) );

			// This should hold:
			Assert.AreEqual( coll.IsAlternatingColors( ), true );

			// Finally, remove a card in the middle:

			coll.RemoveAt( 2 );

			// ... which should make it no longer alternating:
			Assert.AreEqual( coll.IsAlternatingColors( ), false );
		}
	}
}
