using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] float TotalSeconds; // 총 시간 카운팅
    [SerializeField] Text timeText; // 텍스트 오브젝트
    [SerializeField] Text NoticeText; // 알림메시지
    [SerializeField] GameObject StopButton; //

    TimeSpan timespan;
    public static string timer; // 전역변수로 총 시간 정의


    bool timeFirst = false;
    bool timeActive = false;

    public Image StartImage; // 시작 이미지
    public Sprite PauseSprite; // 일시정지 이미지
    public Sprite RestartSprite; // 재시작(삼각형) 이미지

    // 음성 옵션
    public bool Sound = true; // 소리 유무
    public Image SoundImage; // 소리설정 이미지
    public Sprite SoundOn; // 소리 활성화
    public Sprite SoundOff; // 소리 비활성화


    // 전역변수 지정
    public static int finalCoin = 0;

    // Start is called before the first frame update
    void Start()
    {
        TimeSpan timespan = TimeSpan.FromSeconds(TotalSeconds);
        timer = string.Format("{0:00}:{1:00}:{2:00}",
            timespan.Hours, timespan.Minutes, timespan.Seconds);
        timeText.text = timer;
        StopButton.SetActive(false); // 산책종료 버튼 숨기기
    }

    // Update is called once per frame
    void Update()
    {
        StartTime();
        timeFirst = true;
    }

    void StartTime()
    {
        if (timeActive)
        {
            TotalSeconds += Time.deltaTime;

            timespan = TimeSpan.FromSeconds(TotalSeconds);
            timer = string.Format("{0:00}:{1:00}:{2:00}",
                timespan.Hours, timespan.Minutes, timespan.Seconds);
            timeText.text = timer;

            //finalTime = timer;
            StartImage.sprite = PauseSprite;
            StopButton.SetActive(false); // 산책종료 버튼 숨기기
            if (!timeFirst)
            {
                // 처음 시작한 경우
                timeFirst = !timeFirst;
                // Message(NoticeText, "10m 지점마다 1코인씩 얻을 수 있어요!"); // 알림 메시지 띄우기
            }
        }
    }

    public void StartPauseBtn()
    {
       timeActive = !timeActive;
       StartImage.sprite = RestartSprite; // 이미지 변경
       StopButton.SetActive(true); // 산책종료 버튼 나타내기
    }

    public void ResetBtn()
    {
        print("final Time" + timer);
        print("yaayyaayayayyaayyayaa");
        SceneManager.LoadScene("ReviewScene"); // 다음 화면으로 전환
    }

    public void SoundBtn()
    {
        if (Sound) // 소리가 켜져 있다면 -> 소리 끔
        {
            SoundImage.sprite = SoundOff; // 이미지 변경
        }
        else // 소리가 꺼져 있다면끔 -> 소리 킴
        {
            SoundImage.sprite = SoundOn; // 이미지 변경
        }
        Sound = !Sound; // 소리 유무 전환
    }

    /*
    // 메시지 띄우기
    public void Message(Text t, String s)
    {
        t.text = s;
        t.gameObject.SetActive(true);
        CancelInvoke("AfterCall"); // 3초지연
        Invoke("AfterCall", 3.0f); // 3초지연
        t.gameObject.SetActive(false);
    }
    */
}
