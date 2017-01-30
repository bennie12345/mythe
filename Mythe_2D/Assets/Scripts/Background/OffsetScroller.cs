using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour
{
    //scrolls background pieces from right to left
    public float ScrollSpeed;

    private void Update()
    {
        var x = Mathf.Repeat(Time.time * ScrollSpeed, 1);
        var offset = new Vector2(x, 0);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
