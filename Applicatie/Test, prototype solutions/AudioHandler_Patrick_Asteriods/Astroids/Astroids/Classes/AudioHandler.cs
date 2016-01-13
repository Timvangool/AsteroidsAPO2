using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Asteroids.Classes
{
    class AudioHandler : Microsoft.Xna.Framework.GameComponent
    {
        private Song menuBackgroundMusic;
        private Song gameplayBackgroundMusic;
        private Song AmbientBackgroundMusic;
        private SoundEffect largeAsteroidExploding;
        private SoundEffect mediumAsteroidExploding;
        private SoundEffect smallAsteroidExploding;
        private SoundEffect menuClick;
        private SoundEffect spaceshipExploding;
        private SoundEffect spaceShipFiring;
        private SoundEffect spaceShipThrustAlternative;

        public AudioHandler(Game game)
            :base(game)
        {
        }

        public override void Initialize()
        {
            MediaPlayer.Volume = 0.5f;
            base.Initialize();
        }

        public void Load(ContentManager content)
        {
            menuBackgroundMusic = content.Load<Song>("Audio\\BackgroundMusic\\Menu_Background");
            gameplayBackgroundMusic = content.Load<Song>("Audio\\BackgroundMusic\\Game_Background");
            AmbientBackgroundMusic = content.Load<Song>("Audio\\BackgroundMusic\\Ambient_Background");
            largeAsteroidExploding = content.Load<SoundEffect>("Audio\\SoundEffects\\Large_Asteroid_Exploding");
            mediumAsteroidExploding = content.Load<SoundEffect>("Audio\\SoundEffects\\Medium_Asteroid_Exploding");
            smallAsteroidExploding = content.Load<SoundEffect>("Audio\\SoundEffects\\Small_Asteroid_Exploding");
            menuClick = content.Load<SoundEffect>("Audio\\SoundEffects\\Menu_Click");
            spaceshipExploding = content.Load<SoundEffect>("Audio\\SoundEffects\\Small_Asteroid_Exploding");
            spaceShipFiring = content.Load<SoundEffect>("Audio\\SoundEffects\\SpaceShip_Firing");
            spaceShipThrustAlternative = content.Load<SoundEffect>("Audio\\SoundEffects\\SpaceShip_Thrust_Alternative");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void PlayBackgroundMusic(string soundName)
        {
            if (soundName == "Menu_Background")
            {
                MediaPlayer.Volume = 0.5f;
                MediaPlayer.Play(menuBackgroundMusic);
                MediaPlayer.IsRepeating = true;
            }
            if (soundName == "Game_Background")
            {
                MediaPlayer.Volume = 0.3f;
                MediaPlayer.Play(gameplayBackgroundMusic);
                MediaPlayer.IsRepeating = true;
            }
            if (soundName == "Ambient_Background")
            {
                MediaPlayer.Play(AmbientBackgroundMusic);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlaySoundEffect(string soundEffectName)
        {
            //if (soundEffectName == "Ambient_Background")
            //{
            //    SoundEffectInstance inst;
            //    inst = AmbientBackgroundMusic.CreateInstance();
            //    inst.IsLooped = true;
            //    inst.Play();
            //}

            if (soundEffectName == "Large_Asteroid_Exploding")
            {
                new System.Threading.Thread(() =>
                {
                    SoundEffectInstance inst;
                    inst = largeAsteroidExploding.CreateInstance();
                    inst.Play();
                }).Start();
            }

            if (soundEffectName == "Medium_Asteroid_Exploding")
            {
                new System.Threading.Thread(() =>
                {
                    SoundEffectInstance inst;
                    inst = mediumAsteroidExploding.CreateInstance();
                    inst.Play();
                }).Start();
            }

            if (soundEffectName == "Small_Asteroid_Exploding")
            {
                new System.Threading.Thread(() =>
                {
                    SoundEffectInstance inst;
                    inst = smallAsteroidExploding.CreateInstance();
                    inst.Play();
                }).Start();
            }

            if (soundEffectName == "Menu_Click")
            {
                new System.Threading.Thread(() =>
                {
                    SoundEffectInstance inst;
                    inst = menuClick.CreateInstance();
                    inst.Play();
                }).Start();
            }

            if (soundEffectName == "Spaceship_Exploding")
            {
                new System.Threading.Thread(() =>
                {
                    SoundEffectInstance inst;
                    inst = spaceshipExploding.CreateInstance();
                    inst.Play();
                }).Start();
            }

            if (soundEffectName == "SpaceShip_Firing")
            {
                new System.Threading.Thread(() =>
                {
                    SoundEffectInstance inst;
                    inst = spaceShipFiring.CreateInstance();
                    inst.Play();
                }).Start();
            }

            if (soundEffectName == "SpaceShip_Thrust_Alternative")
            {
                new System.Threading.Thread(() =>
                {
                    SoundEffectInstance inst;
                    inst = spaceShipThrustAlternative.CreateInstance();
                    inst.Play();
                }).Start();
            }
        }
    }
}
