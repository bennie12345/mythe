using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour {

    private float _slowAmout = 0.75f;
    private float _slowDuration = 0.15f;
    private float _originalTime = 1.0f;

    public void SlowTheTime()
    {
        StartCoroutine(SlowTimeDuration());
    }

    IEnumerator SlowTimeDuration()
    {
        Time.timeScale = _slowAmout;
        yield return new WaitForSeconds(_slowDuration);
        Time.timeScale = _originalTime;
    }

}
