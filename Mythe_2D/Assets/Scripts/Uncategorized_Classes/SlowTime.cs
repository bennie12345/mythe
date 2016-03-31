using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour {

    private float _slowAmount = 0.5f;
    private float _slowDuration = .25f;
    private float _originalTime = 1.0f;

    public void SlowTheTime()
    {
        StartCoroutine(SlowTimeDuration());
    }

    IEnumerator SlowTimeDuration()
    {
        Time.timeScale = _slowAmount;
        yield return new WaitForSeconds(_slowDuration);
        Time.timeScale = _originalTime;
    }

}
