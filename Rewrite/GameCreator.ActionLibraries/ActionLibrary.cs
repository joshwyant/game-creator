using System;
using System.Collections.Generic;

namespace GameCreator.ActionLibraries
{
    public class ActionLibrary
    {
        public int GameMakerVersion { get; set; }
        public string Author { get; set; }
        public int LibraryID { get; set; }
        public string TabCaption { get; set; }
        public int Version { get; set; }
        public DateTime LastChanged { get; set; }
        public string Info { get; set; }
        public string InitializationCode { get; set; }
        public bool AdvancedModeOnly { get; set; }
        public int LastActionId { get; set; }
        public List<ActionDefinition> Actions { get; set; }
        
        public ActionLibrary()
        {
            GameMakerVersion = 520;
            TabCaption = string.Empty;
            LibraryID = new Random().Next(1000, 1000000000);
            Author = string.Empty;
            Version = 100;
            LastChanged = DateTime.Now;
            Info = string.Empty;
            InitializationCode = string.Empty;
            AdvancedModeOnly = false;
            LastActionId = 0;
            Actions = new List<ActionDefinition>();
        }

        
    }
}