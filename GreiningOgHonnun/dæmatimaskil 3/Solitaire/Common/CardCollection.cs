using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Common
{
	/// <summary>
	/// CardCollection represents a collection of cards. There are no 
	/// restrictions to what kind of cards this collection holds (i.e. they
	/// can be in any order whatsoever, be of any suit/color/rank).
	/// The class contains a few helper functions used to determine if the
	/// cards in the collection fulfill a certain criteria (such as being of
	/// alternating colors, same suit, descending rank etc.). It also contains
	/// a few helper functions which apply a certain function to all cards
	/// in the collection.
	/// </summary>
	public class CardCollection : List<Card>
	{
		#region Constructors
		public CardCollection( )
		{
		}

		public CardCollection( int numElements )
			: base( numElements )
		{
		}
		#endregion

		#region Public functions

		/// <summary>
		/// Draw all cards in the collection.
		/// </summary>
		/// <param name="g"></param>
		public void Draw( Graphics g )
		{
			foreach ( Card c in this )
			{
				c.Draw( g );
			}
		}

		/// <summary>
		/// UpdateLocation takes care of updating every Card in the collection
		/// with the new coordinates. NOTE: the parameters are not X and Y
		/// coordinates, but instead these values will be added to the current
		/// coordinates of the cards. They can be positive or negative.
		/// </summary>
		/// <param name="xDiff"></param>
		/// <param name="yDiff"></param>
		public void UpdateLocation( int xDiff, int yDiff )
		{
			foreach ( Card c in this )
			{
				Point pt = new Point( c.Location.X + xDiff, c.Location.Y + yDiff );
				c.Location = pt;
			}
		}

		/// <summary>
		/// Sets the location of each card in the collection.
		/// </summary>
		/// <param name="ptNewLocation"></param>
		public void SetLocation( Point ptNewLocation )
		{
			base.ForEach( c => c.Location = ptNewLocation );
		}

		public void SetFaceUp( bool bFaceUp )
		{
			base.ForEach( c => c.FaceUp = bFaceUp );
		}

		/// <summary>
		/// Ensure that all cards in this collection will know that a drag
		/// operation has been started.
		/// </summary>
		public void StartDragging( )
		{
			this.ForEach( c => c.StartDragging( ) );
		}

		/// <summary>
		/// Similar to StartDragging.
		/// </summary>
		public void RestoreLocation( )
		{
			this.ForEach( c => c.RestoreLocation( ) );
		}

		/// <summary>
		/// Returns true if the cards in this collection are of alternating
		/// colors,vi.e. red - black - red - black ... etc.
		/// ( or black - red - black - red ... obviously...)
		/// </summary>
		/// <returns></returns>
		public bool IsAlternatingColors( )
		{
			return CompareCards( delegate( Card current, Card previous )
			{
				return ( current.IsOppositeColor( previous ) );
			} );
		}

		/// <summary>
		/// Returns true if the cards in the collection have a descending rank,
		/// i.e. 13 - 12 - 11 - 10 ... etc.
		/// </summary>
		/// <returns></returns>
		public bool IsDescendingRank( )
		{
			return CompareCards( delegate( Card current, Card previous )
			{
				return current.Rank == previous.Rank - 1;
			} );
		}

		/// <summary>
		/// Returns true if the cards in this collection are of alternating
		/// colors AND descending rank. 
		/// Example: black queen - red jack - black 10 - red 9 ... etc.
		/// </summary>
		/// <returns></returns>
		public bool IsAlternatingColorsAndDescendingRank( )
		{
			return CompareCards( delegate( Card current, Card previous )
			{
				return ( current.Rank == previous.Rank - 1 )
					&& ( current.IsOppositeColor( previous ) );
			} );
		}

		/// <summary>
		/// Returns true if the cards in this collection are all of the same
		/// suit and are in a descending order.
		/// </summary>
		/// <returns></returns>
		public bool IsSameSuitAndDescendingRank( )
		{
			return CompareCards( delegate( Card current, Card previous )
			{
				return ( current.Rank == previous.Rank - 1 )
					&& ( current.Suit == previous.Suit );
			} );
		}

		/// <summary>
		/// Returns true if the cards are in ascending order ( 2 - 3 - 4 ...)
		/// </summary>
		/// <returns></returns>
		public bool IsAscendingRank( )
		{
			return CompareCards( delegate( Card current, Card previous )
			{
				return ( current.Rank == previous.Rank + 1 );
			} );			
		}

		/// <summary>
		/// Returns true if all the cards in this collection are of the 
		/// same suit, but false otherwise.
		/// </summary>
		/// <returns></returns>
		public bool IsSameSuit( )
		{
			return CompareCards( delegate( Card current, Card previous )
			{
				return ( current.Suit == previous.Suit );
			} );
		}

		protected delegate bool CompareCardsDelegate( Card a, Card b );

		/// <summary>
		/// Since the code that is needed to check for alternate colors,
		/// descending rank etc. is almost the same, it was refactored
		/// into this handy little function. It accepts a single delegate
		/// that takes care of comparing two adjacent cards, and if they
		/// don't fulfill the criteria the function returns false.
		/// </summary>
		/// <param name="g"></param>
		/// <returns></returns>
		protected bool CompareCards( CompareCardsDelegate g )
		{
			// It is pointless to compare cards if only 1 or 0 cards are
			// present:
			if ( this.Count < 2 )
			{
				return true;
			}
			else
			{
				// Otherwise, loop through all cards
				// and compare each one with the previous one:
				Card previousCard = this[ 0 ];
				for ( int i = 1; i < this.Count; i++ )
				{
					Card currentCard = this[ i ];

					// Call the delegate, which implements whatever criteria
					// should be used for comparing adjacent cards.
					if ( !g( currentCard, previousCard ) )
					{
						return false;
					}
					previousCard = currentCard;
				}
			}

			return true;
		}
		#endregion
	}
}
