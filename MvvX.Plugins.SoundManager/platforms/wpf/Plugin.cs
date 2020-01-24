using MvvmCross;
using MvvmCross.Plugin;

namespace MvvX.Plugins.SoundManager.Wpf
{
    [MvxPlugin]
    [Preserve(AllMembers=true)]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.IoCProvider.RegisterSingleton<IAudioManager>(new AudioManager());
        }
    }
}