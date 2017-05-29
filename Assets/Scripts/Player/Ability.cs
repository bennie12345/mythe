using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    [SerializeField] protected GameObject AbilityGameObject;

    [SerializeField] protected float AbilityDuration;

    [SerializeField] protected string AnimationBoolName;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected void UseAbility()
    {
        StartCoroutine(ActivateAbility(AbilityGameObject, AbilityDuration));
    }

    private IEnumerator ActivateAbility(GameObject ability, float abilityDuration)
    {
        ability.SetActive(true);
        _animator.SetBool(AnimationBoolName, true);
        yield return new WaitForSeconds(abilityDuration);
        _animator.SetBool(AnimationBoolName, false);
        ability.SetActive(false);
    }

}
