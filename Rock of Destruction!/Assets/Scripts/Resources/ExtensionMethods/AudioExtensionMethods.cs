using UnityEngine;

static class AudioExtensionMethods
{
    public static AudioClip GetRandom(this AudioClip[] audioClip)
    {
        return audioClip[Random.Range(0, audioClip.Length)];
    }
}
