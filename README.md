# Syrchalis' Prosthetic Icons
Adds icons to every vanilla prosthetic and implant. Also adds a special texture for stacks of implants in case you have a mod that allows you to stack them.

**2.0:** Patch Operations have been replaced by C# code that looks for key words and assigns textures and colors accordingly. This means that instead of relying on compatibility on the side of this mod it now relies on mods that add prosthetics to use the right words in their defnames. 

The result is that basically any mod that adds any prosthetic is compatible now.

## Guide for modders:
### Make sure your body parts have `<isTechHediff>true</isTechHediff>`
This is accomplished either by adding the above to the thingDef or by using the **vanilla parents**. Mostly there is no reason to not use the vanilla parents, so I recommend that. It also makes your mod automatically compatible with my Prosthetic Table mod.

### Textures get assigned based on key words (strings)
So make sure your defnames are logical. For example any body part that replaces an arm should also have 'arm' in it's defname. [For a full list of keywords look directly into the code](https://github.com/Syrchalis/ProstheticIcons/blob/master/Source/ProstheticIcons/ModSettings.cs#L67).
You can see that it looks for things like "arm" or "kidney". Note the words are not case sensitive so no need to capitalize anything.

### Colors get assigned based on key words as well
Same method as above, colors get assigned by key words. Here it looks for words like "simple" or "archotech" to assign the appropriate color. Defnames just need to contain one of these words if not specified differently.
There are 7 colors:
* White - default color, key words: `natural`
* Brown - for simple prosthetics, key words: `simple prosthetic basic artificial cochlear`
* Yellow - for bionics, key words: `bionic`
* Green - for archotech, key words: `archotech advanced`
* Purple - for advanced archotech, key words: `archotech AND advanced`
* Dark Blue - for simple animal prosthetics, key words: `animal`
* Light Blue - for bionic animal prosthetics, key words: `animal AND bionic`


### You can support me and help me speed up mod development for a small price: 
[![ko-fi](https://www.ko-fi.com/img/donate_sm.png)](ko-fi.com/syrchalis)
