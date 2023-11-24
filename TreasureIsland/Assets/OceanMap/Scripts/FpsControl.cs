using UnityEngine;
public class FPSCapper : MonoBehaviour
{    
    public int targetFPS = 60;
    private void Awake()
    {
        Application.targetFrameRate = targetFPS;
    }
}