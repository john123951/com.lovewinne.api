using System;
using System.Collections;

namespace Sweet.LoveWinne.Utility
{
	public static class CollectionExtention
	{
		public static bool IsNotEmpty (this ICollection collection)
		{
			if (collection != null && collection.Count > 0) {
				return true;
			}

			return false;
		}
	}
}

