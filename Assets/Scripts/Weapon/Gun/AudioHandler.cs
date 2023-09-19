using UnityEngine;

namespace GunComponents
{
    [RequireComponent(typeof(Controller))]
    [RequireComponent(typeof(AudioSource))]
    internal class AudioHandler : MonoBehaviour
    {
        [SerializeField]
        private AudioClip audioShot;
        [SerializeField]
        private AudioClip audioReload;
        [SerializeField, HideInInspector]
        private AudioSource source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            Controller c = GetComponent<Controller>();
            ShotManager s = GetComponent<ShotManager>();
            s.makeShot += PlayShot;
            c.reloadStart += PlayReload;
        }

        private void OnDisable()
        {
            source.Stop();
        }

        private void OnDestroy()
        {
            Controller c = GetComponent<Controller>();
            ShotManager s = GetComponent<ShotManager>();
            s.makeShot -= PlayShot;
            c.reloadStart -= PlayReload;
        }

        private void PlayShot()
        {

            source.PlayOneShot(audioShot);
        }

        private void PlayReload()
        {
            source.PlayOneShot(audioReload);
        }
    }
}