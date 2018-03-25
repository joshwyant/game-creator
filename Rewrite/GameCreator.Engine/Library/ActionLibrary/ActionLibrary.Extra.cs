namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Extra

        public void ParticleSystemCreate(double depth)
        {
        }

        public void ParticleSystemDestroy()
        {
        }

        public void ParticleSystemClear()
        {
        }

        /// <param name="typeId">
        /// 0-15
        /// </param>
        /// <param name="shapeId">
        /// pixel|disk|square|line|star|circle|ring|sphere|flare|spark|explosion|cloud|smoke
        /// </param>
        public void ParticleTypeCreate(int typeId, int shapeId, double minSize, double maxSize, int startColor,
            int endColor)
        {
        }

        /// <param name="typeId">0-15</param>
        /// <param name="shapeId">
        /// pixel|disk|square|line|star|circle|ring|sphere|flare|spark|explosion|cloud|smoke|snow
        /// </param>
        public void ParticleTypeCreate(int typeId, int shapeId, GameSprite sprite, double minSize, double maxSize,
            double sizeIncrement)
        {
        }

        /// <param name="typeId">0-15</param>
        /// <param name="shapeChanging">mixed|changing</param>
        public void ParticleTypeColor(int typeId, bool shapeChanging, int color1, int color2, double startAlpha,
            double endAlpha)
        {
        }

        /// <param name="typeId">0-15</param>
        public void ParticleTypeLife(int typeId, double minLife, double maxLife)
        {
        }

        /// <param name="typeId">0-15</param>
        public void ParticleTypeSpeed(int typeId, double minSpeed, double maxSpeed, double minDir, double maxDir,
            double friction)
        {
        }

        /// <param name="typeId">0-15</param>
        public void ParticleTypeGravity(int typeId, double amount, double direction)
        {
        }

        /// <param name="typeId">0-15</param>
        /// <param name="stepTypeId">0-15</param>
        /// <param name="deathTypeId">0-15</param>
        public void ParticleTypeSecondary(int typeId, int stepTypeId, int stepCount, int deathTypeId, int deathCount)
        {
        }

        /// <param name="emitterId">0-7</param>
        /// <param name="shape">rectangle|ellipse|diamond|line</param>
        public void ParticleEmitterCreate(int emitterId, int shape, double xmin, double xmax, double ymin, double ymax)
        {
        }

        /// <param name="emitterId">0-7</param>
        public void ParticleEmitterDestroy(int emitterId)
        {
        }

        /// <param name="emitterId">0-7</param>
        /// <param name="typeId">0-15</param>
        public void ParticleEmitterBurst(int emitterId, int typeId, int number)
        {
        }

        /// <param name="emitterId">0-7</param>
        /// <param name="typeId">0-15</param>
        public void ParticleEmitterStream(int emitterId, int typeId, int number)
        {
        }

        public void PlayCd(int startTrack, int finalTrack)
        {
            
        }

        public void StopCd()
        {
            
        }

        public void PauseCd()
        {
            
        }

        public void ResumeCd()
        {
            
        }

        public bool CdExists()
        {
            return false;
        }

        public bool CdPlaying()
        {
            return false;
        }

        public void SetCursor(GameSprite sprite, bool showNativeCursor)
        {
            
        }

        public void OpenWebpage(string url)
        {
            
        }

        #endregion
    }
}