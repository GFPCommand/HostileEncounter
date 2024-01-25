using UnityEngine;

public class CharacterLocomotion : MonoBehaviour
{
    [Tooltip("Assign animator if you would like. We are using 2d blendtree")]
    [SerializeField] Animator animator;

    //this script will make you character move correctly regardless of how camera is setup
    [Tooltip("Character controller is a built in component in unity. Feel free to use rigidbody or changing transform directly")]
    [SerializeField] CharacterController characterController;

    [Tooltip("how fast the player walks")]
    [SerializeField] float walkSpeed = 3f;

    [Tooltip("if you would like separate visual from player assign something else here")]
    [SerializeField] Transform characterVisual;//if you would like separate visual from player assign something else here

    [Tooltip("Turn this off if you want to separate movement and aiming")]
    [SerializeField] bool lookToMovementDirection = true;//turn this off if you want to separate movement and aiming

    [Tooltip("Feel free to assign other joysticks here")]
    [SerializeField] FixedJoystick moveJoystick;//assign joystick here

    [Tooltip("Self explanatory. After this magnitude player will move ")]
    [SerializeField] float movementThreshold = 0.1f;// self explanatory. After this magnitude player will move

    float mag; // maginutde
    Transform camTransform;
    Vector3 fwd,right; //camera fwd,right
    void Awake()
    {
        if(characterController == null){
            characterController = GetComponent<CharacterController>();
            //getting the characterController component
        }
        if(characterVisual == null){
            characterVisual = transform;
        }
        camTransform = Camera.main.transform;
    }
    void Start(){
        characterController.detectCollisions = false; //we don't want character controller to detect collisions
        RecalculateCamera(Camera.main);//we should know where camera is looking at. Call this method each time camera angle changes
        //also consider caching the camera
    }
    void Update(){
        mag = Mathf.Clamp01(new Vector2(moveJoystick.Horizontal, moveJoystick.Vertical).sqrMagnitude);
        //getting the magnitude
        if (mag >= movementThreshold) 
        {
            MovementAndRotation();
        }

        if (mag > 0.1f)
        {
            animator.SetBool("IsWalk", true);
        } 
        else
        {
            animator.SetBool("IsWalk", false);
        }

        characterVisual.Translate(0, 0, 0);
    }

    void RecalculateCamera(Camera _cam){
            Camera cam = _cam;
            camTransform = cam.transform;
            fwd = cam.transform.forward; //camera forward
            fwd.y = 0;
            fwd = Vector3.Normalize(fwd);
            right = Quaternion.Euler(new Vector3(0, 90, 0)) * fwd; //camera right
    }
    void MovementAndRotation(){
        Vector3 direction = new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical);//joystick direction
        Vector3 rightMovement = right * walkSpeed * Time.deltaTime * moveJoystick.Horizontal;//getting right movement out of joystick(relative to camera)
        Vector3 upMovement = fwd * walkSpeed * Time.deltaTime * moveJoystick.Vertical; //getting up movement out of joystick(relative to camera)
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement); //final movement vector
        heading.y = -9.8f;//gravity while moving
        characterController.Move(heading * walkSpeed*Time.deltaTime);//move
        if(lookToMovementDirection){
            characterVisual.forward = new Vector3(heading.x,characterVisual.forward.y,heading.z);
            //look to movement direction
        }
        
    }
    
}
