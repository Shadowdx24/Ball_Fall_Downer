using TMPro;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform ball;
    [SerializeField] private BallControler Ball;


    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > ball.position.y + .1f)
        {
            
            Ball.AddScore(1);
           
            this.enabled = false;
        }
    }

   
}
