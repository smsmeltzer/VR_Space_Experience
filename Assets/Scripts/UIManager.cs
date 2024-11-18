using System.Collections;
using System.Collections.Generic;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image fadeImage;

    public float fade = 1.0f;
    public bool fadingOut = true;
    // Start is called before the first frame update
    void Start()
    {
        fade = 1.0f;
        fadingOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingOut) {

            fade -= Time.deltaTime;
            if (fade <= 0.0f)
            {
                fade = 0.0f;
                fadingOut = false;
            }
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.b, fadeImage.color.g, fade);
    }
}
