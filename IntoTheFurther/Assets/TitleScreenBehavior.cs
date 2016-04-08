using UnityEngine;
using System.Collections;

public class TitleScreenBehavior : MonoBehaviour {

    // Use this for initialization
    public GameObject Title;
    public GameObject StartBtn;
    public GameObject AboutBtn;

    public float sec = 14f;
    void Start()
    {
       // Title = GameObject.Find("Title_Text");
       // StartBtn = GameObject.Find("Start_Btn");
       // AboutBtn = GameObject.Find("About_Btn");

        //StartScreenItem = GameObject.FindGameObjectWithTag("TitleScreenText");
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(sec);
        //StartScreenItem.GetComponent<CanvasGroup>()
      
        Title.SetActive(true);
        StartBtn.SetActive(true);
        AboutBtn.SetActive(true);
    }

}
