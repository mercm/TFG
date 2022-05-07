﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreparationBackup : MonoBehaviour
{
    public Text preparationText;
    public GameObject panel;

    //List<string> speeches = new List<string>(); //contains the speeches the user can select.
    //List<string> instructions = new List<string>(); //contains the specific instructions for starting the game.
    private string[] speeches = new string[7];
    //private string[] instructions = new string[7];
    private List<string> keywords = new List<string>();

    private int level;
    private bool spacePressed;
    private bool audioPlaying;
    private int choosenSpeech;
    public static int silencesNeeded;
    public static int longSilencesNeeded;
    public static List<string> kwordNeeded = new List<string>();
    public Button returnButton;
    public Button audioButton;
    public Text audioText;
    public AudioSource audio;

    //public GameObject SoundLoudness;
    public GameObject ManagerGO;

    // Start is called before the first frame update
    void Start()
    {
        //SoundLoudness.gameObject.SetActive(false);
        //Manager.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
        level = PlayerPrefs.GetInt("Level");

        //Inicialization of the instruction
        /*instructions[0] = CreateSilencesText(2, 2);
        instructions[1] = CreateSilencesText(3, 1);
        instructions[2] = CreateSilencesText(3, 0);
        instructions[3] = CreateSilencesText(6, 1);
        instructions[4] = CreateSilencesText(6, 1);
        instructions[5] = CreateSilencesText(6, 1);
        instructions[6] = CreateSilencesText(6, 1);*/

        //Inicialization of the speeches
        speeches[0] =
            @"La vida es lo mas preciado que posee el hombre, a el se le otorga una sola vez y debe saber vivirla de forma tal, 
            que no le cause un dolor torturante por los años pasados en vano; y para que no le remuerda la conciencia, por el ayer 
            vil y mezquino que no lo supo aprovechar, y para que al morir pueda exclamar que toda su vida y todas sus fuerzas, 
            lo ha dedicado a lo mas hermoso que posee el mundo, a la lucha por la justicia, la paz y la liberación de la humanidad.";
        speeches[1] =
            @"El pueblo clama ¡paz!, ¡paz!, pero no hay paz. La guerra ha empezado ya, yo no se que piensan hacer los otros pero
            en lo que a mi respecta,  dadme la libertad o dadme la muerte.";
        speeches[2] =
            @"Sé que a muchos os escandalizará la severidad de mis palabras” ¿pero, acaso no existen motivos para esta severidad?
            Hoy, seré tan crudo como la verdad y tan inflexible como la justicia. Sobre este punto no quiero pensar, ni hablar, ni
            escribir con moderación. ¡No! ¡No! Decid a un hombre que su casa está en llamas para no darle una alarma moderada;
            decidle que rescate a su esposa de manos del raptor; decidle a una madre, que libere poco a poco a su hijo del fuego
            en que ha caído; pero no me animéis a emplear la moderación en la lucha por una causa tan justa como la presente.";
        speeches[3] =
            @"Con diez cañones por banda,
            viento en popa a toda vela,
            no corta el mar, sino vuela
            un velero bergantín;

            bajel pirata que llaman,
            por su bravura, el Temido,
            en todo mar conocido
            del uno al otro confín.";
        speeches[4] =
            @"Martina despertó a las ocho, como todas las mañanas. No le costaba madrugar, pero lo que sí le molestaba era salir de 
            la cama en invierno: odiaba el frío. Sin embargo, al abrir los ojos aquel día, no pensó en lo húmedas que iban a estar la 
            ropa y las zapatillas para ir al colegio —todo ya preparado por ella misma sobre su escritorio, la noche anterior—. Tenía 
            una sensación rara en el estómago, como si allí dentro hubiese algo… que no solía estar allí.";
        speeches[5] =
            @"Aparte del vaso de zumo, Martina bebió su acostumbrado vaso de leche y se comió el huevo, tres galletas y terminó la ensalada. 
            Durante todo el tiempo que estuvo comiendo, su madre no le quitó ojo de encima; no daba crédito.Por su parte, Martina mantuvo la 
            mirada fija en los alimentos que iba engullendo.Cuando terminó se levantó de la silla, miró a su madre y al reloj colgado en la cocina. 
            ¡Se había hecho tarde y no iba a llegar a coger el autobús!Su madre se dio cuenta de la cara de susto de Martina y miró también hacia el reloj.";

        choosenSpeech = 6;
        silencesNeeded = 4;
        longSilencesNeeded = 1;
        kwordNeeded.Clear();

        if (level == 1)
        {

            speeches[6] =
                "Pues bien, (//) ese amuleto valía un cubo lleno de reales de oro, (///) pero para compensar a Táborlin por su generosidad, el calderero se lo "+
            "vendió por solo un penique de hierro, (//) un penique de cobre (//) y un penique de plata. (///) Era negro como una noche de invierno (//) y estaba frío "+ 
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

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Necesitas 5 silencios entre 0.7 y 1.4 segundos (representados con //) " +
            "y 3 silencios largos entre 1.4 y 2.1 segundos (representados con ///). \n\nPresiona A para leer el discurso.";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds (represented with //) " +
            //"and 1 long silence between 1.4 and 2.1 seconds (represented with ///). \n\nPress SPACE to read and practice the speech.";
        }
        else if (level == 2)
        {

            speeches[6] =
                @"Carter apretó los labios dibujando una fina línea. Estiró un brazo y tiró del extremo de la manta ensangrentada. Lo que había dentro rodó 
            sobre sí mismo una vez y se enganchó en la tela. Carter dio otro tirón y se oyó un fuerte ruido, como si hubiera vaciado un saco de guijarros 
            encima de la mesa.
            Era una araña negra como el carbón y del tamaño de una rueda de carro.";
            /*    @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, consciente de la responsabilidad que comporta y con 
            la mayor esperanza en el futuro de España.

            Una nación forjada a lo largo de siglos de Historia por el trabajo compartido de millones de personas de todos los lugares de nuestro territorio 
            y sin cuya participación no puede entenderse el curso de la Humanidad.";*/

            kwordNeeded.Add("Estiró un brazo");
            kwordNeeded.Add("Lo que había dentro");
            kwordNeeded.Add("y se enganchó");
            kwordNeeded.Add("Carter dio otro");
            kwordNeeded.Add("como si hubiera");
            kwordNeeded.Add("como si hubiera");
            kwordNeeded.Add("Era una araña");
            kwordNeeded.Add("y del tamaño");

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Necesitas 6 silencios de entre 0.7 y 1.4 segundos " +
            "y 2 silencios largos de entre 1.4 y 2.1 segundos. \n\nPresiona A para leer el discurso.";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds " +
            //"and 1 long silence between 1.4 and 2.1 seconds. \n\nPress SPACE to read and practice the speech.";
        }
        else if ( level == 3)
        {

            speeches[6] =
                @"Retazos de luz procedentes de las ventanas de la posada se proyectaban sobre el camino de tierra y las puertas de la herrería de enfrente. 
            No era un camino muy ancho, ni muy transitado. No parecía que condujera a ninguna parte, como pasa con algunos caminos. El posadero inspiró el aire 
            otoñal y miró alrededor, inquieto, como si esperase que sucediera algo.";
            /*    @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, consciente de la responsabilidad que comporta y con 
            la mayor esperanza en el futuro de España.

            Una nación forjada a lo largo de siglos de Historia por el trabajo compartido de millones de personas de todos los lugares de nuestro territorio 
            y sin cuya participación no puede entenderse el curso de la Humanidad.";*/

            kwordNeeded.Add("No era un camino");
            kwordNeeded.Add("ni muy transitado");
            kwordNeeded.Add("No parecía que");
            kwordNeeded.Add("El posadero");
            kwordNeeded.Add("inquieto");

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Necesitas 4 silencios de entre 0.7 y 1.4 segundos " +
            "y 2 silencios largos de entre 1.4 y 2.1 segundos. \n\nPresiona A para leer el discurso.";
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
        choosenSpeech = 6;
        silencesNeeded = 4;
        longSilencesNeeded = 1;
        kwordNeeded.Clear();

        Manager.speech = "";
        if (level == 1)
        {

            speeches[6] =
                "Pues bien, (//) ese amuleto valía un cubo lleno de reales de oro, (///) pero para compensar a Táborlin por su generosidad, el calderero se lo " +
            "vendió por solo un penique de hierro, (//) un penique de cobre (//) y un penique de plata. (///) Era negro como una noche de invierno (//) y estaba frío " +
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

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Necesitas 5 silencios entre 0.7 y 1.4 segundos (representados con //) " +
            "y 3 silencios largos entre 1.4 y 2.1 segundos (representados con ///). \n\nPresiona A para leer el discurso.";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds (represented with //) " +
            //"and 1 long silence between 1.4 and 2.1 seconds (represented with ///). \n\nPress SPACE to read and practice the speech.";
        }
        else if (level == 2)
        {

            speeches[6] =
                @"Carter apretó los labios dibujando una fina línea. Estiró un brazo y tiró del extremo de la manta ensangrentada. Lo que había dentro rodó 
            sobre sí mismo una vez y se enganchó en la tela. Carter dio otro tirón y se oyó un fuerte ruido, como si hubiera vaciado un saco de guijarros 
            encima de la mesa.
            Era una araña negra como el carbón y del tamaño de una rueda de carro.";
            /*    @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, consciente de la responsabilidad que comporta y con 
            la mayor esperanza en el futuro de España.

            Una nación forjada a lo largo de siglos de Historia por el trabajo compartido de millones de personas de todos los lugares de nuestro territorio 
            y sin cuya participación no puede entenderse el curso de la Humanidad.";*/

            kwordNeeded.Add("Estiró un brazo");
            kwordNeeded.Add("Lo que había dentro");
            kwordNeeded.Add("y se enganchó");
            kwordNeeded.Add("Carter dio otro");
            kwordNeeded.Add("como si hubiera");
            kwordNeeded.Add("como si hubiera");
            kwordNeeded.Add("Era una araña");
            kwordNeeded.Add("y del tamaño");

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Necesitas 6 silencios de entre 0.7 y 1.4 segundos " +
            "y 2 silencios largos de entre 1.4 y 2.1 segundos. \n\nPresiona A para leer el discurso.";
            //"Welcome! It is time to practice the silences of your speech. \n\nYou need to do 4 silences between 0.7 and 1.4 seconds " +
            //"and 1 long silence between 1.4 and 2.1 seconds. \n\nPress SPACE to read and practice the speech.";
        }
        else if (level == 3)
        {

            speeches[6] =
                @"Retazos de luz procedentes de las ventanas de la posada se proyectaban sobre el camino de tierra y las puertas de la herrería de enfrente. 
            No era un camino muy ancho, ni muy transitado. No parecía que condujera a ninguna parte, como pasa con algunos caminos. El posadero inspiró el aire 
            otoñal y miró alrededor, inquieto, como si esperase que sucediera algo.";
            /*    @"Inicio mi reinado con una profunda emoción por el honor que supone asumir la Corona, consciente de la responsabilidad que comporta y con 
            la mayor esperanza en el futuro de España.

            Una nación forjada a lo largo de siglos de Historia por el trabajo compartido de millones de personas de todos los lugares de nuestro territorio 
            y sin cuya participación no puede entenderse el curso de la Humanidad.";*/

            kwordNeeded.Add("No era un camino");
            kwordNeeded.Add("ni muy transitado");
            kwordNeeded.Add("No parecía que");
            kwordNeeded.Add("El posadero");
            kwordNeeded.Add("inquieto");

            preparationText.text =
           "¡Bienvenido! Es momento de practicar los silencios de un discurso. Necesitas 4 silencios de entre 0.7 y 1.4 segundos " +
            "y 2 silencios largos de entre 1.4 y 2.1 segundos. \n\nPresiona A para leer el discurso.";
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
        /*if (choosenSpeech == -1)
        {
            kwordNeeded.Clear();
            switch (Input.inputString)
            {
                case "1":
                    choosenSpeech = 0;
                    //kwordNeeded = keywords;
                    silencesNeeded = 2;
                    longSilencesNeeded = 2;
                    kwordNeeded.Add("a el se le otorga");
                    kwordNeeded.Add("que no le cause un dolor");
                    kwordNeeded.Add("y para que no le remuerda");
                    kwordNeeded.Add("y para que al morir");
                    kwordNeeded.Add("lo mas hermoso");
                    kwordNeeded.Add("a la lucha");
                    kwordNeeded.Add("la paz");
                    kwordNeeded.Add("y la liberación");
                    break;
                case "2":
                    choosenSpeech = 1;
                    silencesNeeded = 3;
                    longSilencesNeeded = 1;
                    break;
                case "3":
                    choosenSpeech = 2;
                    silencesNeeded = 3;
                    longSilencesNeeded = 0;
                    break;
                case "4":
                    choosenSpeech = 3;
                    silencesNeeded = 6;
                    longSilencesNeeded = 1;
                    break;
                case "5":
                    choosenSpeech = 4;
                    silencesNeeded = 6;
                    longSilencesNeeded = 1;
                    break;
                case "6":
                    choosenSpeech = 5;
                    silencesNeeded = 6;
                    longSilencesNeeded = 1;
                    break;
                case "7":
                    choosenSpeech = 6;
                    silencesNeeded = 4;
                    longSilencesNeeded = 1;
                    kwordNeeded.Add("consciente de la responsabilidad");
                    kwordNeeded.Add("y con la mayor esperanza");
                    kwordNeeded.Add("Una nación forjada");
                    kwordNeeded.Add("por el trabajo compartido");
                    kwordNeeded.Add("y sin cuya participación");
                    break;
                case "default":
                    break;
            }
            if (choosenSpeech != -1) // Only when a Speech has been selected
            {
                //preparationText.text = instructions[choosenSpeech];
                preparationText.text = CreateSilencesText(silencesNeeded, longSilencesNeeded);
            }
        }
        else if (!spacePressed && Input.GetKeyDown(KeyCode.Space))
        {
            preparationText.text = speeches[choosenSpeech];
            spacePressed = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            Manager.speech = preparationText.text;
            preparationText.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            ManagerGO.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            choosenSpeech = -1;
            spacePressed = false;
            preparationText.text =
                "Select an speech from 1 to " + speeches.Length + " and practice it. \n\nPress SPACE when you are ready to present.";
        }*/
        

        if (OVRManager.isHmdPresent)// headset connected
        {
            if (!spacePressed && OVRInput.GetDown(OVRInput.Button.One))
            {
                /*choosenSpeech = 6;
                silencesNeeded = 4;
                longSilencesNeeded = 1;
                kwordNeeded.Clear();

                if(level == 1)
                {
                    kwordNeeded.Add("ese amuleto valía");
                    kwordNeeded.Add("pero para compensar");
                    kwordNeeded.Add("un penique de cobre");
                    kwordNeeded.Add("un penique de plata");
                    kwordNeeded.Add("Era negro");
                    kwordNeeded.Add("y estaba frío");
                    kwordNeeded.Add("pero mientras");
                    kwordNeeded.Add("Demonios y demás");
                }
                else if (level == 2)
                {
                    kwordNeeded.Add("Estiró un brazo");
                    kwordNeeded.Add("Lo que había dentro");
                    kwordNeeded.Add("y se enganchó");
                    kwordNeeded.Add("Carter dio otro");
                    kwordNeeded.Add("como si hubiera");
                    kwordNeeded.Add("como si hubiera");
                    kwordNeeded.Add("Era una araña");
                    kwordNeeded.Add("y del tamaño");
                }
                else if (level == 3)
                {
                    kwordNeeded.Add("No era un camino");
                    kwordNeeded.Add("ni muy transitado");
                    kwordNeeded.Add("No parecía que");
                    kwordNeeded.Add("El posadero");
                    kwordNeeded.Add("inquieto");
                }

                /*kwordNeeded.Add("consciente de la responsabilidad");
                kwordNeeded.Add("y con la mayor esperanza");
                kwordNeeded.Add("Una nación forjada");
                kwordNeeded.Add("por el trabajo compartido");
                kwordNeeded.Add("y sin cuya participación");*/
                
                preparationText.text = speeches[choosenSpeech] + "Presiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego";
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
                Manager.speech = speeches[choosenSpeech];//preparationText.text
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
                choosenSpeech = 6;
                silencesNeeded = 4;
                longSilencesNeeded = 1;
                kwordNeeded.Clear();

                /*kwordNeeded.Add("consciente de la responsabilidad");
                kwordNeeded.Add("y con la mayor esperanza");
                kwordNeeded.Add("Una nación forjada");
                kwordNeeded.Add("por el trabajo compartido");
                kwordNeeded.Add("y sin cuya participación");*/
                preparationText.text = speeches[choosenSpeech] + "Presiona A cuando estés listo para presentar. Una vez estés jugando, presiona A otra vez para parar el juego";
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
                Manager.speech = speeches[choosenSpeech];//preparationText.text
                preparationText.gameObject.SetActive(false);
                panel.gameObject.SetActive(false);
                ManagerGO.gameObject.SetActive(true);
                //returnButton.gameObject.SetActive(false);
                audio.Stop();
                audioButton.gameObject.SetActive(false);
                audioText.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SceneManager.LoadScene("CinemaStart");
            }
        }

            
    }

    string CreateSilencesText(int silences, int longSilences)
    {
        return "For this speech, you will need to do " + silences + " silences (between 0.7 and 1.4 seconds) and " + longSilences +
            " long silences (between 1.4 and 2.1 seconds)." + 
            "\n\nPress space to see the speech. Practice it as many times as you need and press SPACE to start presenting.";
        /*return "For this speech, you will need to do " + silences + " silences (between 1.5 and 2.5 seconds) and " + longSilences +
            " long silences (between 2.5 and 3.5 seconds)." +
            "\n\nPress space to see the speech. Practice it as many times as you need and press SPACE to start presenting.";*/
    }
}