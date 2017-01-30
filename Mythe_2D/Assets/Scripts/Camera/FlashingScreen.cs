using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashingScreen : MonoBehaviour
{
    //shows a bloody screen when the player is hit
    [SerializeField]private float _fadeSpeed;
    private Color _startingColor;
    private bool _fade = false;
    [SerializeField]private Image _flashingImage;
    private Color _red;

    private void Start()
    {
        _red = _flashingImage.color;
        _startingColor = Color.clear;
        _flashingImage.color = _startingColor;
    }

    private void Update()
    {
        FadeToClear();
    }

    private void FadeToClear()
    {
        if (_fade == true && _flashingImage.color != _startingColor)
        {
            StartCoroutine(FadeCoroutine(1.5f));
        }
    }

    private IEnumerator FadeCoroutine(float waitTime)
    {
        _flashingImage.color = Color.Lerp(_flashingImage.color, Color.clear, _fadeSpeed * Time.deltaTime);
        yield return new WaitForSeconds(waitTime);
        _fade = false;

    }

    public void StartFade()
    {
        _flashingImage.color = _red;
        _fade = true;
    }
}
