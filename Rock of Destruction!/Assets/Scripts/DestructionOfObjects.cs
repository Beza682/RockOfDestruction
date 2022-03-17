using System.Collections.Generic;
using UnityEngine;

public class DestructionOfObjects : MonoBehaviour
{
    public float objectStrength;
    public float value;
    public int AudioClip;

    public static List<GameObject> destructibleObjects;
    public static float playerStrength;

    private void Start()
    {
        //playerStrength = GameHelper.Instance.playerStrength;
        //Debug.Log(playerStrength);
    }
    private void Update() // »нстанс, который смотрит координату Z персонажа
    {
        
    }
    private void OnCollisionEnter (Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //SoundManager.Vibration();
            SoundManager.Instance.Vibration();
            SoundManager.Instance.CollisionSounds(AudioClip);

            //Debug.Log(value);
            //Debug.Log(objectStrength);
            //Debug.Log(playerStrength);

            if ((playerStrength > objectStrength || playerStrength == objectStrength) && objectStrength > 1)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Collider>().enabled = false;

                GameHelper.Instance.score += value;

                Destroy(gameObject, 2f);
                //GameHelper.Instance.destructibleObjects.Remove(gameObject);
                destructibleObjects.Remove(gameObject);


            }
            else if (objectStrength == 1)
            {
                GameHelper.Instance.score += value;

                Destroy(gameObject, 2f);
                //GameHelper.Instance.destructibleObjects.Remove(gameObject);
                destructibleObjects.Remove(gameObject);


            }
            else if (playerStrength < objectStrength)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                //Destroy(GameHelper.Instance.player);
            }
        }
    }
}
