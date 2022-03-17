using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveController.Save(Data.Instance);
        }
    }
}
