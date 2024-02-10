using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GmlBindingOption;

namespace GameCreator.Engine.Library
{
    public interface IPathFunctions
    {
        [Gml("path_start")]
        void PathStart([GmlBinding(CurrentInstance)] GameInstance self, GamePath path, double speed, 
            PathEndAction endAction, bool absolute);
        
        [Gml("path_end")]
        void PathEnd();
    }
}