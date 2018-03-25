using System;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Control

        public bool IfEmpty(GameInstance self, double x, double y, bool allObjects, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public bool IfCollision(GameInstance self, double x, double y, bool allObjects, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public bool IfObject(GameInstance self, GameObject obj, double x, double y, bool relative = false)
        {
            throw new NotImplementedException();
        }

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = smaller than,
        /// 2 = larger than
        /// </param>
        public bool IfNumber(GameObject obj, int number, int operation)
        {
            throw new NotImplementedException();
        }

        public bool IfDice(int sides)
        {
            throw new NotImplementedException();
        }

        public bool IfQuestion(string question)
        {
            throw new NotImplementedException();
        }

        public bool If(Variant expression)
        {
            throw new NotImplementedException();
        }

        /// <param name="button">
        /// 0 = no button,
        /// 1 = left,
        /// 2 = right,
        /// 3 = middle
        /// </param>
        public bool IfMouse(int button)
        {
            throw new NotImplementedException();
        }

        public bool IfAligned(GameInstance self, int snapx, int snapy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: This requires context for the current event and object,
        /// which requires support from the game engine, at the least.
        /// </summary>
        public void CallInheritedEvent()
        {
            throw new NotImplementedException();
        }

        public void ExecuteScript(GameInstance self, GameScript script, Variant arg0, Variant arg1, Variant arg2, Variant arg3,
            Variant arg4)
        {
            throw new NotImplementedException();
        }

        /// <param name="operation">
        /// 0 = equal to,
        /// 1 = less than,
        /// 2 = greater than
        /// </param>
        public bool IfVariable(GameInstance self, Variant result, Variant value, int operation)
        {
            throw new NotImplementedException();
        }

        public void DrawVariable(GameInstance self, Variant result, double x, double y, bool relative = false)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}