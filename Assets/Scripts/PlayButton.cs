using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayButton : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        text.color = Color.white;
    }

    void OnMouseEnter()
    {
        text.color = Color.red;
    }

    void OnMouseExit()
    {
        text.color = Color.white;
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}
