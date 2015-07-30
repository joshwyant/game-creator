# game-creator
An open-source clone of Game Maker. 

Originally hosted on Google Code (https://code.google.com/p/game-creator)

Started in 2008 and added to version control in 2009, this project has been stored 
in 3 different version control systems. I've converted the old original SVN and 
replacement Mercurial repoitory to GIT and concatenated them. As such, this repo 
on GitHub has the entire commit history.

I was 16 when I started this project, and I've worked on it since then when I have the time.

From Google Code:

Game Creator is an open-source clone of Game Maker. The goal is for the IDE to be 
compatible with Windows, Linux, and Mac, and to create games for a variety of different platforms, 
such as the iPhone, Zune, XBox 360, as well as the development platforms themselves. 
Game Creator aims for 99.9% compatibility with Game Maker, for minimal changes to ported games. 
A specification will be written to keep incompatibilities of runtime environments 
across different platforms to a minimum.

[http://game-creator.googlecode.com/files/screenshot.png]

This project is not affiliated with YoYo Games, Ltd.

## Latest updates:
 * Completed a .NET compiler backend/JIT engine
 * Started building an optionally obfuscating JavaScript backend
 * Rewrote and modularized everything
 * Separated the interpreter from the runtime library and parser
 * Sped up the interpreter with JITed variable access
 * Added a GML generator with a custom formatter
 * ... and more.

## Technologies Currently Used
 * *.NET Framework/Mono Runtime*
   The IDE is written in C#, which is native to Windows and can be easily
   ported to Linux and Mac OS.
 * *OpenTK*
   OpenTK is a multiplatform graphics (gl) and audio API, used for games that target
   the .NET framework.
 * *JavaScript*
   The JavaScript backend to the GML compiler optionally obfuscates and
   minifies your code, allowing you to publish your game on the web with HTML5.
 * *Abstract Syntax Tree*
   The GML compiler builds a tree based on the structure of the GML code. 
   When interpreted, the system executes lambdas for each expression node.
   The API has some potential. It will let you build a syntax tree, optimize it, and
   output the optimized GML.
 * *System.Reflection.Emit*
   This is used to generate .NET executables, in a backend to the GML compiler.
   Assemblies are created with the AssemblyBuilder class. For JIT, the lightweight
   DynamicMethod class is used instead of AssemblyBuilder. 
   System.Linq.Expressions is another core part of the .NET framework that uses
   DynamicMethod internally. Game Creator uses this in interpreted games to create
   delegates that access object properties from GML. It can also be used to build
   an expression tree directly from a lambda, which is featured in the JavaScript compiler
   by making use of ExpressionVisitor.
 * *Dynamic Runtime*
   GML is a dynamic, interpreted language by nature. In cases where types or names
   are not known at compile time, Game Creator includes a dynamic runtime for accessing
   those variables and objects. This will ensure that your game is fully compatible
   and supported when imported from GameMaker.

## Technologies Not Used Yet
 * *LLVM*
   LLVM is a compiler infrastructure I'm planning on using as a backend to the 
   GML compiler. This would make compiled GML ultra fast and ultra portable. It
   would also make writing runtimes for new platforms a breeze, because they can 
   be written in any language and linked with LLVM output files. It would also 
   make writing export modules easier, due to the creation of an LLVM export interface.
 * *MonoGame*
   MonoGame is a good option because it targets many more platforms than OpenTK, though
   MonoGame uses it internally. It's actually the open-source equivalent of Microsoft XNA, 
   and targets iOS, Android, XBox, and more.
 * *Plugin Interface*
   Support is planned for extensiblity by using Export Modules. Once an export module
   is plugged in, you will be able to export your game to any platform supported
   by the open-source community.
 * *Line-level debugging*
   I have hopes of plugging in a line debugger with breakpoints that allows you to
   inspect values at runtime. There is support with the ICorDebug interface, and 
   System.Diagnostics.Debugger.

I started this project in June of 2008 as a hobby, and I worked on it briefly from 2008 to 2009.

The latest snapshot of Game Creator (09/2009) is available as a download in .zip format. 
It's provided AS IS, as a preview. It's pretty unstable since not much has been implemented yet, 
but definitely go ahead and try it out. 
Click here [http://game-creator.googlecode.com/files/snapshot_bin2.zip] to download.

I have a few ideas for improvement.

  * Build a GML analyzer for building efficient compiled code
  * Use an abstract syntax tree to represent the game, to be compiled on any platform
  * Build an interface for using a desired middle layer, i.e. LLVM (http://llvm.org) or Microsoft CCI (http://research.microsoft.com/en-us/projects/cci/)
  * Other back ends can then be used (OpenTK [http://www.opentk.com/], GTKSharp [http://www.mono-project.com/GtkSharp], Emscripten+WebGL for HTML5 [https://github.com/kripken/emscripten], [http://en.wikipedia.org/wiki/WebGL] for HTML5, XNA [http://create.msdn.com/en-US/], etc., etc.)

Note that as of late, these ideas are already being implemented.
