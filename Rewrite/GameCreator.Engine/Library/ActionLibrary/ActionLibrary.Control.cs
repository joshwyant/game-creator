using GameCreator.Runtime.Api;

namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Control

        public bool IfEmpty(GameInstance self, double x, double y, bool allObjects, bool relative = false)
        {
            return false;
        }

        public bool IfCollision(GameInstance self, double x, double y, bool allObjects, bool relative = false)
        {
            return false;
        }

        public bool IfObject(GameInstance self, GameObject obj, double x, double y, bool relative = false)
        {
            return false;
        }

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = smaller than,
        /// 2 = larger than
        /// </param>
        public bool IfNumber(GameObject obj, int number, int operation)
        {
            return false;
        }

        public bool IfDice(int sides)
        {
            return false;
        }

        public bool IfQuestion(string question)
        {
            return false;
        }

        public bool If(Value expression)
        {
            return false;
        }

        /// <param name="button">
        /// 0 = no button,
        /// 1 = left,
        /// 2 = right,
        /// 3 = middle
        /// </param>
        public bool IfMouse(int button)
        {
            return false;
        }

        public bool IfAligned(GameInstance self, int snapx, int snapy)
        {
            return false;
        }

        /// <summary>
        /// TODO: This requires context for the current event and object,
        /// which requires support from the game engine, at the least.
        /// </summary>
        public void CallInheritedEvent()
        {
        }

        public void ExecuteScript(GameInstance self, GameScript script, Value arg0, Value arg1, Value arg2, Value arg3,
            Value arg4)
        {
        }

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        public bool IfVariable(GameInstance self, Value result, Value value, int operation)
        {
            return false;
        }

        public void DrawVariable(GameInstance self, Value result, double x, double y, bool relative = false)
        {
        }

        #endregion
    }
}