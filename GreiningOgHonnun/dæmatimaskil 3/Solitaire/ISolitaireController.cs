using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Solitaire.Common;

namespace Solitaire
{
	/// <summary>
	/// ISolitaireController is an interface that must be implemented by all
	/// different solitaires.
	/// </summary>
	public interface ISolitaireController
	{
		/// <summary>
		/// This function will get called when the user initiates a
		/// "start drag" operation. The function should return a collection
		/// of cards that will be dragged during the operation, or null
		/// if no cards should get moved.
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		CardCollection StartDragging( Point pt );

		/// <summary>
		/// This function will get called when the drag operation is completed.
		/// The controller can either accept or reject the drag, indicated
		/// by the return value (returns true if accepted, false otherwise).
		/// </summary>
		/// <param name="cards"></param>
		/// <param name="pt"></param>
		/// <returns></returns>
		bool EndDragging( CardCollection cards, Point pt );

		/// <summary>
		/// Called when the solitaire window is double clicked. Note: there is no
		/// guarantee that a card exists where the double click takes place.
		/// </summary>
		/// <param name="pt"></param>
		void DoubleClick( Point pt );

		/// <summary>
		/// Called when the solitaire window is single-clicked.
		/// </summary>
		/// <param name="pt"></param>
		void Click( Point pt );

		/// <summary>
		/// Called when the controller must draw the solitaire.
		/// </summary>
		/// <param name="g"></param>
		void Draw( Graphics g );

		/// <summary>
		/// Called when a new game should be dealt.
		/// </summary>
		void Deal( );

		/// <summary>
		/// Called when the current game should display its 
		/// options dialog, if it has one.
		/// </summary>
		void ShowOptions( );
	}
}
