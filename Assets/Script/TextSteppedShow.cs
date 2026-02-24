using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextSteppedShow : MonoBehaviour
{
    public int maxWidth = 250;
    private string text;
    public float stepTime = 0.1f;
    private int stepCount;
    private TextMeshProUGUI textMeshPro;
    Image background;

    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        background = transform.parent.GetComponent<Image>();
        text = textMeshPro.text;
    }
    void OnEnable()
    {
        textMeshPro.text = "";
        stepCount = 0;
        StartCoroutine(StepShow());
    }
    void OnDisable()
    {
        StopAllCoroutines();
        background.rectTransform.sizeDelta = new Vector2(maxWidth, 50);
    }
    IEnumerator StepShow()
    {
        while (stepCount < text.Length)
        {
            textMeshPro.text+= text[stepCount];
            yield return new WaitForEndOfFrame();
            background.rectTransform.sizeDelta = new Vector2(maxWidth, textMeshPro.textBounds.size.y + 27.65f);
            if (text[stepCount++] == '\n') continue;
            yield return new WaitForSeconds(stepTime);
        }

    }
}
