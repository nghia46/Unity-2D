using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBarSprite;
    public void updateHealth(float currentHealt, float maxHealth)
    {
        healthBarSprite.fillAmount = currentHealt / maxHealth;
    }
}
