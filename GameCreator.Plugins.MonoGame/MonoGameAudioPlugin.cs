using System;
using System.Collections.Generic;
using System.IO;
using GameCreator.Engine.Api;
using Microsoft.Xna.Framework.Audio;

namespace GameCreator.Plugins.MonoGame
{
    internal sealed class MonoGameAudioPlugin : IAudioPlugin, IDisposable
    {
        private GameCreatorXnaGame Game { get; }
        private readonly List<SoundEffect> SoundEffects = new List<SoundEffect>();

        public MonoGameAudioPlugin(GameCreatorXnaGame game)
        {
            Game = game;
        }

        public ISoundEffect LoadSound(Stream stream)
        {
            var effect = SoundEffect.FromStream(stream);
            var info = new SoundInfo(effect);
            return info;
        }

        public void PlaySound(ISoundEffect sound)
        {
            var info = (SoundInfo) sound;

            info.SoundEffect.Play();
        }

        public void Dispose()
        {
            SoundEffects.ForEach(s => s.Dispose());
            SoundEffects.Clear();
        }
    }
}