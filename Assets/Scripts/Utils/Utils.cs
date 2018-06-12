using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyUtils
{
	public class Utils
	{
		public Utils ()
		{
		}

		public static Color[] colors = { 
			Utils.HexToColor("35E2F2"), // Cyan
			Utils.HexToColor("F6DF0E"), // Yellow
			Utils.HexToColor("8A13F8"), // Mageto
			Utils.HexToColor("FC007E")  // Pink
		};

		public static Color HexToColor(string hex)
		{
			byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r,g,b, 255);
		}

		public static string ColorToHex(Color32 color)
		{
			string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
			return hex;
		}
	}
}

