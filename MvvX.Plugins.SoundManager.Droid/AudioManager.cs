using Android.Content;
using Android.Media;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid;

namespace MvvX.Plugins.SoundManager.Droid
{
    /// <summary>
    /// Controls audio
    /// </summary>
    public class AudioManager : IAudioManager
    {
        #region Master Volume Manipulation

        /// <summary>
        /// Gets the current master volume in scalar values (percentage)
        /// </summary>
        /// <returns>-1 in case of an error, if successful the value will be between 0 and 100</returns>
        public float GetMasterVolume()
        {
            var context = Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext;
            var audioManager = context.GetSystemService(Context.AudioService) as Android.Media.AudioManager;
            return audioManager.GetStreamVolume(Stream.Music);
        }

        private readonly VolumeNotificationFlags _notificationFlags;

        /// <summary>
        /// Sets the master volume to a specific level
        /// </summary>
        /// <param name="newLevel">Value between 0 and 100 indicating the desired scalar value of the volume</param>
        public void SetMasterVolume(float newLevel)
        {
            var context = Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext;
            var audioManager = context.GetSystemService(Context.AudioService) as Android.Media.AudioManager;
            var maxVolume = audioManager.GetStreamMaxVolume(Stream.Music);
            var volume = (maxVolume / 100.0f) * newLevel;
            audioManager.SetStreamVolume(Stream.Music, (int)volume, _notificationFlags);
        }

        /// <summary>
        /// Gets the mute state of the master volume. 
        /// While the volume can be muted the <see cref="GetMasterVolume"/> will still return the pre-muted volume value.
        /// </summary>
        /// <returns>false if not muted, true if volume is muted</returns>
        public bool GetMasterVolumeMute()
        {
            return GetMasterVolume() == 0;
        }

        private float oldMasterVolume = 0F;
        /// <summary>
        /// Mute or unmute the master volume
        /// </summary>
        /// <param name="isMuted">true to mute the master volume, false to unmute</param>
        public void SetMasterVolumeMute(bool isMuted)
        {
            if (isMuted)
            {
                oldMasterVolume = GetMasterVolume();
                SetMasterVolume(0);
            }
            else
                SetMasterVolume(oldMasterVolume);
        }

        #endregion

        #region Play sounds

        /// <summary>
        /// Play a media file on the computer
        /// </summary>
        /// <param name="soundFilePath"></param>
        public void Play(string soundFilePath)
        {
            
        }
        
        #endregion
    }
}
