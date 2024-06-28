using UnityEngine;

public class MapSize : MonoBehaviour
{
    public int mazeX, mazeY;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}