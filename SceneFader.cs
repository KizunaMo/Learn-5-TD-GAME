using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
        Debug.Log("Active? " + gameObject.activeInHierarchy);
    }

    IEnumerator FadeIn()//協程應用
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a); // 摘要:
                                                  //     Constructs a new Color with given r,g,b,a components.
                                                  // 參數:
                                                  //   r:
                                                  //     Red component.
                                                  //   g:
                                                  //     Green component.
                                                  //   b:
                                                  //     Blue component.
                                                  //   a:
                                                  //     Alpha component.
                                                  //a(alpha的意思)


            yield return 0;
            //yield return null; 暫停協程等待下一幀繼續執行
            //yield return 0或其他數字; 暫停協程等待下一幀繼續執行
            //yield return new WairForSeconds(時間); 等待規定時間後繼續執行
            //yield return StartCoroutine("協程方法名"); 開啟一個協程（巢狀協程)
        }   
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        
        SceneManager.LoadScene(scene);
        Debug.Log("Active? " + gameObject.activeInHierarchy);

    }



}
