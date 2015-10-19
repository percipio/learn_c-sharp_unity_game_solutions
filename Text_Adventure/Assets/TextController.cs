using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {
		cell_0, cell_1, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
		corridor_0
	};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell_0;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.cell_0) 			{cell_0();}
		if 		(myState == States.cell_1) 			{cell_1();}
		else if (myState == States.sheets_0) 		{sheets_0();}
		else if (myState == States.sheets_1) 		{sheets_1();}
		else if (myState == States.lock_0) 			{lock_0();}
		else if (myState == States.lock_1) 			{lock_1();}
		else if (myState == States.mirror) 			{mirror();}
		else if (myState == States.cell_mirror) 	{cell_mirror();}
		else if (myState == States.corridor_0) 		{corridor_0();}
	}
	
	void cell_0 () {		
		text.text = "You are asleep." + 
					"\n\nPress 'Space Bar' to wake up.";
		if 		(Input.GetKeyDown(KeyCode.Space))	{myState = States.cell_1;}
	}
	
	void cell_1 () {		
		text.text = "There is a mirror on the wall and the only door in the room is locked from the outside. " +
			"The hole in the ground near one corner smells like a toilet that hasn't been flushed in a long time." + 
				"\n\nPress 'S' to view the sheets, M to view the mirror, L to view the lock.";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_0;} 
		else if (Input.GetKeyDown(KeyCode.M))		{myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L))		{myState = States.lock_0;}
	}
	
	void sheets_0 () {		
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasure of prison life " +
					"I guess!" + 
					"\n\nPress 'R' to view the rest of the cell";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_1;} 
	}
	
	void sheets_1 () {		
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better. " + 
					"\n\nPress 'R' to view the rest of the cell";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;} 
	}
	
	void lock_0 () {		
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"\n\nPress 'R' to view the rest of the cell";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_1;} 
	}
	
	void lock_1 () {		
		text.text = "You carefully put the mirror through the bars, and turn it around " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click." +
					"\n\nPress 'O' to open the cell, or 'R' to view the rest of the cell";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.O))		{myState = States.corridor_0;}
	}
	
	void mirror () {		
		text.text = "The cell mirror is small and could easily fit in your hand. " +
					"You see it is held to the cell wall by a flimsy nail. " + 
					"\n\nPress 'T' to take the mirror, or 'R' to view the rest of the cell";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_1;}
		else if (Input.GetKeyDown(KeyCode.T))		{myState = States.cell_mirror;}
	}
	
	void cell_mirror () {		
		text.text = "You are holding the cell mirror in your hands." + 
					"\n\nPress 'S' to view the sheets again or 'L' to view the lock";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;} 
		else if (Input.GetKeyDown(KeyCode.L))		{myState = States.lock_1;}
	}
	
	void corridor_0 () {		
		text.text = "You are in a corridor. There is a wall closet on the right and stairs on the left." + 
					"\n\nPress 'S' to walk up the stairs.";
		if 		(Input.GetKeyDown(KeyCode.P))		{myState = States.cell_0;}
	}
}