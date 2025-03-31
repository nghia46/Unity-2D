using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class HapticGameManager : MonoBehaviour
{
    public static HapticGameManager Instance;
    private Coroutine hapticCoroutine; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region 🔥 HỆ THỐNG RUNG TAY CẦM 🔥
    // Haptic feedback system for gamepad
    // This system uses the Unity Input System to provide haptic feedback on gamepads.
    public void PlayHaptic(float lowFrequency, float highFrequency, float duration)
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(lowFrequency, highFrequency);

            if (hapticCoroutine != null)
            {
                StopCoroutine(hapticCoroutine);
            }

            hapticCoroutine = StartCoroutine(StopHapticAfterTime(duration));
        }
    }
    public void PlayQuickHaptic()
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(0.5f, 0.5f);
            StartCoroutine(StopHapticAfterTime(0.1f));
        }
    }

    private IEnumerator StopHapticAfterTime(float duration)
    {
        yield return new WaitForSecondsRealtime(duration); // Đảm bảo không bị ảnh hưởng bởi Time.timeScale
        StopHaptic();
    }

    public void StopHaptic()
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.SetMotorSpeeds(0f, 0f);
        }

        if (hapticCoroutine != null)
        {
            StopCoroutine(hapticCoroutine);
            hapticCoroutine = null;
        }
    }

    #endregion
}
