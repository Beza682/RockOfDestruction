using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    [SerializeField] private int activationDistance;
    private void Update()
    {
        if (gameObject.transform.position.z < (PlayerController.Instance.gameObject.transform.position.z - activationDistance))
        {
            Destroy(gameObject);
        }
    }
}
