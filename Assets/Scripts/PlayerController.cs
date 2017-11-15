using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GUIText countText;
    public GUIText winText;
    public GUIText timerText;
    public GUIText winTimerText;

    private int count;
    private bool restart;

    void Start()
    {
        count = 0;
        restart = false;
        SetCountText();
        winText.text = "";
        timerText.text = "Start";
    }

    void FixedUpdate()
    {
        if (timerText != null)
            timerText.text = Time.timeSinceLevelLoad.ToString("00");
        float moveHorisontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorisontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void SetCountText()
    {
        if (countText != null)
            countText.text = "Fångade: " + count.ToString();
        if (count >= 9)
        {
            Destroy(timerText);
            Destroy(countText);
            winTimerText.text = "Din tid: " + Time.timeSinceLevelLoad.ToString("00") + " sek";
            winText.text = "Tryck 'R' för att köra igen, 'ESC' avslutar";
            restart = true;
        }
    }
}
