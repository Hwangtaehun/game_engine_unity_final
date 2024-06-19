using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;
    [SerializeField] Image progressBar;
    [SerializeField] TMP_Text progresstext;

    public static void LoadScene(string sceneflame)
    {
        nextScene = sceneflame;
        SceneManager.LoadScene("Load");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        float percent;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
                percent = op.progress * 100;
                progresstext.text = percent.ToString("F2") + "%";
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1.0f, timer);
                percent = Mathf.Lerp(0.9f, 1.0f, timer) * 100;
                progresstext.text = percent.ToString("F2") + "%";

                if (progressBar.fillAmount >= 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}

//√‚√≥: https://wergia.tistory.com/183