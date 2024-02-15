using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IEventFunctions
{
    #region Deprecated Functions
    //
    // Introduced in v3.0
    //
    [Gml("perform_create_event", v30, v31)]
    void PerformCreateEvent(int obj);

    [Gml("perform_destroy_event", v30, v31)]
    void PerformDestroyEvent(int obj);

    [Gml("perform_step_event", v30, v31)]
    void PerformStepEvent(int obj);

    [Gml("perform_collision_event", v30, v31)]
    void PerformCollisionEvent(int obj);

    [Gml("perform_alarm_event", v30, v31)]
    void PerformAlarmEvent(int obj, int numb);

    [Gml("perform_mouse_event", v30, v31)]
    void PerformMouseEvent(int obj, int numb);

    [Gml("perform_keyboard_event", v30, v31)]
    void PerformKeyboardEvent(int obj, int key);

    [Gml("perform_meeting_event", v30, v31)]
    void PerformMeetingEvent(int obj, int obj2);

    [Gml("perform_other_event", v30, v31)]
    void PerformOtherEvent(int obj, int numb);
    #endregion

    //
    // Introduced in v4.0
    //

    [Gml("event_perform", v40)]
    void EventPerform(double type, double numb);

    [Gml("event_perform_object", v40)]
    void EventPerformObject(string obj, double type, double numb);

    [Gml("event_user", v40)]
    void EventUser(double numb);
}
