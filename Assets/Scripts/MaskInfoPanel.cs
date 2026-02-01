using System.Collections;
using UnityEngine;
using TMPro;

public class MaskInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI maskDescription;
    public TextMeshProUGUI materialDescription;
    public TextMeshProUGUI fancyDescription;
    public GameObject panel;

    public Mask correctMask;
    public Mask selectedMask;

    public GameObject textBox;
    public GameObject resultBoxObject;
    public TextMeshProUGUI resultText;

    private ResultBox resultBox;

    void Start()
    {
        panel.SetActive(false);
        textBox.SetActive(true);
        resultBoxObject.SetActive(false);

        resultBox = resultBoxObject.GetComponent<ResultBox>();
    }

    public void ShowMaskInfo(Mask mask)
    {
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }

        selectedMask = mask;
        maskDescription.text = mask.maskDescription;
        materialDescription.text = "<b>Material</b>: " + mask.materialDescription;
        fancyDescription.text = "<b>Fancy Schmancy Level</b>: " + mask.fancyDescription;
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
