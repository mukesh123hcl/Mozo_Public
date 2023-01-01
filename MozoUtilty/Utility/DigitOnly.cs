using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MozoUtilty.Utility
{
	public class DigitOnly
	{
		public static bool IsDigitsOnly(string str)
		{
			foreach (char c in str)
			{
				if (c < '0' || c > '9')
					return false;
			}

			return true;
		}
	}
}
