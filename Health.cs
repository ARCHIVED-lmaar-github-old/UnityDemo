using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health")]
    public Image HealthBarFill;


    [Tooltip("Maximum amount of health")]
    public float maxHealth = 100f;
    [Tooltip("Health ratio at which the critical health vignette starts appearing")]
    [Range(0, 0.5f)] 
    public float criticalHealthRatio = 0.3f;


    //public UnityAction<float, GameObject> onDamaged;
    //public UnityAction<float> onHealed;
    //public UnityAction onDie;

    public float currentHealth { get; set; }
    public bool invincible { get; set; }
    public bool canPickup() => currentHealth < maxHealth;

    public float getRatio() => currentHealth / maxHealth;
    public bool isCritical() => getRatio() <= criticalHealthRatio;



    [Header("Score")]
    public int itemScore = 1000;
    public int coinScore = 0;
    protected Score score;
    protected ScoreCoins scoreCoins;


    [Header("Internal Use Only")]
    public bool IsDead = false;

    private void Start()
    {
        // Setup Health
        currentHealth = maxHealth;
        DoHealthBar(1);

        // Setup Score Objects
        if (!scoreCoins)
            scoreCoins = FindObjectOfType<ScoreCoins>();

        // Setup Score Objects
        if (!score)
            score = FindObjectOfType<Score>();

    }

    private void DoHealthBar(float h)
    {
        if(HealthBarFill)
            HealthBarFill.fillAmount = h;
    }

    public void Heal(float healAmount)
    {
        float healthBefore = currentHealth;
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        DoHealthBar(getRatio());

        //float trueHealAmount = currentHealth - healthBefore;
    }

    //public void TakeDamage(float damage, GameObject damageSource)
    public void TakeDamage(float damage)
    {
        if (invincible)
            return;

        float healthBefore = currentHealth;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        DoHealthBar(getRatio());

        //Debug.Log("Damage = " + damage + " / Health = " + healthBefore + " > " + currentHealth);

        //float trueDamageAmount = healthBefore - currentHealth;

        HandleDeath();


    }

    public void Kill()
    {
        currentHealth = 0f;

        DoHealthBar(0);

        HandleDeath();
    }

    private void HandleDeath()
    {
        if (IsDead)
            return;

        // call OnDie action
        if (currentHealth <= 0f)
        {
            /*
            if (onDie != null)
            {
                m_IsDead = true;
                onDie.Invoke();
            }
            */

            DoScoreOnDestroy();

            if (this.name == "Player")
            {
                FindObjectOfType<GameManagerScript>().EndGame();
            }
            else
            {
                Destroy(this.gameObject, 0f);
            }

            IsDead = true;
            //Debug.Log(":: DEAD ::");
        }
    }
    
    void DoScoreOnDestroy()
    {
        if (coinScore > 0)
        {

            if (scoreCoins)
                scoreCoins.AddPoints(coinScore);
        }

        if (itemScore > 0)
        {
            if (score)
                score.AddPoints(((int)(itemScore) / 10) * 10);
        }
    }

}
