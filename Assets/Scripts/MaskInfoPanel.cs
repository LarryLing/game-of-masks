using System.Collections;
using UnityEngine;
using TMPro;

public class MaskInfoPanel : MonoBehaviour
{
    public TextMeshProUGUI maskDescription;
    public GameObject panel;
    public Mask correctMask;
    public Mask selectedMask;

    private float typingSpeed = 0.01f;

    void Start()
    {
        panel.SetActive(false);
    }

    IEnumerator TypeLine(string description)
    {
        maskDescription.text = string.Empty;
        foreach (char letter in description.ToCharArray())
        {
            maskDescription.text += letter;
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
        StartCoroutine(TypeLine(mask.maskDescription));
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        maskDescription.text = string.Empty;
    }

    public void ConfirmSelection()
    {
        if (selectedMask == correctMask)
        {
            Debug.Log("Correct mask selected!");
        }
        else
        {
            Debug.Log("Incorrect mask selected. Try again.");
        }
    }
}
