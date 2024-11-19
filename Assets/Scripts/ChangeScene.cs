using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private UIManager ui;
    public string sceneName;

    private void Start()
    {
        ui = GameObject.Find("UI").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        var op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        float t = 0;

        while (op.progress < 0.9f || t < 1)
        {
            t += Time.deltaTime / 2;
            t = Mathf.Clamp01(t);
            ui.fade = t;
            yield return null;
        }
        op.allowSceneActivation = true;
    }
}
