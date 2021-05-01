using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleEntityView : MonoBehaviour
{
    [SerializeField]
    private Image portrait;
    [SerializeField]
    private Sprite defaultPortrait;
    [SerializeField]
    SmoothScaleBar scaleBar;

    Character currentCharacter;

    [SerializeField]
    GameObject damageEffect;

    int dir;

    [SerializeField]
    private GameObject textName;



    public void SetCharacter(Character character, int direction=1)
    {
        dir = direction;
        currentCharacter = character;

        if (character is IPortraitable)
        {
            portrait.sprite = ((IPortraitable)character).getPortrait();
        }
        else portrait.sprite = defaultPortrait;

        var l =transform.localScale;
        transform.localScale = new Vector3(l.x*direction, l.y, l.z);

        UpdateHealth(character.CurrentHealth);
        currentCharacter.OnDealedHealthDamage += entityDamageChange;
        currentCharacter.OnAttack += entityAttack;

        if(character is Enemy)
        {
            textName.SetActive(true);
            textName.GetComponent<Text>().text = character.EntityName;
        }
    }

    private void entityDamageChange(int damage)
    {
        StartCoroutine(createDamageEffect(damage));
    }

    private void entityAttack(Character attacker, Character defender)
    {
        StartCoroutine(createAttackEffect());
    }

    private IEnumerator createAttackEffect()
    {
        var pos = transform.position;
        transform.DOLocalMoveX(dir * 70f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        if(this!=null) transform.DOMove(pos, 0.5f);
    }

    private IEnumerator createDamageEffect(int damage)
    {
        yield return new WaitForSeconds(0.6f);
        if (this != null)
        {
            transform.DOShakeRotation(1.2f, Vector3.forward * 20);
            var effect = Instantiate(damageEffect, transform.parent);
            effect.GetComponent<DamageEffect>().SetValue(damage);
            effect.transform.position = transform.position;

            UpdateHealth(currentCharacter.CurrentHealth);
        }

    }

    public void UpdateHealth(int health)
    {
        if (currentCharacter != null)
        {
            scaleBar.SetScaleSmooth((float)health / (float)currentCharacter.MaxHealth);
        }
    }

    public void ClearCharacter()
    {
        StopAllCoroutines();
        if (currentCharacter != null) 
        {
            currentCharacter.OnAttack -= entityAttack;
            currentCharacter.OnDealedHealthDamage -= entityDamageChange;
        } 
    }

    private void OnDestroy()
    {
        ClearCharacter();
    }
}
