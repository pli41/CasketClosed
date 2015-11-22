Cuddly Cupcakes
- Garrett Stache
- Tiffany Zhang
- Charvi Argawal
- Sahsa Azad
- Peilin Li

Particle system 1: Poof! Depossessed cloud
- This particle system is triggered by the Possessible script, in the method dePossess().The primary particle emitter is a burst of bright blue particles, which turn activate smoke puff sub emitters on death. The smoke puff sub emitter uses a particle blend material with a cloud png. The emitter is in the shape of the ghost mesh The velocity of the particles reduces over time, the size increases, the particles rotate over time, and the alpha value fades out to create a semi-realistic smoke cloud. We wanted an ethereal cloud to signify when the ghost has been rejected by the body. If the player presses space to leave his possessed host, or runs out of time, the particle effect is triggered.
- This particle effect is a child of the ghoul object in the main scene

Particle System 2: Inky Death
- this particle system is attached to an all-black, partially transparent NPC that follows the player around.
- the system uses an ink texture, wich a local velocity over time implemented, so it looks like the ink is bleeding from form of the NPC. It uses size over time, rotation over time, and angular rotation to create a flowing, ink like effect that enhances both the intimidation factor and supernatural feel of the Death NPC, which will be used in the final game to hunt down the player
