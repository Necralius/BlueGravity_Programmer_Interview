using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public AudioSource effectsSource;
        public AudioSource musicSource;
        public AudioSource footstepsSource;

        public List<AudioClip> musics;
        public void PlaySound(AudioClip clip) => effectsSource.PlayOneShot(clip);
        public void PlayFootstepSound(AudioClip clip)
        {
            footstepsSource.volume = Random.Range(0.75f, 1f);
            footstepsSource.pitch = Random.Range(0.85f, 1);
            footstepsSource.PlayOneShot(clip);
        }
        public void MusicManagement()
        {
            if (musicSource.isPlaying) return;
            else musicSource.PlayOneShot(musics[Random.Range(0, musics.Count)]);
        }
        private void Update()
        {
            if (InputManager.Instance.reloadSceneTrigger) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            MusicManagement();
        }
    }
}