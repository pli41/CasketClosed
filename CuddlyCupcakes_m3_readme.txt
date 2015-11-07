1. Information of team members:
	a. Name: Garrett Stache
	   Prism: gstache3
	   E-mail: gstache3@gatech.edu
	b. Name: Charvi Agarwal
	   Prism account: cagarwal9
	   E-mail: charvi@gatech.edu
	c. Name: Tiffany Zhang
	   Prism account: tzhang76
	   E-mail: tzhang76@mail.gatech.edu
	d. Name: Sasha Azad
	   Prism account: sazad6
	   E-mail: sasha.azad@gatech.edu
	e. Name: Peilin Li
	   Prism account: pli41
	   E-mail: lipeilin@gatech.edu
2. a. Create 1 RAIN AI Nav Mesh Rig that maps the space.  [Done]
   b. Create 2 navigation targets, used in at least one behavior tree. [Done; it is implemented in FemaleNPC].
   c. Create a waypoint network rig that contains at least 6 way points(so that they branch from at least one central way point). [Done; it is implemented in ChildNPC]
   d. Use Mechanim Motor to control the animation controller. [Done; it is implemented in BasicAIWalker, ChildNPC, FemaleNPC]
   e. One specialty animation should be triggered by the AI behavior tree. [Done; BasicAIWalker will do a gesture when approaching to a female character.]
   f. Create a custom RAIN AI element for an NPC that uses position prediction of another game character or object. [Done; the child NPC will use position prediction to intercept the spider]
   g. Create 3 NPC AI types that have different behavior trees. [Done; BasicAIWalker, ChildNPC, FemaleNPC]
   h. NPCs support game feel. [Done]
ChildNPC
Is set up with a RAIN AI Entity named “Child”
Has a separate animator called AI Animator_ChildNPC :: Make sure animator changes for this prefab are made in that controller only
Has a separate Behavior tree called ChildNPCTree
this tree is a duplicate of BasicNPCTree, which is implemented by basic walker, and will have to be changed
Is set up for possession
Chases a spider around the room, advancing its move target to anticipate the spiders’ motion

FemaleNPC 
Is set up with a RAIN AI Entity named “Lady”
Has a separate animator called AI Animator_FemaleNPC
Has a separate Behavior tree called FemaleNPCTree  :: Make sure animator changes for this prefab are made in that controller only
Is set up for possession
Goes to main room nav target
if sees lady, goes to talk with lady
if sees man, goes to casket nav target

BasicAIWalker (Man):
Follows a waypoint route until it sees a RAIN AI Entity named “Lady”
walks to Lady, performs a gesture animation, like in conversation
if Lady is no longer in vision, returns to patrol route
Waypoints selected randomly, so multiple NPCs can use route
has RAIN AI Entity named “Man”
3. Imported resources: all models are imported from Unity asset store.
4. No special instruction needed for building and running of the code.
5. Exact steps to test: walking in the room is enough to test the game features. USE arrow keys to walk, space to possess/ depossess
6. Main scene file: Room_for_Wake
7. prism.gatech.edu\~gstache3\CuddlyCupcakes_M3.html
