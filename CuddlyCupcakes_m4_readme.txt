Cuddly Cupcakes


Particle system 1: Poof! Depossessed cloud
- This particle system is triggered by the Possessible script, in the method dePossess(). It uses a particle blend material with a cloud png. The emitter is in the shape of the ghost mesh The velocity of the particles reduces over time, the size increases, the particles rotate over time, and the alpha value fades out to create a semi-realistic smoke cloud. We wanted an ethereal cloud to signify when the ghost has been rejected by the body. If the player presses space to leave his possessed host, or runs out of time, the particle effect is triggered.
- This particle effect is a child of the ghoul object in the main scene