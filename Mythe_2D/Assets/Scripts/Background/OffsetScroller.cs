using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour
{
    public float scrollSpeed;
    
    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, 0);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
