using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    public static PlayerCharacteristics Instance;

    internal float strength;
    internal float size;
    private Vector3 vector3 = new Vector3(1f, 1f, 1f);

    private void Awake()
    {
        Instance = this;

        strength = 2 + Data.Instance.upgradeLevel.strengthLevel * 0.5f;
        size = 1 + Data.Instance.upgradeLevel.sizeLevel * 0.2f;
        PlayerGrowth();
    }
    private void Update()
    {
        if (size > 1.2f && Mathf.Round(transform.position.z + 10) % 60 == 0 )
        {
            size -= 0.1f;
            PlayerGrowth();
        }
    }

    public void PlayerGrowth()
    {
        transform.localScale = vector3 * size;
        gameObject.GetComponent<Rigidbody>().mass = size * 1.5f;
    }
}