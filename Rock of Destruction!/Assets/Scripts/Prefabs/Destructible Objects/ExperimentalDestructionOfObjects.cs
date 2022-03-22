using UnityEngine;

//Это экспериментальный скрипт на разрушение объекта с распадом на кусочки. Сейчас он нигде не используется.
public class ExperimentalDestructionOfObjects : MonoBehaviour
{
    private float pieceSize = 1;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Explode();
        }
    }
    private void Explode()
    {
        for (int x = 0; x < gameObject.transform.localScale.x; x++)
        {
            for (int y = 0; y < gameObject.transform.localScale.y; y++)
            {
                for (int z = 0; z < gameObject.transform.localScale.z; z++)
                {
                    if (!(x < 0 && x > gameObject.transform.localScale.x && y < 0 && y > gameObject.transform.localScale.y && z < 0 && z > gameObject.transform.localScale.z))
                    {
                        CreatePiece(x, y, z);

                    }
                }
            }
        }
        Destroy(gameObject);
    }
    private void CreatePiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = transform.position + new Vector3(x, y, z) - new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y / 2, gameObject.transform.localScale.z / 2);
        piece.transform.localScale = new Vector3(pieceSize, pieceSize, pieceSize);

        piece.AddComponent<Rigidbody>().mass = 0.002f;
        Destroy(piece, 2f);
    }

}
