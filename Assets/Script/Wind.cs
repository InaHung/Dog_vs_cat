using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float maxWindForce = 1.5f;
    private float windForce;
    public Transform windBarBackground;
    public GameObject windBar;
    public GameObject flag;



    private void Awake()
    {
        StateMachine.onStateChange += ChangeWindDirection;
    }
    public void ChangeWindDirection(State curState)
    {

        if (curState != State.Attack)
        {
            windForce = Random.Range(-maxWindForce, maxWindForce);
            float percent = windForce / maxWindForce;
            float scaledValue = (windBarBackground.localScale.x / 2) * percent;
            windBar.transform.localScale = new Vector3(scaledValue, 1f, transform.localScale.z);
            Debug.Log(windForce);
        }
        if (windForce < 0)
            flag.transform.GetComponent<SpriteRenderer>().flipX = true;
        else
            flag.transform.GetComponent<SpriteRenderer>().flipX = false;

        if (curState == State.Complete)
            StateMachine.onStateChange -= ChangeWindDirection;
    }



    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "weapon")
        {

            Rigidbody2D rigidbody;
            rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(windForce, 0f), ForceMode2D.Force);
        }
    }
}





