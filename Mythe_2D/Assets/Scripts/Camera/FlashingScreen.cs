using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashingScreen : MonoBehaviour {

    [SerializeField]private Image flashingImage;
    [SerializeField]private float fadeSpeed;
    private Color startingColor;
    private bool fade = false;

	void Start () {
        //flashingImage.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        flashingImage.enabled = true;
        startingColor = flashingImage.color;
    }
	
	void Update () {
        if(flashingImage.color == Color.clear)
        {
            flashingImage.color = startingColor;
            fade = false;
        }
        if (fade)
        {
            FadeToClear();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fade = true;
        }
	}

    void FadeToClear()
    {
        flashingImage.color = Color.Lerp(flashingImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
}
