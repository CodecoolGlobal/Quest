using System;

namespace Codecool.Quest.Models
{
    public class PauseManager
    {
        private static PauseManager _singletonPauseManager;
        public static PauseManager SingletonStaticManager => _singletonPauseManager ??= new PauseManager();

        public event Action PauseEvent;

        public event Action UnpauseEvent;

        private PauseManager()
        {

        }

        public void Pause()
        {
            PauseEvent?.Invoke();
        }

        public void UnPause()
        {
            UnpauseEvent?.Invoke();
        }

    }
}