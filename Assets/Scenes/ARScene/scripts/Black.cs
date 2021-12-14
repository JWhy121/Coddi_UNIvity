using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Black : MonoBehaviour
{
    [SerializeField] GameObject BlackButton;
    [SerializeField] GameObject BlackView;
    [SerializeField] GameObject EndBlackButton;


    // Start is called before the first frame update
    void Start()
    {
        BlackView.SetActive(false); // 숨기기
        EndBlackButton.SetActive(false); // 숨기기
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlackBtn()
    {
        BlackView.SetActive(true); // 나타내기
        EndBlackButton.SetActive(true); // 나타내기
    }

    public void BEndBlackBtn()
    {
        BlackView.SetActive(false); // 숨기기
        EndBlackButton.SetActive(false); // 숨기기
    }
}
