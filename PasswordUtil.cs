using System;
using System.Collections.Generic;

namespace Util {

	static class PasswordUtil
	{
		public static string GenerateStrongPassword()
		{
			// -------------------------------------------------
			// Generates a random, 16 character strong password
			// -------------------------------------------------
			string strongPassword = string.Empty;
			string rndLetter = string.Empty;
			string rndDigit = string.Empty;
			string rndSChar = string.Empty;
			string lastChar = string.Empty;
			string[] aryDigits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
			string[] aryLetters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
			string[] arySpecialChars = { "*", "#", "$", "%", "!", "?" };
			List<string> lstLetters = new List<string>();
			List<string> lstSpecial = new List<string>();
			List<string> lstDigits = new List<string>();
			int rInt = 0;
			int pos = 0;
			Random r;
			// ---------------------------------------------
			// Create the random letters list
			// ---------------------------------------------
			r = new Random();
			while (true)
			{
				rInt = r.Next(0, 52);
				rndLetter = aryLetters[rInt];
				if (!lstLetters.Contains(rndLetter)) lstLetters.Add(rndLetter);
				if (lstLetters.Count == 52) break;
			}
			// ---------------------------------------------
			// Create the random Special Characters list
			// ---------------------------------------------
			while (true)
			{
				rInt = r.Next(0, 6);
				rndSChar = arySpecialChars[rInt];
				if (!lstSpecial.Contains(rndSChar)) lstSpecial.Add(rndSChar);
				if (lstSpecial.Count == 6) break;
			}
			// ---------------------------------------------
			// Create the random Digits list
			// ---------------------------------------------
			while (true)
			{
				rInt = r.Next(0, 10);
				rndDigit = aryDigits[rInt];
				if (!lstDigits.Contains(rndDigit)) lstDigits.Add(rndDigit);
				if (lstDigits.Count == 10) break;
			}
			// -------------------------------------------------
			// Final password: a random mix of 16 letters, 
			// special characters and digits.
			// -------------------------------------------------
			r = new Random();
			while (strongPassword.Length < 16)
			{
				// ---------------------------------------------
				// Randomly choose one of the 3 character lists:
				// Letters, special characters or digits.
				// ---------------------------------------------
				int nList = r.Next(0, 3);
				switch (nList)
				{
					case 0:
						// -------------------------------------
						// Choose a random letter
						// -------------------------------------
						pos = r.Next(0, 51);
						if (!strongPassword.Contains(lstLetters[pos])) strongPassword += lstLetters[pos];
						break;
					case 1:
						// -------------------------------------
						// Choose a random special character
						// -------------------------------------
						// Enforce password must start with a letter.
						if (strongPassword.Length == 0) continue;
						pos = r.Next(0, 5);
						if (!strongPassword.Contains(lstSpecial[pos])) strongPassword += lstSpecial[pos];
						break;
					case 2:
						// -------------------------------------
						// Choose a random digit
						// -------------------------------------
						// Enforce password must start with a letter.
						if (strongPassword.Length == 0) continue;
						pos = r.Next(0, 9);
						if (!strongPassword.Contains(lstDigits[pos])) strongPassword += lstDigits[pos];
						break;
				}
			}
			return strongPassword;
		}

	}
}
