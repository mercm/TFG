using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Preparation : MonoBehaviour
{
    public Text preparationText;
    public GameObject panel;
    
    private List<string> keywords = new List<string>();

    private int level;
    private string speech;
    private bool spacePressed;
    private bool audioPlaying;
    private int choosenSpeech;
    public static int silencesNeeded;
    public static int longSilencesNeeded;
    public static int totalPoints;
    public static List<string> kwordNeeded = new List<string>();
    public Button returnButton;
    public Button audioButton;
    public Text audioText;
    //public TextMeshPro timerText;
    private AudioSource audio;
    public AudioSource audioLv1;
    public AudioSource audioLv2;
    public Text levelText;

    //public GameObject SoundLoudness;
    public GameObject ManagerGO;
    public GameObject TimerGO;

    // Start is called before the first frame update
    void Start()
    {
        //kwordNeeded.Clear();

        panel.gameObject.SetActive(true);
        TimerGO.gameObject.SetActive(true);
        level = PlayerPrefs.GetInt("Level");

        if (level == 1)
        {
            //timerText.text = "0";
            speech =
                "Pues bien, (//) ese amuleto valía un cubo lleno de reales de oro, (///) pero para compensar a Táborlin por su generosidad, el calderero se lo "+
            "vendió por solo un penique de hierro, (//) un penique de cobre (//) y un penique de plata. (///) Era negro como una noche de invierno y estaba frío "+ 
            "como el hielo, (//) pero mientras lo llevara colgado del cuello, Táborlin estaría a salvo de todas las cosas malignas.(///) Demonios y demás.";
            /*   @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, (//) consciente de la responsabilidad que comporta (//) y con 
           la mayor esperanza en el futuro de España. (///)

           Una nación forjada a lo largo de siglos de Historia (//) por el trabajo compartido de millones de personas de todos los lugares de nuestro territorio 
           (//) y sin cuya participación no puede entenderse el curso de la Humanidad.";*/

            kwordNeeded.Add("ese amuleto valía");
            kwordNeeded.Add("pero para compensar");
            kwordNeeded.Add("un penique de cobre");
            kwordNeeded.Add("un penique de plata");
            kwordNeeded.Add("Era negro");
            kwordNeeded.Add("y estaba frío");
            kwordNeeded.Add("pero mientras");
            kwordNeeded.Add("Demonios y demás");

            totalPoints = 40;
            audio = audioLv1;
            silencesNeeded = 4;
            longSilencesNeeded = 3;
            levelText.text = "Nivel 1";

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Para éste necesitas 4 silencios de entre 0.6 y 1.0 segundos (representados con //) " +
            "y 3 silencios largos entre 1.1 y 2.1 segundos (representados con ///)."+
            "\n\nPresiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds (represented with //) " +
            //"and 1 long silence between 1.4 and 2.1 seconds (represented with ///). \n\nPress SPACE to read and practice the speech.";
        }
        else if (level == 2)
        {

            speech =
                "Carter apretó los labios dibujando una fina línea. Estiró un brazo y tiró del extremo de la manta ensangrentada. Lo que había dentro rodó "+ 
            "sobre sí mismo una vez y se enganchó en la tela. Carter dio otro tirón y se oyó un fuerte ruido, como si hubiera vaciado un saco de guijarros "+
            "encima de la mesa.\n"+
            "Era una araña negra como el carbón y del tamaño de una rueda de carro.";
            /*speech =
                "Carter apretó los labios dibujando una fina línea. (//)Estiró un brazo y tiró del extremo de la manta ensangrentada.(//) Lo que había dentro rodó " +
            "sobre sí mismo una vez(//) y se enganchó en la tela.(///) Carter dio otro tirón y se oyó un fuerte ruido,(//) como si hubiera vaciado un saco de guijarros " +
            "encima de la mesa.\n(///)" +
            "Era una araña negra como el carbón(//) y del tamaño de una rueda de carro.";*/     
            /*    @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, consciente de la responsabilidad que comporta y con 
            la mayor esperanza en el futuro de España.

            Una nación forjada a lo largo de siglos de Historia por el trabajo compartido de millones de personas de todos los lugares de nuestro territorio 
            y sin cuya participación no puede entenderse el curso de la Humanidad.";*/

            kwordNeeded.Add("Estiró un brazo");
            kwordNeeded.Add("Lo que había dentro");
            kwordNeeded.Add("y se enganchó");
            kwordNeeded.Add("Carter dio otro");
            kwordNeeded.Add("como si hubiera");
            kwordNeeded.Add("Era una araña");
            kwordNeeded.Add("y del tamaño");

            totalPoints = 40;
            audio = audioLv2;
            silencesNeeded = 5;
            longSilencesNeeded = 2;
            levelText.text = "Nivel 2";

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Para éste necesitas 5 silencios de entre 0.6 y 1.1 segundos " +
            "y 2 silencios largos de entre 1.1 y 2.1 segundos."+
            "\n\nPresiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds " +
            //"and 1 long silence between 1.4 and 2.1 seconds. \n\nPress SPACE to read and practice the speech.";
        }
        else if ( level == 3)
        {

            speech =
                "Retazos de luz procedentes de las ventanas de la posada se proyectaban sobre el camino de tierra y las puertas de la herrería de enfrente. "+
            "No era un camino muy ancho, ni muy transitado. No parecía que condujera a ninguna parte, como pasa con algunos caminos. El posadero inspiró el aire "+
            "otoñal y miró alrededor, inquieto, como si esperase que sucediera algo.";
            /*speech =
                "Retazos de luz procedentes de las ventanas de la posada se proyectaban sobre el camino de tierra y las puertas de la herrería de enfrente.(//) " +
            "No era un camino muy ancho, (//) ni muy transitado.(//) No parecía que condujera a ninguna parte, como pasa con algunos caminos.(///) El posadero inspiró el aire " +
            "otoñal y miró alrededor,(//) inquieto,(//) como si esperase que sucediera algo.";*/
            /*    @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, consciente de la responsabilidad que comporta y con 
            la mayor esperanza en el futuro de España.

            Una nación forjada a lo largo de siglos de Historia por el trabajo compartido de millones de personas de todos los lugares de nuestro territorio 
            y sin cuya participación no puede entenderse el curso de la Humanidad.";*/

            kwordNeeded.Add("No era un camino");
            kwordNeeded.Add("ni muy transitado");
            kwordNeeded.Add("No parecía que");
            kwordNeeded.Add("El posadero");
            kwordNeeded.Add("inquieto");
            kwordNeeded.Add("como si esperase");

            totalPoints = 25;
            silencesNeeded = 4;
            longSilencesNeeded = 1;
            levelText.text = "Nivel 3";

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Para éste, necesitas 4 silencios de entre 0.6 y 1.0 segundos " +
            "y 2 silencios largos de entre 1.1 y 2.1 segundos." +
            "\n\nPresiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds " +
            //"and 1 long silence between 1.4 and 2.1 seconds. \n\nPress SPACE to read and practice the speech.";
        }
        else
        {
            Debug.LogError("Problems with level number.");
        }

        /*@"La vida es lo mas preciado que posee el hombre, a el se le otorga una sola vez y debe saber vivirla de forma tal, 
            que no le cause un dolor torturante por los años pasados en vano; y para que no le remuerda la conciencia, por el ayer 
            vil y mezquino que no lo supo aprovechar, y para que al morir pueda exclamar que toda su vida y todas sus fuerzas, 
            lo ha dedicado a lo mas hermoso que posee el mundo, a la lucha por la justicia, la paz y la liberación de la humanidad.";*/


        /*preparationText.text =
            "Welcome! It is time to practice the silences of your speech. Select an speech from 1 to " +
            speeches.Length + " and practice it. \n\nPress SPACE when you are ready to present. Press the LEFT ARROW to choose another speech.";*/
       
    }

    private void OnEnable()
    {
        //choosenSpeech = -1;
        spacePressed = false;
        audioPlaying = false;
        //returnButton.gameObject.SetActive(false);//Seguro?
        audioButton.gameObject.SetActive(false);
        audioText.gameObject.SetActive(false);
        //silencesNeeded = 4;
        //longSilencesNeeded = 1;
        //timerText.text = "0";
        //kwordNeeded.Clear();

        Manager.speech = "";
        if (level == 1)
        {
            preparationText.text =
          "¡Bienvenido! Es momento de practicar los silencios de un discurso. Para éste necesitas 4 silencios de entre 0.6 y 1.0 segundos (representados con //) " +
           "y 3 silencios largos entre 1.1 y 2.1 segundos (representados con ///)." +
           "\n\nPresiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds (represented with //) " +
            //"and 1 long silence between 1.4 and 2.1 seconds (represented with ///). \n\nPress SPACE to read and practice the speech.";
        }
        else if (level == 2)
        {
            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Para éste necesitas 5 silencios de entre 0.6 y 1.1 segundos " +
            "y 2 silencios largos de entre 1.1 y 2.1 segundos." +
            "\n\nPresiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds " +
            //"and 1 long silence between 1.4 and 2.1 seconds. \n\nPress SPACE to read and practice the speech.";
        }
        else if (level == 3)
        {
            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Para éste, necesitas 4 silencios de entre 0.6 y 1.0 segundos " +
            "y 2 silencios largos de entre 1.1 y 2.1 segundos." +
            "\n\nPresiona A para ver el texto del discurso. Podrás verlo mientras presentas, por lo que no es necesario que lo memorices";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds " +
            //"and 1 long silence between 1.4 and 2.1 seconds. \n\nPress SPACE to read and practice the speech.";
        }
        else
        {
            Debug.LogError("Problems with level number.");
        }

        /*preparationText.text =
            "Welcome! It is time to practice the silences of your speech. Select an speech from 1 to " +
            speeches.Length + " and practice it. \n\nPress SPACE when you are ready to present. Press the LEFT ARROW to choose another speech.";*/
        preparationText.gameObject.SetActive(true);
        //ManagerGO.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRManager.isHmdPresent)// headset connected
        {
            if (!spacePressed && OVRInput.GetDown(OVRInput.Button.One))
            {
                preparationText.text = speech + "\n\nPresiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego";
                    //"\n\n\nPress SPACE when you are ready to present.  Press SPACE again to finish the game.";
                spacePressed = true;
                if (level == 1 || level == 2)
                {
                    audioButton.gameObject.SetActive(true);
                    audioText.gameObject.SetActive(true);
                }
            }
            else if (OVRInput.GetDown(OVRInput.Button.One))
            {
                //preparationText.text = speeches[choosenSpeech];
                Manager.speech = speech;//preparationText.text
                preparationText.gameObject.SetActive(false);
                panel.gameObject.SetActive(false);
                ManagerGO.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(false);
                audio.Stop();
                audioButton.gameObject.SetActive(false);
                audioText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else if (!audioPlaying && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && spacePressed && (level == 1 || level == 2))// Button.SecondaryThumbstick
            {
                audio.Play();
                audioPlaying = true;
            }
            else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && audioPlaying)// Button.SecondaryThumbstick
            {
                audio.Stop();
                audioPlaying = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }
        else
        {
            if (!spacePressed && Input.GetKeyDown(KeyCode.Space))
            {
                silencesNeeded = 4;
                longSilencesNeeded = 1;

                preparationText.text = speech + "\n\nPresiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego";
                //"\n\n\nPress SPACE when you are ready to present.  Press SPACE again to finish the game.";
                spacePressed = true;
                if (level == 1 || level == 2)
                {
                    audioButton.gameObject.SetActive(true);
                    audioText.gameObject.SetActive(true);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                //preparationText.text = speeches[choosenSpeech];
                Manager.speech = speech;//preparationText.text
                preparationText.gameObject.SetActive(false);
                panel.gameObject.SetActive(false);
                ManagerGO.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(false);
                audio.Stop();
                audioButton.gameObject.SetActive(false);
                audioText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else if (!audioPlaying && Input.GetKeyDown(KeyCode.Alpha0) && spacePressed && (level == 1 || level == 2))
            {
                audio.Play();
                audioPlaying = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0) && audioPlaying)
            {
                audio.Stop();
                audioPlaying = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }

            
    }

    string CreateSilencesText(int silences, int longSilences)
    {
        return "For this speech, you will need to do " + silences + " silences (between 0.6 and 1.1 seconds) and " + longSilences +
            " long silences (between 1.1 and 2.1 seconds)." + 
            "\n\nPress space to see the speech. Practice it as many times as you need and press SPACE to start presenting.";
        /*return "For this speech, you will need to do " + silences + " silences (between 1.5 and 2.5 seconds) and " + longSilences +
            " long silences (between 2.5 and 3.5 seconds)." +
            "\n\nPress space to see the speech. Practice it as many times as you need and press SPACE to start presenting.";*/
    }
}
