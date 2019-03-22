using UnityEngine;

public class Explode : MonoBehaviour
{
    void AnimationEnd()
    {
        Destroy(gameObject);
    }
}
