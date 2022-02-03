using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private float timer = 10f;
    private bool setTimer = false;
    private bool setriger = false;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //Player Hurt
            anim.SetTrigger("hurt");
        } else
        {
            if(!dead)
            {
               isDead();
            }
           
        }
    }

    // belum terpakai
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void isDead(){

        Debug.Log(timer);
        if (setTimer == true)
        {
            anim.SetTrigger("die");
            timer -= Time.deltaTime * 15;
            if(timer < 1f)
            {
                setriger = true;
                
            }
        }

        if (setriger == true)
        {
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;
            SceneManager.LoadScene(0);

        }
    }

    private void Update(){
        isDead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "enemy")
        {
            setTimer = true;
        }
    }
}
