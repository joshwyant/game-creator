using GameCreator.Engine.Api;
using static GameCreator.Engine.Api.GmlBindingOption;

namespace GameCreator.Engine.Library
{
    public interface IMoveFunctions
    {
        [Gml("motion_set")]
        void MotionSet([GmlBinding(CurrentInstance)] GameInstance self, double direction, double speed);
        
        [Gml("motion_add")]
        void MotionAdd([GmlBinding(CurrentInstance)] GameInstance self, double direction, double speed);
        
        [Gml("place_free")]
        bool PlaceFree([GmlBinding(CurrentInstance)] GameInstance self, double x, double y);
        
        [Gml("place_empty")]
        bool PlaceEmpty([GmlBinding(CurrentInstance)] GameInstance self, double x, double y);
        
        [Gml("place_meeting")]
        bool PlaceMeeting([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, int anyId);
        
        [Gml("place_snapped")]
        bool PlaceSnapped([GmlBinding(CurrentInstance)] GameInstance self, int hsnap, int vsnap);
        
        [Gml("move_random")]
        void MoveRandom([GmlBinding(CurrentInstance)] GameInstance self, int hsnap, int vsnap);
        
        [Gml("move_snap")]
        void MoveSnap([GmlBinding(CurrentInstance)] GameInstance self, int hsnap, int vsnap);
        
        [Gml("move_wrap")]
        void MoveWrap([GmlBinding(CurrentInstance)] GameInstance self, bool hor, bool vert, double margin);
        
        [Gml("move_towards_point")]
        void MoveTowardsPoint([GmlBinding(CurrentInstance)] GameInstance self, double x, double y, double speed);
        
        [Gml("move_bounce_solid")]
        void MoveBounceSolid([GmlBinding(CurrentInstance)] GameInstance self, bool advanced);
        
        [Gml("move_bounce_all")]
        void MoveBounceAll([GmlBinding(CurrentInstance)] GameInstance self, bool advanced);
        
        [Gml("move_contact_solid")]
        void MoveContactSolid([GmlBinding(CurrentInstance)] GameInstance self, double dir, double maxdist);
        
        [Gml("move_contact_all")]
        void MoveContactAll([GmlBinding(CurrentInstance)] GameInstance self, double dir, double maxdist);
        
        [Gml("move_outside_solid")]
        void MoveOutsideSolid([GmlBinding(CurrentInstance)] GameInstance self, double dir, double maxdist);
        
        [Gml("move_outside_all")]
        void MoveOutsideAll([GmlBinding(CurrentInstance)] GameInstance self, double dir, double maxdist);
        
        [Gml("distance_to_point")]
        void DistanceToPoint([GmlBinding(CurrentInstance)] GameInstance self, double x, double y);
        
        [Gml("distance_to_object")]
        void DistanceToObject([GmlBinding(CurrentInstance)] GameInstance self, int anyId);
        
        [Gml("position_empty")]
        void PositionEmpty(double x, double y);
        
        [Gml("position_meeting")]
        void PositionMeeting(double x, double y, int anyId);
    }
}