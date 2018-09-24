using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineExample : MonoBehaviour


{
    public Transform Cube;
    public Renderer CubeRenderer;
    //public float duration = 2f; (or you can specify this in the function itself - will only apply to that function)

    // Use this for initialization
    void Start()
    {
        StartCoroutine(FadeColor(Color.black)); //calling Color.black as variable TargetColor

    }

    IEnumerator TestCoroutine()
    {
        Cube.Translate(0.5f, 0f, 0f);
        yield return new WaitForSeconds(2f);
        Cube.Translate(-0.5f, 0f, 0f);
        yield return new WaitForSeconds(2f);
        StartCoroutine(TestCoroutine());
    }

    IEnumerator FadeColor(Color TargetColor)
    {
        Color StartColor = new Color(1f, 0.05f, 0.5f); //Color.black or simple colors exist, otherwise specify RGB

        //how long the fade takes, in seconds
        float duration = 2f;

        float t = 0;
        while (t < 1f)
        {
            Debug.Log(t);
            CubeRenderer.material.color = Color.Lerp(StartColor, TargetColor, t);

            //can use:
            //Color.Lerp (for color)
            //Vector3.Lerp (for position or scale)
            //Quaterion.Lerp (for rotation)
            //Mathf.Lerp (for ints and floats)

            t += Time.deltaTime / duration;
            yield return null;
        }
        yield break;

    }
}
