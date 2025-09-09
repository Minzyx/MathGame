using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource clickSound;

    public void PlayClick()
    {
        clickSound.Play();
    }
}
