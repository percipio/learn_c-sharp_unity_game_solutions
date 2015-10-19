using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum States {
		cell_0, cell_1, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
		corridor_0, corridor_1, corridor_2, corridor_3, stairs_0, stairs_1, 
		stairs_2, courtyard_0, courtyard_1, floor_0, floor_1, closet_door_0, closet_door_1, in_closet
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
		else if (myState == States.corridor_1)		{corridor_1();}
		else if (myState == States.corridor_2)		{corridor_2();}
		else if (myState == States.corridor_3)		{corridor_3();}
		else if (myState == States.stairs_0)		{stairs_0();}
		else if (myState == States.stairs_1)		{stairs_1();}
		else if (myState == States.stairs_2)		{stairs_2();}
		else if (myState == States.floor_0)			{floor_0();}
		else if (myState == States.floor_1)			{floor_1();}
		else if (myState == States.courtyard_0)		{courtyard_0();}
		else if (myState == States.courtyard_1)		{courtyard_1();}
		else if (myState == States.closet_door_0)	{closet_door_0();}
		else if (myState == States.closet_door_1)	{closet_door_1();}
		else if (myState == States.in_closet)		{in_closet();}
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
					"\n\nPress 'S' to walk up the stairs, 'F' to look at the floor, or 'C' to look at the closet.";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_0;}
		if 		(Input.GetKeyDown(KeyCode.F))		{myState = States.floor_0;}
		if 		(Input.GetKeyDown(KeyCode.C))		{myState = States.closet_door_0;}
	}
	
	void corridor_1 () {		
		text.text = "You are still in the corridor paperclip in hand." + 
					"\n\nPress 'S' to walk up the stairs, 'C' to look at the closet, or 'F' to look back at the floor.";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_1;}
		if 		(Input.GetKeyDown(KeyCode.F))		{myState = States.floor_1;}
		if 		(Input.GetKeyDown(KeyCode.C))		{myState = States.closet_door_1;}
	}
	
	void corridor_2 () {		
		text.text = "You are back in the corridor with clothes in hand." + 
					"\n\nPress 'S' to walk up the stairs or 'C' to get back in the closet.";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_2;}
		if 		(Input.GetKeyDown(KeyCode.C))		{myState = States.in_closet;}
	}
	
	void corridor_3 () {		
		text.text = "You are back in the corridor dressed as a guard." + 
			"\n\nPress 'S' to walk up the stairs and enter the courtyard or 'C' to get back in the closet and undress.";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.courtyard_1;}
		if 		(Input.GetKeyDown(KeyCode.C))		{myState = States.in_closet;}
	}
	
	void stairs_0 () {		
		text.text = "You walk to the top of the stairs and see a courtyard full of guards. They don't notice you." + 
			"\n\nPress 'R' to return to the corridor or 'E' to enter the courtyard.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_0;}
		if 		(Input.GetKeyDown(KeyCode.E))		{myState = States.courtyard_0;}
	}
	
	void stairs_1 () {		
		text.text = "You return to the top of the stairs and a guard notices the glint of the paper clip." + 
			"\n\nPress 'R' to quickly dash back downstairs unnoticed. Press 'E' to enter the courtyard";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_1;}
		if 		(Input.GetKeyDown(KeyCode.E))		{myState = States.courtyard_0;}
	}
	
	void stairs_2 () {		
		text.text = "You return to the top of the stairs but you are just holding some clothing. Are you sure you want to enter the yard?" + 
			"\n\nPress 'R' to return to the corridor before the guards notice you. Press 'E' to enter the courtyard.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_2;}
		if 		(Input.GetKeyDown(KeyCode.E))		{myState = States.courtyard_0;}
	}
	
	void floor_0 () {		
		text.text = "The floor is disgusting. It is covered in dirt and some dark sludge; you see a glinting paperclip off to the corner." + 
					"\n\nPress 'R' to view the rest of the room or press 'P' to pick up the paperclip.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_0;}
		if 		(Input.GetKeyDown(KeyCode.P))		{myState = States.corridor_1;}
	}
	
	void floor_1 () {		
		text.text = "The floor is still a messy layer of dirt and sludge." + 
			"\n\nPress 'R' to view the rest of the room.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_1;}
	}
	
	void closet_door_0 () {
		text.text = "You see a sturdy closet door but it is locked." +
					"\n\nPress 'R' to view the corridor.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_0;}
	}
	
	void closet_door_1 () {
		text.text = "You see a sturdy closet door but it is locked." +
					"\n\nPress 'R' to view the corridor or 'P' to pick the lock and enter the closet.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_1;}
		if 		(Input.GetKeyDown(KeyCode.P))		{myState = States.in_closet;}
	}
	
	void in_closet () {
		text.text = "You enter the closet and see some guard's clothing. You pick them up." +
					"\n\nPress 'R' to Return to the corridor or 'D' to get dressed and return to the corridor.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_2;}
		if 		(Input.GetKeyDown(KeyCode.D))		{myState = States.corridor_3;}
	}
	
	void courtyard_0 () {
		text.text = "You enter the courtyard and the guards all notice you. They proceed to beat you until you black out and then throw you into your cell." +
			"\n\nPress 'P' to start the game over.";
		if 		(Input.GetKeyDown(KeyCode.P))		{myState = States.cell_0;}
	}
	
	void courtyard_1 () {
		text.text = "You're in the courtyard and all the guards are staring at you." +
			"\n\nPress 'R' to Return to the corridor.";
		if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.corridor_3;}
	}
}