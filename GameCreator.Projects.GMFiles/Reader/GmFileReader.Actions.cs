using System;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Api.Resources;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private List<ActionEntry> GetActions()
        {
            var version = ReadInt();

            return Enumerable.Range(0, ReadInt())
                .Select(i => new ActionEntry
                {
                    Version = ReadInt(),
                    LibraryId = ReadInt(),
                    ActionId = ReadInt(),
                    Kind = (ActionKind) ReadInt(),
                    MayBeRelative = ReadBool(),
                    IsQuestion = ReadBool(),
                    AppliesToSomething = ReadBool(),
                    Type = (ActionExecutionType) ReadInt(),
                    FunctionName = ReadString(),
                    Code = ReadString(),
                    ArgumentsUsed = ReadInt(),
                    ArgumentTypes = Enumerable
                        .Range(0, ReadInt())
                        .Select(j => (ActionArgumentType) ReadInt())
                        .ToArray(),
                    AppliesToObjectIndex = ReadInt(),
                    Relative = ReadBool(),
                    Arguments = Enumerable
                        .Range(0, ReadInt())
                        .Select(j => ReadString())
                        .ToArray(),
                    Not = ReadBool()
                }).ToList();
        }
    }
}
