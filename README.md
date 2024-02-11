# Game Creator - A Classic Game Maker-Compatible Game Engine

An experimental cross-platform, pluggable .NET game engine, with an editor, scripting engine, runner, compiler, and front-end with various implementations, compatible with games created for _**Game Maker**_, based on the API and behavior observed during gameplay.

Note that this engine is based on the the classic, legacy versions of
Game Maker written by Mark Overmars (versions <= 8.1), _not_ GameMaker Studio or current versions of GameMaker (with no space) developed by YoYo Games.

### Branches
The old code base (14+ years) is incomplete and was in the middle of some heavy refactoring, so I have moved various components into different branches as they are reworked with new code. Here are the main variants:

- **master** - all of the game engine logic and API, including for the function and action libraries.
  
- **monogame** - a front-end runtime built on MonoGame.
  
- **opentk** - a front-end runtime built on OpenTK.
  
- **fix-legacy** - includes the GML interpreter and legacy IDE, and supports GML backends.

- **gmfiles** - compatibility with .gmd files and includes a .gmk decoder.
  
- **action-libraries** - compatibility with classic action library files.
  
- **GML-binder** - support for writing seamless GML-style code in c#, and tighter integraton with the runtime and interpreter.
  
- **clr-compiler** - just-in-time (JIT) compiler interface for outputting parsed GML to .NET bytecode.

Some of the code, specifically for reading and writing GML, GMK, and action library files, are based on other 

#### Other branches:

- **gc-projects** - the project model for the older code.
  
- **js-backburner** - an older GML parser and runtime experiment written in JavaScript.


## Contributing
The developer experience should be continually improving now. Feel free to join the effort, submit a PR, report any issues, or just get in touch!

Josh