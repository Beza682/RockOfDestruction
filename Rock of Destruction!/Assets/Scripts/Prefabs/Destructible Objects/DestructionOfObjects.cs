using System.Collections.Generic;
using UnityEngine;

public class DestructionOfObjects : MonoBehaviour
{
    public float objectStrength;
    public int value;
    public Audio AudioClip;

    private void Start()
    {

    }
    private void Update()
    {
        if (gameObject.transform.position.z < (PlayerController.Instance.gameObject.transform.position.z - 100))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter (Collision other)
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

                if (PlayerController.Instance.gameObject.GetComponent<Rigidbody>().velocity.z < 0)
                {

                    SoundManager.Instance.PlayerDestructionSounds();
                    GameHelper.Instance.IncreaseSimpleScore();
                    UIManager.Instance.GameOver();
                    Destroy(PlayerController.Instance.gameObject);
                }
                else
                {
                    SoundManager.Instance.PlayerCollisionSounds();
                }
            }
        }
    }
}
