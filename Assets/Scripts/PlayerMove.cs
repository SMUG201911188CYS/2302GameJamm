using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float mouseSpeed = 8f;
    private float down_gravity;
    private float up_gravity;
    private float gravity;
    private CharacterController controller;
    private Vector3 mov;

    public static bool isWalk;
    public static bool isDead;
    public static bool isScream;

    public static int _orange = 3;
    private float mouseX;
    private string _currentState;

    public GameObject objectToThrow;
    public float throwForce = 10f;
    public Transform ThrowPoint;
    public static Transform player;
    public bool isMud = false;
    private bool isStarted;
    public GameObject Dolha;
    private bool ischeck;

    public string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        mov = Vector3.zero;
        down_gravity = 20f;
        up_gravity = 15f;
        gravity = 20f;
        currentScene = SceneManager.GetActiveScene().name;
        isStarted = true;
        Dolha.SetActive(false);
        player = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted)
        {
            if (!isDead)
            {
                if (isMud)
                {
                    MudMove();
                }
                else
                {
                    Move();
                }
            }
            else if (isDead)
            {
                StartCoroutine(nameof(DeadCorutine));
            }

            if (Input.GetMouseButtonDown(0) && _orange > 0 && SceneManager.GetActiveScene().name == "MainMapMud")
            {
                ThrowObject();
                _orange--;
            }
        }

        if (currentScene == "MainMapMud" && !ischeck)
        {
            isMud = true;
            ischeck = true;
        }
    }

    void ThrowObject()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // 충돌한 지점에서 게임 오브젝트 생성
            GameObject thrownObject = Instantiate(objectToThrow, ThrowPoint.position, Quaternion.identity);

            // thrownObject에서 Rigidbody 컴포넌트를 찾아서 힘을 가해 던지기
            Rigidbody thrownRigidbody = thrownObject.GetComponent<Rigidbody>();
            Vector3 throwDirection = (hit.point - ThrowPoint.position).normalized;
            thrownRigidbody.AddForce(throwDirection * throwForce , ForceMode.Impulse);
            SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Throw);
        }
    }

    void Move()
    {
        float diagonalFactor = 0.875f;
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        this.transform.localEulerAngles = new Vector3(0, mouseX, 0);

        if (controller.isGrounded)
        {

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            mov = new Vector3(x, 0, y);
            mov = controller.transform.TransformDirection(mov);
            float factor = (Mathf.Abs(x) + Mathf.Abs(y) > 1f) ? diagonalFactor : 1f;
            mov *= factor; 

            if ((x != 0 || y != 0) && _currentState != "Walk")
            {
                Debug.Log("Current State : Walk");
                _currentState = "Walk";
                isWalk = true;
                SoundManager.instance.walkSound.Play();
                Debug.Log("IsWalk :" + isWalk);
            }

            if (x == 0 && y == 0 && _currentState != "Idle")
            {
                Debug.Log("Current State : Stop");
                _currentState = "Idle";
                SoundManager.instance.walkSound.Stop();
                isWalk = false;
            }

        }
        else
        {
            mov.y -= down_gravity * Time.deltaTime;
        }

        controller.Move(mov * (Time.deltaTime  * speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mud") && !isMud)
        {
            isMud = true;
        }

        if (other.CompareTag("Escape"))
        {
            SceneManager.LoadScene("Ending");
        }

    }

    void MudMove()
    {
        float diagonalFactor = 0.875f;
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        this.transform.localEulerAngles = new Vector3(0, mouseX, 0);
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        mov = new Vector3(x, 0, y);
        mov = controller.transform.TransformDirection(mov);
        float factor = (Mathf.Abs(x) + Mathf.Abs(y) > 1f) ? diagonalFactor : 1f;
        mov *= factor;

        if ((x != 0 || y != 0) && _currentState != "Walk")
        {
            SoundManager.instance.walkSound.Play();
            _currentState = "Walk";
            isWalk = true;
        }
        if (x == 0 && y == 0 && _currentState != "Idle")
        {
            SoundManager.instance.walkSound.Stop();
            _currentState = "Idle";
            isWalk = false;
        }

        if (!isWalk)
        {
            if (transform.position.y > 8.6f)
            {
                mov.y -= down_gravity * Time.deltaTime;
                if (speed <= 4.5)
                {
                    speed += 0.4f * Time.deltaTime;
                }
            }
            else
            {
                isDead = true;
            }
        }
        else
        {
            if (transform.position.y < 10.15f)
            {
                mov.y += up_gravity * Time.deltaTime;
                if (speed >= 3)
                {
                    speed -= 0.3f * Time.deltaTime;
                }
            }
        }
        //Debug.Log(speed);
        controller.Move(mov * (Time.deltaTime * speed));
    }

    IEnumerator DeadCorutine()
    {
        SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.EnemyHit);
        Dolha.SetActive(true);
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("DeadEnding");
    }

}