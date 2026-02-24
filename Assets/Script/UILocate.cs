using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILocate : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rt;
    void Start()
    {
        rt=GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.parent.parent.position);
        rt.position = new Vector3(screenPos.x+rt.sizeDelta.x/2,screenPos.y);
    }
}
