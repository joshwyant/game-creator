using GameCreator.Engine.Api;
using static GameCreator.Engine.Api.GmlBindingOption;

namespace GameCreator.Engine.Library
{
    public interface IMotionPlanningFunctions
    {
        [Gml("mp_linear_step")]
        bool LinearStep([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, double stepsize, 
            bool checkall);
        
        [Gml("mp_linear_step_object")]
        bool LinearStepObject([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, double stepsize, 
            int anyId);
        
        [Gml("mp_potential_step")]
        bool PotentialStep([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, double stepsize, 
            bool checkall);
        
        [Gml("mp_potential_step_object")]
        bool PotentialStepObject([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, double stepsize, 
            int anyId);

        [Gml("mp_potential_settings")]
        void PotentialSettings(double maxrot, double rotstep, double ahead, double onspot);
        
        
    }
}