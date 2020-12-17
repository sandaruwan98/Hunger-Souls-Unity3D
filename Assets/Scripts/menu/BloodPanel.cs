using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodPanel : MonoBehaviour
{
    CanvasGroup canva;
    bool isShowing = false;
    public float duration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        canva = GetComponent<CanvasGroup>();
        
    }

    public void DisplayPanel()
    {
        if(!isShowing)
            StartCoroutine(Fade());
        //isShowing = !isShowing;
    }


    public IEnumerator Fade()
    {
        isShowing = true;
        float start = canva.alpha;
        float counter = 0f;
        float finduration = duration * 0.25f;
        float foutduration = duration * 0.75f;
        while (counter < finduration)
        {
            counter += Time.deltaTime;
            canva.alpha = Mathf.Lerp(0f,1f,counter/ finduration);
            yield return null;
        }
        counter = 0f;
        start = canva.alpha;
        while (counter < foutduration)
        {
            counter += Time.deltaTime;
            canva.alpha = Mathf.Lerp(1f, 0f, counter / foutduration);
            yield return null;
        }
        isShowing = false;
    }


    public IEnumerator Gameover()
    {
       
        float start = canva.alpha;
        float counter = 0f;
        float finduration = duration * 0.5f;
        
        while (counter < finduration)
        {
            counter += Time.deltaTime;
            canva.alpha = Mathf.Lerp(start, 1f, counter / finduration);
            yield return null;
        }
        
    }


}
