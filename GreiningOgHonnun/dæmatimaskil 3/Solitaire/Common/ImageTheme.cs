using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Solitaire.Common
{
	/// <summary>
	/// TODO: document!!!
	/// </summary>
	public class ImageTheme
	{
		#region Member variables
		private Image m_cardBackground   = null;
		private Image m_windowBackground = null;
		private Dictionary< int, Image > m_loadedCardImages = new Dictionary<int, Image>( );
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public Image CardBackground 
		{
			get
			{
				// Load on demand:
				if ( m_cardBackground == null )
				{
					m_cardBackground = LoadImage( "Cards\\bkgnd.jpg" );
				}

				return m_cardBackground;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Image WindowBackground
		{
			get
			{
				// Load on demand:
				if ( m_windowBackground == null )
				{
					m_windowBackground = LoadImage( "wndBkgnd.png" );
				}

				return m_windowBackground;
			}
		}
		#endregion

		#region Public functions
		/// <summary>
		/// 
		/// </summary>
		/// <param name="suit"></param>
		/// <param name="rank"></param>
		/// <returns></returns>
		public Image GetCardImage( Suit suit, int rank )
		{
			Image cardImage = null;

			// Generate an ImageID based on the suit and the rank.
			// Neither values will become very big (1-4 and 1-13),
			// so we can pack them into a single integer.
			int nImageID = ( (int)suit << 16 ) | rank;

			if ( !m_loadedCardImages.Keys.Contains( nImageID ) )
			{
				String strFileName = String.Format( "Cards\\{0}_{1}.png", suit, rank );
				cardImage = LoadImage( strFileName );

				m_loadedCardImages[ nImageID ] = cardImage;
			}
			else
			{
				cardImage = m_loadedCardImages[ nImageID ];
			}

			return cardImage;
		}
		#endregion

		#region Protected functions
		/// <summary>
		/// 
		/// </summary>
		/// <param name="strFileName"></param>
		/// <returns></returns>
		protected Image LoadImage( String strFileName )
		{
			Image img = null;

			// TODO: make the image loading dynamic depending on the theme (folder) in question

			try
			{
				img = Image.FromFile( strFileName );
			}
			catch ( Exception ex )
			{
				System.Diagnostics.Debug.WriteLine( ex.Message );
			}

			return img;

		}
		#endregion
	}
}
