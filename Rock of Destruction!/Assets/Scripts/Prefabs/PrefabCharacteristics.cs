using UnityEngine;

public class PrefabCharacteristics : MonoBehaviour
{
    public float objectStrength;
    public int value;
    public Audio AudioClip;
    internal bool unlock;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            SoundManager.Instance.Vibration();
            Debug.Log(objectStrength);

            if ((PlayerCharacteristics.Instance.strength > objectStrength || PlayerCharacteristics.Instance.strength == objectStrength) && objectStrength > 1)
            {
                SoundManager.Instance.PrefabDestructionSounds(AudioClip);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Collider>().enabled = false;
                GameHelper.Instance.score += value;

                Destroy(gameObject, 2f);
            }
            else if (objectStrength == 1)
            {
                SoundManager.Instance.PrefabDestructionSounds(AudioClip);
                GameHelper.Instance.score += value;

                Destroy(gameObject, 2f);
            }
            else if (PlayerCharacteristics.Instance.strength < objectStrength)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;

                if (PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z < 2)
                {
                    SoundManager.Instance.PlayerDestructionSounds();
                    PlayerController.Instance.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    UIManager.Instance.GameOver();

                    GameHelper.Instance.IncreaseSimpleScore();
                    SoundManager.Instance.BackgroundSound();

                }
                else
                {
                    SoundManager.Instance.PlayerCollisionSounds();
                }
            }
        }
    }
}
