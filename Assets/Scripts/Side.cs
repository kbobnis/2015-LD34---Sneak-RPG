using UnityEngine;
using System.Collections;

public enum Side {
	Up = 0, Right = 90, Down = 180, Left = -90
}

public static class SideExtension {

	public static Side GetDiff(this Side mySide, Side otherSide) {
		int my = (int)mySide;
		int diff = (int)otherSide - my;
		if (Mathf.Abs(diff) >= 360) {
			diff %= 360;
		}
		if (diff == 270) {
			diff = -90;
		}
		if (diff == -270) {
			diff = 90;
		}
		if (diff == 360) {
			diff = 0;
		}
		return (Side)diff;
	}
}
