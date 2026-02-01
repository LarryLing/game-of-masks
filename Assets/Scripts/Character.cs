using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject basic;
    public GameObject masked;

    public string successMessage;
    public string failureMessage;

    void Start()
    {
        basic.SetActive(true);
        masked.SetActive(false);
    }

    public void SwitchToMasked()
    {
        basic.SetActive(false);
        masked.SetActive(true);
    }
}
