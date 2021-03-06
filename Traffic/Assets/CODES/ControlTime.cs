using UnityEngine;
using UnityEngine.UI;

public class ControlTime : MonoBehaviour
{
    public float counttime;
    public Slider slider;

    private void Start()
    {
        counttime = 1;
        slider.value = counttime;
    }

    public void SlideTime(float speed)
    {
        counttime = speed;
    }
}
