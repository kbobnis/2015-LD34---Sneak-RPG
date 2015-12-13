using UnityEngine;
using System.Collections;

public class WrongTouchException : System.Exception {

	public WrongTouchException(string reason) : base(reason){
	}


}
