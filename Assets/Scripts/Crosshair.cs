
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public RectTransform rectL;
    public RectTransform rectR;
    public float speed= 2f;
    public float maxsize= 2f;
    public float restsize= 2f;
    float currentsize= 2f;
    // Start is called before the first frame update
    void Start()
    {
        //rect = GetComponent<RectTransform>();
        currentsize = restsize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0f || Input.GetAxis("Horizontal") != 0f || Input.GetButton("Fire1"))
        {
            currentsize = Mathf.Lerp(currentsize,maxsize,Time.deltaTime*speed);
        }
        else
        {
            currentsize = Mathf.Lerp(currentsize, restsize, Time.deltaTime * speed);
        }

        rectL.localPosition = new Vector3(-currentsize, 0, 0);
        rectR.localPosition = new Vector3(currentsize, 0, 0);
       // rect.sizeDelta = new Vector2(currentsize, restsize);
    }
}
