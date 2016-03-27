using GameCreator.Engine.Api;
using static GameCreator.Engine.Api.GmlBindingOption;

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