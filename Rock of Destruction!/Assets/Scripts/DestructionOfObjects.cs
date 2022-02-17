using UnityEngine;

public class DestructionOfObjects : MonoBehaviour
{
    private float strength;
    private float value;


    private void Start()
    {

    }

    private void OnCollisionEnter (Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            switch (tag)
            {
                case "Small":

                    switch (name)
                    {
                        case "Human":

                            value = 50f;

                            break;

                        case "Barrier":

                            value = 10f;

                            break;

                        case "Tree":

                            value = 80f;

                            break;
                    }

                    GameHelper.singleton.score += value;
                    Destroy(gameObject, 2f);

                    break;
               
                case "Large":

                    switch (name)
                    {
                        case "Gate":

                            value = 1000f;

                            break;

                        case "PassageWalls":

                            value = 1500f;

                            break;

                        case "Wall":

                            value = 800f;

                            break;

                        case "Tower":

                            value = 500f;

                            break;

                        case "House":

                            value = 200f;

                            break;

                        case "Alcove":

                            value = 100f;

                            break;
                    }

                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<Collider>().enabled = false;

                    GameHelper.singleton.score += value;

                    Destroy(gameObject, 2f);

                    break;
            }
        }
    }
}
