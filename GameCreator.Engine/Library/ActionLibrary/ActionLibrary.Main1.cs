using System;

namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Main1

        public void CreateObject(GameInstance self, GameObject obj, double x, double y, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void CreateObjectMotion(GameInstance self, GameObject obj, double x, double y, double speed,
            double direction, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void CreateObjectRandom(GameInstance self, GameObject obj1, GameObject obj2, GameObject obj3,
            GameObject obj4, double x, double y, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void ChangeObject(GameInstance self, GameObject obj, bool performEvents)
        {
            throw new NotImplementedException();
        }

        public void KillObject(GameInstance self)
        {
            throw new NotImplementedException();
        }

        public void KillPosition(GameInstance self, double x, double y, bool relative = false)
        {
            throw new NotImplementedException();
        }

        public void SetSprite(GameInstance self, GameSprite sprite, int subimage, double speed)
        {
            throw new NotImplementedException();
        }

        public void SetSprite(GameInstance self, GameSprite sprite, double scaleFactor)
        {
            throw new NotImplementedException();
        }

        /// <param name="mirroring">
        /// 0 = no mirroring
        /// 1 = mirror horizontally
        /// 2 = flip vertically
        /// 3 = mirror and flip
        /// </param>
        public void TransformSprite(GameInstance self, double xscale, double yscale, double angle, int mirroring)
        {
            throw new NotImplementedException();
        }

        public void SpriteSetColor(GameInstance self, int color, double alpha)
        {
            throw new NotImplementedException();
        }

        public void PlaySound(GameSound sound, bool loop)
        {
            throw new NotImplementedException();
        }

        public void StopSound(GameSound sound)
        {
            throw new NotImplementedException();
        }

        public bool IfSound(GameSound sound)
        {
            throw new NotImplementedException();
        }

        public void GoToPreviousRoom(RoomTransitionKind transitionKind)
        {
            throw new NotImplementedException();
        }

        public void GoToNextRoom(RoomTransitionKind transitionKind)
        {
            throw new NotImplementedException();
        }

        public void RestartCurrentRoom(RoomTransitionKind transitionKind)
        {
            throw new NotImplementedException();
        }

        public void GoToRoom(GameRoom room, RoomTransitionKind transitionKind)
        {
            throw new NotImplementedException();
        }

        public bool IfPreviousRoom()
        {
            throw new NotImplementedException();
        }

        public bool IfNextRoom()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}