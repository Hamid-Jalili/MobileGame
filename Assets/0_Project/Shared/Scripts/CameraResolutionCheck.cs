using UnityEngine;
using UnityEngine.UI;


    public class CameraResolutionCheck : MonoBehaviour
    {
        [SerializeField] CanvasScaler scaler;

        enum DeviceType
        {
            Phone = 2,
            Tablet = 3
        }

        void Awake()
        {


            var device = GetDeviceType();

            if (device == DeviceType.Tablet)
            {
                scaler.matchWidthOrHeight = 1f;
            }
            else
            {
                scaler.matchWidthOrHeight = 0f;
            }

        }

        private float DeviceDiagonalSizeInInches()
        {
            float screenWidth = Screen.width / Screen.dpi;
            float screenHeight = Screen.height / Screen.dpi;
            float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

            return diagonalInches;
        }

        DeviceType GetDeviceType()
        {
#if UNITY_IOS
    bool deviceIsIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
            if (deviceIsIpad)
            {
                return DeviceType.Tablet;
            }
 
            bool deviceIsIphone = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
            if (deviceIsIphone)
            {
                return DeviceType.Phone;
            }
#endif

#if !UNITY_EDITOR
            float aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
            bool isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);
#else
            UnityEditor.PlayModeWindow.GetRenderingResolution(out uint width, out uint height);
            float aspectRatio = Mathf.Max(width, height) / Mathf.Min(width, height);
            bool isTablet = (DeviceDiagonalSizeInInches() > 6.5f && aspectRatio < 2f);
#endif

            if (isTablet)
            {
                return DeviceType.Tablet;
            }
            else
            {
                return DeviceType.Phone;
            }
        }
    }
