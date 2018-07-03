namespace MvvX.Plugins.SoundManager
{
    public interface IAudioManager
    {
        /// <summary>
        /// Gets the current master volume in scalar values (percentage)
        /// </summary>
        /// <returns>-1 in case of an error, if successful the value will be between 0 and 100</returns>
        float GetMasterVolume();

        /// <summary>
        /// Sets the master volume to a specific level
        /// </summary>
        /// <param name="newLevel">Value between 0 and 100 indicating the desired scalar value of the volume</param>
        void SetMasterVolume(float newLevel);

        /// <summary>
        /// Gets the mute state of the master volume. 
        /// While the volume can be muted the <see cref="GetMasterVolume"/> will still return the pre-muted volume value.
        /// </summary>
        /// <returns>false if not muted, true if volume is muted</returns>
        bool GetMasterVolumeMute();

        /// <summary>
        /// Mute or unmute the master volume
        /// </summary>
        /// <param name="isMuted">true to mute the master volume, false to unmute</param>
        void SetMasterVolumeMute(bool isMuted);

        /// <summary>
        /// Play a media file on the computer
        /// Actually, the media must be a .wav file
        /// </summary>
        /// <param name="soundFilePath"></param>
        void Play(string soundFilePath);
    }
}
