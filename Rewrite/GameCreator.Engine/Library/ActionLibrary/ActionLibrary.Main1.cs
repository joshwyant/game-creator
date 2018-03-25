namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Main1

        public void CreateObject(GameInstance self, GameObject obj, double x, double y, bool relative = false)
        {
        }

        public void CreateObjectMotion(GameInstance self, GameObject obj, double x, double y, double speed,
            double direction, bool relative = false)
        {
        }

        public void CreateObjectRandom(GameInstance self, GameObject obj1, GameObject obj2, GameObject obj3,
            GameObject obj4, double x, double y, bool relative = false)
        {
        }

        public void ChangeObject(GameInstance self, GameObject obj, bool performEvents)
        {
        }

        public void KillObject(GameInstance self)
        {
        }

        public void KillPosition(GameInstance self, double x, double y, bool relative = false)
        {
        }

        public void SetSprite(GameInstance self, GameSprite sprite, int subimage, double speed)
        {
        }

        public void SetSprite(GameInstance self, GameSprite sprite, double scaleFactor)
        {
        }

        /// <param name="mirroring">
        /// 0 = no mirroring
        /// 1 = mirror horizontally
        /// 2 = flip vertically
        /// 3 = mirror and flip
        /// </param>
        public void TransformSprite(GameInstance self, double xscale, double yscale, double angle, int mirroring)
        {
        }

        public void SpriteSetColor(GameInstance self, int color, double alpha)
        {
        }

        public void PlaySound(GameSound sound, bool loop)
        {
        }

        public void StopSound(GameSound sound)
        {
        }

        public bool IfSound(GameSound sound)
        {
            return false;
        }

        public void GoToPreviousRoom(RoomTransitionKind transitionKind)
        {
        }

        public void GoToNextRoom(RoomTransitionKind transitionKind)
        {
        }

        public void RestartCurrentRoom(RoomTransitionKind transitionKind)
        {
        }

        public void GoToRoom(GameRoom room, RoomTransitionKind transitionKind)
        {
        }

        public bool IfPreviousRoom()
        {
            return false;
        }

        public bool IfNextRoom()
        {
            return false;
        }

        #endregion
    }
}