using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleUIAnimator : MonoBehaviour
{

    public SimpleUIAnimation UI_animation;

    public Image image;
    public int currentFrame=0;
    private bool mirrorDirection = true;
    private bool IsPlayed = false;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void Play(SimpleUIAnimation animation)
    {
        UI_animation = animation;
        IsPlayed =true;
        StopAllCoroutines();
        StartCoroutine(animationLoop());
    }

    public void Stop()
    {
        StopAllCoroutines();
        IsPlayed = false;
    }

    private void OnDisable()
    {
       if(IsPlayed) StopAllCoroutines();
    }

    private void OnEnable()
    {
        if (IsPlayed && UI_animation!=null)
        {
            Play(UI_animation);
        }
    }

    IEnumerator animationLoop()
    {
        while (UI_animation != null && gameObject.activeSelf)
        {

            if (mirrorDirection)
            {
                image.sprite = UI_animation.frames[currentFrame++];
                if (currentFrame == UI_animation.frames.Length)
                {
                    currentFrame = UI_animation.frames.Length - 1;
                    mirrorDirection = false;
                }
            }
            else
            {
                image.sprite = UI_animation.frames[currentFrame--];
                if (currentFrame < 0)
                {
                    currentFrame = 0;
                    mirrorDirection = true;
                }
            }

            yield return new WaitForSeconds(UI_animation.duration);

        }
    }
}
