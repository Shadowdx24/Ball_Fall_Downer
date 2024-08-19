using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector3 lastPos = Vector3.zero;
    private bool newTap = true;
   // [SerializeField] private float speed;

    void Start()
    {
       // currControls = PlayerPrefs.GetInt("CurrControl");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPos = Input.mousePosition ;

            if (newTap)
            {
                lastPos = currentPos;   
            }

            float delta = currentPos.x - lastPos.x;

            transform.Rotate(delta * Vector3.up);

            lastPos = currentPos;

            newTap = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            newTap = true;
        }

    }
}
