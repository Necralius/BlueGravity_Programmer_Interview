using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class GameManager : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //GameManager - (0.1)
        //State: - (Needs Refactoring, Needs Coments, Needs Improvement)
        //This code represents (Code functionality or code meaning)

        #region - Singleton Pattern -
        public static GameManager Instance;
        private void Awake() => Instance = this;
        #endregion 

        public AudioSource generalAudioSource;

        public void PlaySound(AudioClip clip) => generalAudioSource.PlayOneShot(clip);

    }
}