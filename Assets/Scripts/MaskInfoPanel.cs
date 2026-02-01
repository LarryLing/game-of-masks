using System.Collections;
using UnityEngine;
using TMPro;

public class MaskInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI maskDescription;
    public GameObject panel;

    public Mask correctMask;
    public Mask selectedMask;

    public GameObject textBox;
    public GameObject resultBoxObject;
    public TextMeshProUGUI resultText;

    private ResultBox resultBox;
    private float typingSpeed = 0.01f;

    void Start()
    {
        panel.SetActive(false);
        textBox.SetActive(true);
        resultBoxObject.SetActive(false);

        resultBox = resultBoxObject.GetComponent<ResultBox>();
    }

    IEnumerator TypeLine(TextMeshProUGUI textMeshPro, string description)
    {
        textMeshPro.text = string.Empty;
        foreach (char letter in description.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void ShowMaskInfo(Mask mask)
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }

        StopAllCoroutines();
        selectedMask = mask;
        maskDescription.text = string.Empty;
        StartCoroutine(TypeLine(maskDescription, mask.maskDescription));
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        maskDescription.text = string.Empty;
    }

    public void ConfirmSelection()
    {
        panel.SetActive(false);
        textBox.SetActive(false);
        resultBoxObject.SetActive(true);

        Mask[] allMasks = FindObjectsByType<Mask>(FindObjectsSortMode.None);
        foreach (Mask mask in allMasks)
        {
            mask.gameObject.SetActive(false);
        }

        if (selectedMask == correctMask)
        {
            resultBox.ShowResult("Wonderful! Thank you, I can already feel this is exactly what I need. I wish you the best.");
        }
        else
        {
            resultBox.ShowResult("I guess this will do. Wish you the best.");
        }

    }
}
