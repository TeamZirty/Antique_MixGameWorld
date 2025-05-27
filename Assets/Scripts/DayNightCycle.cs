/* 일정 거리 이동마다 분위기 전환*/


using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;
    public Color dayColor;
    public Color nightColor;
    public float switchDistance = 100f;

    private bool isNight = false;

    void Update()
    {
        if (Mathf.Floor(player.position.x / switchDistance) % 2 == 1)
        {
            if (!isNight)
            {
                SwitchToNight();
            }
        }
        else
        {
            if (isNight)
            {
                SwitchToDay();
            }
        }
    }

    void SwitchToDay()
    {
        mainCamera.backgroundColor = dayColor;
        isNight = false;
    }

    void SwitchToNight()
    {
        mainCamera.backgroundColor = nightColor;
        isNight = true;
    }
}
