using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    //public variable of type imagge
    public Image fading_image;
    public AnimationCurve curve;

    void tart()
    {
        
        StartCoroutine(FadeIn());
    }
    public void TrasitionFade(int scene)
    {
        StartCoroutine(fadeOut(scene));
    }
    //two functions.fading in and fading out

    IEnumerator FadeIn()
    {
        float time = 0f;

        while (time > 1f)
        {
            time += Time.deltaTime; //this will wait a small amount of time
            float alphaValue = curve.Evaluate(time);
            fading_image.color = new Color(0f, 0f, 0f, alphaValue);
            yield return 0; //this will skip to the next frame
        }
        

        //then it will load a scene
    }
  

  


    IEnumerator fadeOut(int scene)
    {
        float time = 1f;

        while (time > 0f)
        {
            time -= Time.deltaTime; //this will wait a small amount of time
            float alphaValue = curve.Evaluate(time);
            fading_image.color = new Color(0f, 0f, 0f,alphaValue);
            yield return 0; //this will skip to the next frame
        }
        SceneManager.LoadScene(scene);
        
        //then it will load a scene
        
    

    }


}

//on the loadscreen on click script try this

 //public FadeOnclick fadeTransition

 //in the loadbyindex function
 //fadeTransition.fadeTo(sceneIndex)

 //on the quit function we can also do a debug statement
 //Debug.Log("Thank you for coming")



