using System; 
using UnityEngine;
using UnityEngine.SceneManagement;   //For Multiple Levels in game

public class RocketShip : MonoBehaviour
{

    [SerializeField] float rcsthrust = 100f;   //Rotation
    [SerializeField] float mainthrust = 100f;
    [SerializeField] float levelloaddelay = 2f;//Rocket Thrust

    
    [SerializeField] AudioClip mainengine;     //Mainengine sounds  (AudioClip= A container for audio data)
    [SerializeField] AudioClip success;        //Success Sound
    [SerializeField] AudioClip death;          //Death Sound

    
    
    
    [SerializeField] ParticleSystem mainenginepart;   //Engine Particles
    [SerializeField] ParticleSystem successpart;      //Success Particles
    [SerializeField] ParticleSystem deathpart;        //Death Particles  
    
    
    Rigidbody rigidBody;
    AudioSource audioSource;

    enum State { alive,dying,transcending};       //Enumeration for GameState
    State state;
    
    bool collisionaredisable=true;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }


   
    void Update()
    {
        if (state == State.alive)      //Condition to execute Rocket Functioning
        {
            Respondtothrust();          //For Thrust
            Respondtorotate();          //For Rotation of Rocket
        }
        respondtodebugkeys();

    }

    private  void respondtodebugkeys()
    {
        if(Input.GetKeyDown(KeyCode.C ))
        {
            collisionaredisable = !collisionaredisable;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state != State.alive||!collisionaredisable)
        {
            return;
        }
        switch(collision.gameObject.tag)
        {
            case "start":
                print("ok");
                break;
            
           
                             case "finish":
                             state = State.transcending;       //Game state=transcending
                             audioSource.PlayOneShot(success);
                             successpart.Play();
                             Invoke("loadnextlevel2", levelloaddelay) ;
                              break;
            
                                                   case "finish1"://entry to lvl3
                                                   state = State.transcending;
                                                   print("Next level");
                                                   audioSource.PlayOneShot(success);
                                                   successpart.Play();
                                                   Invoke("loadnextlevel3", levelloaddelay);
                                                   break;
           
                                                               case "finish2"://Entry to lvl4
                                                               state = State.transcending;
                                                               audioSource.PlayOneShot(success);
                                                               successpart.Play();
                                                               Invoke("loadnextlevel4", levelloaddelay);
                                                               break;
           
                
                                                                              case "finish3"://Entry to lvl5
                                                                              state = State.transcending;
                                                                              audioSource.PlayOneShot(success);
                                                                              successpart.Play();
                                                                              Invoke("loadnextlevel5", levelloaddelay);
                                                                              break;
                                           
                                                                                     
                                                                                     case "finish4"://Entry to lvl5
                                                                                     state = State.transcending;
                                                                                     audioSource.PlayOneShot(success);
                                                                                     successpart.Play();
                                                                                     Invoke("loadnextlevel6", levelloaddelay);
                                                                                     break;




                                                                                           case "finish5"://Entry to lvl5
                                                                                           state = State.transcending;
                                                                                           audioSource.PlayOneShot(success);
                                                                                           successpart.Play();
                                                                                           Invoke("loadnextlevel7", levelloaddelay);
                                                                                           break;

                                                                                 
            
             
             
                                                                                                     case "finish6"://Entry to lvl5
                                                                                                     state = State.transcending;
                                                                                                     audioSource.PlayOneShot(success);
                                                                                                     successpart.Play();
                                                                                                     Invoke("loadnextlevel8", levelloaddelay);
                                                                                                     break;

            case "finish7"://Entry to lvl5
                state = State.transcending;
                audioSource.PlayOneShot(success);
                successpart.Play();
                Invoke("loadnextlevel9", levelloaddelay);
                break;

            case "finish8"://Entry to lvl5
                state = State.transcending;
                audioSource.PlayOneShot(success);
                successpart.Play();
                Invoke("loadnextlevel", levelloaddelay);
                break;





            case "dead":
                                                                                                state = State.dying;  //Game state=dying
                                                                                                audioSource.Stop();
                                                                                                audioSource.PlayOneShot(death);
                                                                                                deathpart.Play();
                                                                                                Invoke("loadfirstlevel", 2.3f);
                                                                                                print("Out");
                                                                                                break;
           
            default:
                print("do nothing");
                break;
        }
    }

    private  void loadnextlevel2()
    {
        print("Next level");//Entry to lvl2
        SceneManager.LoadScene(2);
    }

    private void loadnextlevel3()
    {
        print("Next level");//Entry to lvl3
        SceneManager.LoadScene(3);
    }
    private void loadnextlevel4()
    {
        print("Next level");//Entry to lvl4
        SceneManager.LoadScene(4);
    }
    private void loadnextlevel5()
    {
        print("Next level");//Entry to lvl5
        SceneManager.LoadScene(5);
    }
    private void loadnextlevel6()
    {
        print("Next level");//Entry to lvl6
        SceneManager.LoadScene(6);
    }
    private void loadnextlevel7()
    {
        print("Next level");//Entry to lvl7
        SceneManager.LoadScene(7);
    }
    private void loadnextlevel8()
    {
        print("Next level");//Entry to lvl8
        SceneManager.LoadScene(8);
    }
    private void loadnextlevel9()
    {
        print("Next level");//Entry to lvl9
        SceneManager.LoadScene(9);
    }
    private void loadnextlevel10()
    {
        print("Next level");//Entry to lvl10
        SceneManager.LoadScene(10);
    }
    private void loadfirstlevel()
    {
        print("first level");//Entry to lvl2
        SceneManager.LoadScene(0);
    }

     void Respondtothrust()
    {
        applythrust();                  //Rocket Thrust declaration

    }
 private void applythrust()               //Rocket Thrust Initialization
    {
        if (Input.GetKey(KeyCode.Space))        //Assign space for Thrust
        {
            rigidBody.AddRelativeForce(Vector3.up * mainthrust);     //Addrelativeforce-adds amount of thrust to rigidbody
            if (!audioSource.isPlaying)             
            {
                audioSource.PlayOneShot(mainengine);         //playoneshot= plays the audio clip
                mainenginepart.Play();
            }
            

        }
        else
        {
            audioSource.Stop();
            mainenginepart.Stop();
        }
    }

      void Respondtorotate()
    {
        applyrotate();               //Rocket rotation declaration
    }

    private void applyrotate()        //Rocket rotation initialization
    {
        rigidBody.freezeRotation = true; //Controlling the rotation manually starts
        float rotationthisframe = rcsthrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationthisframe);
        }
      
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationthisframe);
        }
        rigidBody.freezeRotation = false;   //Controlling the rotation manually stops
    }
}
