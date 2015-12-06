Cuddly Cupcakes
- Garrett Stache    gstache3 gstache3@gatech.edu
	
- Tiffany Zhang   tzhang76
 tzhang76@mail.gatech.edu
- Charvi Argawal   cagarwal9
  charvi@gatech.edu

- Sahsa Azad   sazad6
  sasha.azad@gatech.edu

- Peilin Li   pli41
  lipeilin@gatech.edu
2

UI Style:
- We have a main menu and a death screen that implement similar UI functions, allowing the player to enter the funeral and see the credits. In both, the camera orbits the funeral parlor while the "Adam's Family" theme song plays. The UI elements draw from the gothic theme of the show, with a semi-ornate panel behind the main text, and coffin-shaped buttons below. The font is also playfully spooky, and used in all UI panels throughout the game. The buttons highlight a ghoulish green when hovered over with the mouse, or scrolled to with the arrow keys. For now, use up arrow, down arrow and return to navigate the buttons, or use the mouse.
- In the credits, the camera flies like a ghost through a hallway, revealing ghoulish green text for each contirbution. We used the same font as the main menu, and made the hallway dim, so only the text and individual lights could be seen.

Particle system 1: Poof! Depossessed cloud
- This particle system is triggered by the Possessible script, in the method dePossess().The primary particle emitter is a burst of bright blue particles, which turn activate smoke puff sub emitters on death. The smoke puff sub emitter uses a particle blend material with a cloud png. The emitter is in the shape of the ghost mesh The velocity of the particles reduces over time, the size increases, the particles rotate over time, and the alpha value fades out to create a semi-realistic smoke cloud. We wanted an ethereal cloud to signify when the ghost has been rejected by the body. If the player presses space to leave his possessed host, or runs out of time, the particle effect is triggered.
- This particle effect is a child of the ghoul object in the main scene

Particle System 2: Inky Death
- this particle system is attached to an all-black, partially transparent NPC that follows the player around.
- the system uses an ink texture, wich a local velocity over time implemented, so it looks like the ink is bleeding from form of the NPC. It uses size over time, rotation over time, and angular rotation to create a flowing, ink like effect that enhances both the intimidation factor and supernatural feel of the Death NPC, which will be used in the final game to hunt down the player

List of 3rd party assets used so far:

Ghoul: BUMSTRUM, http://u3d.as/h0v
Mocap Animations: Unity Technologies Raw Mocap for Mechanim, http://u3d.as/3Bt
Spider: [prism bucket], http://u3d.as/9ze
Retro Lamps: Artur G, http://u3d.as/8qL
Chairs: Ka Designs, http://u3d.as/5Fs
Flowers: Game Asset Studio, http://u3d.as/5zY
Knife: https://www.assetstore.unity3d.com/en/#!/content/4429
Bolt: https://www.assetstore.unity3d.com/en/#!/content/2763
Teddy Bear: https://www.assetstore.unity3d.com/en/#!/content/39976
Other Characters made with Make Human
Music: Adams Family theme, Adams Family Overture; Warner Brothers

first Scene to open in Unity:
StartScreen

Controls to test:
Use WASD to move, space to possess. Possess and de-possess a character to test particle system 1, then look for the large semi-transparent black character to view particle system 2. Use the arrow keys to scroll through the menu buttons, or use the mouse.

Prism URL:
www.prism.gatech.edu/~gstache3/Milestone4/Milestone4.html