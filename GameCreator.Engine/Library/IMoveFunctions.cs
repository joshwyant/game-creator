using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;
public interface IMoveFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v1.1
    //
    [Gml("move_random", v11, v33)]
    void MoveRandom(int obj);

    [Gml("is_free", v11, v33)]
    bool IsFree(double x, double y);

    [Gml("is_empty", v11, v33)]
    bool IsEmpty(double x, double y);

    [Gml("is_meeting", v11, v33)]
    bool IsMeeting(double x, double y, int obj);

    // Introduced in v1.2
    [Gml("nothing_at", v12, v33)]
    bool NothingAt(double x, double y);

    [Gml("object_at", v12, v33)]
    bool ObjectAt(double x, double y, int obj);
    
    //
    // Introduced in v3.0
    //
    [Gml("set_motion", v30, v33)]
    void SetMotion(int dir, double speed);

    [Gml("add_motion", v30, v33)]
    void AddMotion(int dir, double speed);

    [Gml("bounce", v30, v33)]
    void Bounce();

    [Gml("is_aligned", v30, v33)]
    bool IsAligned();

    [Gml("align", v30, v33)]
    void Align();

    [Gml("set_collision_mode", v30, v33)]
    void SetCollisionMode(int val);

    //
    // Introduced in v3.1
    //
    [Gml("move_towards", v31, v33)]
    void MoveTowards(double x, double y);

    //
    // Introduced in v3.3
    //
    [Gml("move_contact", v33, v33)]
    void MoveContact();
    #endregion

    //
    // Introduced in v3.1
    //
    [Gml("distance_to_point", v31)]
    double DistanceToPoint(double x, double y);

    [Gml("distance_to_object", v31)]
    double DistanceToObject(string obj);

    //
    // Introduced in v4.0
    //
    [Gml("motion_set", v40)]
    void MotionSet(double dir, double speed);

    [Gml("motion_add", v40)]
    void MotionAdd(double dir, double speed);

    [Gml("place_free", v40)]
    double PlaceFree(double x, double y);

    [Gml("place_empty", v40)]
    double PlaceEmpty(double x, double y);

    [Gml("place_meeting", v40)]
    double PlaceMeeting(double x, double y, string obj);

    [Gml("place_snapped", v40)]
    double PlaceSnapped(double hsnap, double vsnap);

    [Gml("move_random", v40)]
    void MoveRandom(double hsnap, double vsnap);

    [Gml("move_snap", v40)]
    void MoveSnap(double hsnap, double vsnap);

    [Gml("move_towards_point", v40)]
    void MoveTowardsPoint(double x, double y, double sp);

    [Gml("move_bounce_solid", v40)]
    void MoveBounceSolid(double adv);

    [Gml("move_bounce_all", v40)]
    void MoveBounceAll(double adv);

    [Gml("move_contact", v40)]
    void MoveContact(double dir);

    [Gml("position_empty", v40)]
    double PositionEmpty(double x, double y);

    [Gml("position_meeting", v40)]
    double PositionMeeting(double x, double y, string obj);

    //
    // Introduced in v5.0
    //
    [Gml("move_contact_solid", v50)]
    bool MoveContactSolid(int dir, double maxdist);

    [Gml("move_contact_all", v50)]
    bool MoveContactAll(int dir, double maxdist);

    [Gml("move_outside_solid", v50)]
    bool MoveOutsideSolid(int dir, double maxdist);

    [Gml("move_outside_all", v50)]
    bool MoveOutsideAll(int dir, double maxdist);
}