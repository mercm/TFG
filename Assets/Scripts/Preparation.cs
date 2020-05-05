using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preparation : MonoBehaviour
{
    public Text preparationText;

    //List<string> speeches = new List<string>(); //contains the speeches the user can select.
    //List<string> instructions = new List<string>(); //contains the specific instructions for starting the game.
    private string[] speeches = new string[3];
    private string[] instructions = new string[3];

    private bool spacePressed;
    private int choosenSpeech;

    public GameObject SoundLoudness;

    // Start is called before the first frame update
    void Start()
    {
        SoundLoudness.gameObject.SetActive(false);
        choosenSpeech = -1;
        spacePressed = false;

        instructions[0] = CreateSilencesText(2, 2);
        instructions[1] = CreateSilencesText(3, 1);
        instructions[2] = CreateSilencesText(3, 0);

        speeches[0] = "La vida es lo mas preciado que posee el hombre, a el se le otorga una sola vez y debe saber vivirla" +
            " de forma tal, que no le cause un dolor torturante por los años pasados en vano; y para que no le remuerda la conciencia," +
            " por el ayer vil y mezquino que no lo supo aprovechar, y para que al morir pueda exclamar que toda su vida y todas sus" +
            " fuerzas, lo ha dedicado a lo mas hermoso que posee el mundo, a la lucha por la justicia, la paz y la liberación de la humanidad.";
        speeches[1] = "El pueblo clama ¡paz!, ¡paz!, pero no hay paz. La guerra ha empezado ya, yo no se que piensan hacer los otros" +
            " pero en lo que a mi respecta,  dadme la libertad o dadme la muerte.";
        speeches[2] = "Sé que a muchos os escandalizará la severidad de mis palabras” ¿pero, acaso no existen motivos para esta severidad?" +
            " Hoy, seré tan crudo como la verdad y tan inflexible como la justicia. Sobre este punto no quiero pensar, ni hablar, ni" +
            " escribir con moderación. ¡No! ¡No! Decid a un hombre que su casa está en llamas para no darle una alarma moderada;" +
            " decidle que rescate a su esposa de manos del raptor; decidle a una madre, que libere poco a poco a su hijo del fuego en que" +
            " ha caído; pero no me animéis a emplear la moderación en la lucha por una causa tan justa como la presente.";

        preparationText.text = "Welcome! It is time to practice the silences of your speech. Select an speech from 1 to " + speeches.Length + 
            " and practice it. Press space when you are ready to present.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            choosenSpeech = 0;
            preparationText.text = instructions[choosenSpeech];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            choosenSpeech = 1;
            preparationText.text = instructions[choosenSpeech];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            choosenSpeech = 2;
            preparationText.text = instructions[choosenSpeech];
        }
        else if (choosenSpeech > -1 && choosenSpeech < speeches.Length && Input.GetKeyDown(KeyCode.Space))
        {
            preparationText.text = speeches[choosenSpeech];
            spacePressed = true;
            choosenSpeech = -1;
        }
        else if(spacePressed && Input.GetKeyDown(KeyCode.Space))
        {
            SoundLoudness.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    string CreateSilencesText(int silences, int longSilences)
    {
        return "For this speech, you will need to do " + silences + "silences (between 1.5 and 2.5 seconds) and " + longSilences +
            "long silences (between 2.5 and 3.5 seconds). " +
            "\n\nPress space to see the speech. Practice it as many times as you need and hit the space button to start presenting.";
    }
}
