using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public Text angularSpeedText;
    public Text accelerationText;
    public Text AltitudeText;
    public Text LongitudeText;
    public Text LatitudeText;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.location.isEnabledByUser)
        {
            Input.location.Start();
        }
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            angularSpeedText.text = Input.gyro.rotationRate.ToString();
            accelerationText.text = Input.acceleration.ToString();
            AltitudeText.text = Input.location.lastData.altitude.ToString();
            LongitudeText.text = Input.location.lastData.longitude.ToString();
            LatitudeText.text = Input.location.lastData.latitude.ToString();
        }
    }
}
