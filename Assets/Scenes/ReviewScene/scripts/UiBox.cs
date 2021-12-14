using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiBox : MonoBehaviour
{
    // 코인바
    [SerializeField] Text uiCoinNum; // 코인수 표시 텍스트
    public int coin = 1000; // 코인수 (다른 클래스에서 받아와야 함)

    // 게이지바
    public Image uiGaugeFull; // 게이지 이미지
    public float goal = 5f; // 목표 산책거리 (임의로 5km로 설정)
    public float achieve = 4.1f; // 달성 산책거리 (임의로 4.1km로 설정)



    // Start is called before the first frame update
    void Start()
    {
        // 코인바
        uiCoinNum.text = coin.ToString();

        // 게이지바
        uiGaugeFull.fillAmount = achieve / goal;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void ReturntBtn()
    {
        SceneManager.LoadScene("MainHomeScene"); // 다음 화면으로 전환
    }
}
