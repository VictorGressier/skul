using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Solitaire.Common;

namespace Solitaire.Solitaires.Klondike
{
	/// <summary>
	/// KlondikeDeckPile represents the deck pile, i.e. a pile which contains
	/// all the cards that haven't been dealt yet.
	/// </summary>
	public class KlondikeDeckPile : Pile
	{
		#region Constructor
		public KlondikeDeckPile( Point pt, CardCollection cards )
			: base( pt, cards )
		{
		}
		#endregion

		#region Properties
		public CardCollection Cards
		{
			set 
			{
				base.m_cards = value;
				base.m_cards.SetLocation( this.Location );
			}
		}
		#endregion

		#region Overridden functions
		/// <summary>
		/// We don't support drag'n'drop:
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		public override CardCollection GetCardsToDrag( Point pt )
		{
			return null;
		}

		/// <summary>
		/// We don't support adding cards back:
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		public override bool AddCard( Card c )
		{
			return false;
		}

		/// <summary>
		/// Adding a collection of cards is not supported:
		/// </summary>
		/// <param name="cards"></param>
		/// <returns></returns>
		public override bool AddCards( CardCollection cards )
		{
			return false;
		}

		/// <summary>
		/// Drawing is overridden, so we can draw a custom
		/// indicator when there are no cards left to deal.
		/// </summary>
		/// <param name="g"></param>
		public override void Draw( Graphics g )
		{
			base.Draw( g );

			if ( base.Count == 0 )
			{
				using ( Pen p = new Pen( Color.Red, 12.0f ) )
				{
					p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
					p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

					g.DrawLine( p, this.Location.X + 6,              this.Location.Y + 6, this.Location.X + Card.WIDTH - 6, this.Location.Y + Card.HEIGHT - 6 );
					g.DrawLine( p, this.Location.X + Card.WIDTH - 6, this.Location.Y + 6, this.Location.X + 6,              this.Location.Y + Card.HEIGHT - 6 );
				}
				// TODO: draw a marker if we cannot draw again
				// - such as a big red X
			}
		}
		#endregion
	}
}
