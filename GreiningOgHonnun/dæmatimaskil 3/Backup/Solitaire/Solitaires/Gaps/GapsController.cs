using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Solitaire.Common;

namespace Solitaire.Solitaires.Gaps
{
	public class GapsController : ISolitaireController
	{
		#region ISolitaireController Members

		CardCollection ISolitaireController.StartDragging( System.Drawing.Point pt )
		{
			throw new NotImplementedException( );
		}

		bool ISolitaireController.EndDragging( CardCollection cards, System.Drawing.Point pt )
		{
			throw new NotImplementedException( );
		}

		void ISolitaireController.DoubleClick( System.Drawing.Point pt )
		{
			throw new NotImplementedException( );
		}

		void ISolitaireController.Click( System.Drawing.Point pt )
		{
			throw new NotImplementedException( );
		}

		void ISolitaireController.Draw( System.Drawing.Graphics g )
		{
			throw new NotImplementedException( );
		}

		void ISolitaireController.Deal( )
		{
			// TODO:
		}

		void ISolitaireController.ShowOptions( )
		{
			// TODO:
		}

		#endregion
	}
}
