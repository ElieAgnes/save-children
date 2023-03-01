using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScreenEaster : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    // Start is called before the first frame update
    private string[] titles = 
    {
        "you tried",
        "Tu sais tu peux alt + f4",
        "T'as perdu la garde de tes enfants"
    };

    void Start()
    {
        System.Random random = new System.Random(); 
        int index = random.Next(titles.Length);
        text.SetText(titles[index]);
    }
}
