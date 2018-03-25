namespace GameCreator.Engine.Library
{
    public enum RoomTransitionKind
    {
        NoTransition,
        CreateFromLeft,
        CreateFromTop,
        CreateFromRight,
        CreateFromBottom,
        CreateFromCenter,
        PushFromLeft,
        PushFromTop,
        PushFromRight,
        PushFromBottom,
        ShiftFromLeft,
        ShiftFromTop,
        ShiftFromRight,
        ShiftFromBottom,
        InterlacedFromLeft,
        InterlacedFromTop,
        InterlacedFromRight,
        InterlacedFromBottom
    }
}