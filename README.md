# game-creator
An **open-source clone of Game Maker** focused on **maximum portability** and **backwards-compatability**.

**As of 2018,** I am in the process of rewriting the game engine in dotnet core, and have destroyed most of the old code. The original version was centered around the parser. This one is centered around the game engine. The only thing left to move over is the interpreter/compiler. After that, we need a cross-platform IDE, which should be plug-and-play. I'm thinking of writing it in Avalonia (http://avaloniaui.net/) or creating a web-based UI.

I have fully modularized everything and moved platform logic into plugins. Currently, 2 platform plugins exist and are functional: MonoGame and OpenTK. Between these, maximum portability is ensured. A further iteration to include a WebGL platform is planned and will call for a GML grammar written in Antlr, which will open up possibilities even further.

Eventually I will publish the modules to Nuget, which will allow all kinds of GM tools to be created: editors, format converters, microservices in docker, command-line tools, GML shell, etc. It's possible it could be ported to the Unity platform.

I've been working on this project sporadically in my spare time since I was 16 (2008). It started with an interpreter that reliably worked exactly like GM's.

## What's implemented
1. Game engine - almost fully functional, with 3D support and pixel-perfect collision detection.
2. Plugin support
3. GM Domain Model - Events, resources, instances, rooms, etc.
4. GM project and library loading
5. GML Interpreter, binary compiler, and JIT compiler - execute_string() is supported

## What's left
1. Cross-platform IDE
2. Web platform
3. Full action and function libraries
4. Specific libraries: particles, multiplayer, etc.

## Contributing
Let me know if you'd like to help out! The project is written in C# (dotnet core). The biggest need is implementation of the function library. You can reach me at Joshwyant91@gmail.com.
