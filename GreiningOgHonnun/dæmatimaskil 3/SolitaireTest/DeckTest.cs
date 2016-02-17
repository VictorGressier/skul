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
	public class DeckTest
	{
		[Test]
		public void TestDeckConstructor( )
		{
			Deck d = new Deck( );

			Assert.AreEqual( d.Count, 52 );
		}
	}
}
