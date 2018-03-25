using System;

namespace GameCreator.Engine.Library
{
    public partial class ActionLibrary
    {
        #region Extra

        public void ParticleSystemCreate(double depth)
        {
            throw new NotImplementedException();
        }

        public void ParticleSystemDestroy()
        {
            throw new NotImplementedException();
        }

        public void ParticleSystemClear()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <param name="typeId">0-15</param>
        /// <param name="shapeId">
        /// pixel|disk|square|line|star|circle|ring|sphere|flare|spark|explosion|cloud|smoke|snow
        /// </param>
        public void ParticleTypeCreate(int typeId, int shapeId, GameSprite sprite, double minSize, double maxSize,
            double sizeIncrement)
        {
            throw new NotImplementedException();
        }

        /// <param name="typeId">0-15</param>
        /// <param name="shapeChanging">mixed|changing</param>
        public void ParticleTypeColor(int typeId, bool shapeChanging, int color1, int color2, double startAlpha,
            double endAlpha)
        {
            throw new NotImplementedException();
        }

        /// <param name="typeId">0-15</param>
        public void ParticleTypeLife(int typeId, double minLife, double maxLife)
        {
            throw new NotImplementedException();
        }

        /// <param name="typeId">0-15</param>
        public void ParticleTypeSpeed(int typeId, double minSpeed, double maxSpeed, double minDir, double maxDir,
            double friction)
        {
            throw new NotImplementedException();
        }

        /// <param name="typeId">0-15</param>
        public void ParticleTypeGravity(int typeId, double amount, double direction)
        {
            throw new NotImplementedException();
        }

        /// <param name="typeId">0-15</param>
        /// <param name="stepTypeId">0-15</param>
        /// <param name="deathTypeId">0-15</param>
        public void ParticleTypeSecondary(int typeId, int stepTypeId, int stepCount, int deathTypeId, int deathCount)
        {
            throw new NotImplementedException();
        }

        /// <param name="emitterId">0-7</param>
        /// <param name="shape">rectangle|ellipse|diamond|line</param>
        public void ParticleEmitterCreate(int emitterId, int shape, double xmin, double xmax, double ymin, double ymax)
        {
            throw new NotImplementedException();
        }

        /// <param name="emitterId">0-7</param>
        public void ParticleEmitterDestroy(int emitterId)
        {
            throw new NotImplementedException();
        }

        /// <param name="emitterId">0-7</param>
        /// <param name="typeId">0-15</param>
        public void ParticleEmitterBurst(int emitterId, int typeId, int number)
        {
            throw new NotImplementedException();
        }

        /// <param name="emitterId">0-7</param>
        /// <param name="typeId">0-15</param>
        public void ParticleEmitterStream(int emitterId, int typeId, int number)
        {
            throw new NotImplementedException();
        }

        public void PlayCd(int startTrack, int finalTrack)
        {
            throw new NotImplementedException();
        }

        public void StopCd()
        {
            throw new NotImplementedException();
        }

        public void PauseCd()
        {
            throw new NotImplementedException();
        }

        public void ResumeCd()
        {
            throw new NotImplementedException();
        }

        public bool IfCdExists()
        {
            throw new NotImplementedException();
        }

        public bool IfCdPlaying()
        {
            throw new NotImplementedException();
        }

        public void SetCursor(GameSprite sprite, bool showNativeCursor)
        {
            throw new NotImplementedException();
        }

        public void OpenWebpage(string url)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}