using UnityEngine;

public class Explode : MonoBehaviour
{
    void AnimationEnd()
    {
        Disable();
    }

    void Disable()
    {
        //Disable the explode anime so it can be reused by the Object Pool
        gameObject.SetActive(false);
    }
}
