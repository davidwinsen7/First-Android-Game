using UnityEngine;

public class settingsValue : MonoBehaviour
{
    public bool music = true;
    public bool SFX = true;

    public static settingsValue instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
