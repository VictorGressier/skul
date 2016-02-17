using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solitaire.Common
{
	public class ImageManager
	{
		private ImageTheme m_currentTheme = new ImageTheme( );

		public ImageTheme CurrentTheme
		{
			get
			{
				return m_currentTheme;
			}
		}
	}
}
