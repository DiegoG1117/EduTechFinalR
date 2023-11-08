using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class RegistroEstudiante : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField lastNameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField courseIdInput;
    public Button registroButton;

    public Toggle aceptarToggle; // Agregado el Toggle

    public GameObject canvasRegistro;
    //public GameObject canvasLogin; // Aseg�rate de asignar el canvas de Login en el Inspector de Unity

    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text resultadoTexto;

    [SerializeField] TMP_InputField inputcontraseñaV;
    [SerializeField] TMP_Text textocontraseñaV;

    [SerializeField] TMP_Text textonombreV;
    [SerializeField] TMP_Text textoapellidoV;
    [SerializeField] TMP_Text textoemailV;
    [SerializeField] TMP_Text textoclaseV;
    [SerializeField] TMP_Text textotoggleV;

    public GameObject panelMiraCorreo;

    public delegate char ValidarInputDelegate(string text, int charIndex, char addedChar);

    private const string role = "1"; // Valor constante para el campo role

    void Start()
    {
        //panelMiraCorreo.SetActive(false);

        if (registroButton != null)
        {
            registroButton.onClick.AddListener(RegistrarEstudiante);
            registroButton.onClick.AddListener(ValidarCampos);

        }
        else
        {
            Debug.LogError("Bot�n de registro no asignado en el Inspector de Unity.");
        }

        // Limitar a 10 caracteres
        nameInput.characterLimit = 10;
        lastNameInput.characterLimit = 10;

        // No permitir espacios
        nameInput.contentType = TMP_InputField.ContentType.Standard;
        lastNameInput.contentType = TMP_InputField.ContentType.Standard;

        // Asignar validador de entrada
        nameInput.onValidateInput += ValidarInput;
        lastNameInput.onValidateInput += ValidarInput;

        // Asignar validador de entrada
        emailInput.contentType = TMP_InputField.ContentType.Standard;
        emailInput.inputValidator = ScriptableObject.CreateInstance<EmailInputValidator>();

        if (aceptarToggle != null)
        {
            aceptarToggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
    }

    void OnToggleValueChanged(bool value)
    {
        // Puedes agregar l�gica adicional si es necesario
        Debug.Log("Toggle Cambiado a: " + value);
    }

    char ValidarInput(string text, int charIndex, char addedChar)
    {
        // Implementa tu l�gica de validaci�n aqu�
        if (char.IsLetter(addedChar))
        {
            return addedChar;
        }
        else
        {
            return '\0'; // Car�cter no v�lido
        }
    }


    void RegistrarEstudiante()
    {
        string name = nameInput.text;
        string lastName = lastNameInput.text;
        string email = emailInput.text;
        string password = passwordInput.text;
        int courseId = 0;

        string correoIngresado = inputField.text;


        if (int.TryParse(courseIdInput.text, out courseId) && correoIngresado.EndsWith("@uao.edu.co") &&
        !string.IsNullOrWhiteSpace(name) && name.Length >= 3 &&
        !string.IsNullOrWhiteSpace(lastName) && lastName.Length >= 3 &&
        !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Length >= 14 && // Asegura que haya texto antes de @
        !string.IsNullOrWhiteSpace(password) && password.Length >= 8 && courseId != null && aceptarToggle != null && aceptarToggle.isOn)
        {
            string jsonBody = $"{{\"name\":\"{name}\",\"last_name\":\"{lastName}\",\"email\":\"{email}\",\"password\":\"{password}\",\"role\":\"{role}\",\"course_id\":{courseId}}}";

            // Guardar el JSON en un archivo en el escritorio
            //GuardarJSONEnEscritorio(jsonBody);

            StartCoroutine(EnviarRegistro(name, lastName, email, password, courseId));

            // Apagar canvas de Registro
            if (canvasRegistro != null)
            {
                canvasRegistro.SetActive(false);
               

            }
            else
            {
                Debug.LogError("Canvas de Registro no asignado en el Inspector de Unity.");
            }

            // Encender canvas de Login
            if (panelMiraCorreo != null)
            {
                panelMiraCorreo.SetActive(true);
                //canvasLogin.SetActive(true);

                //nameInput.text = "";
                //lastNameInput.text = "";
                //emailInput.text = "";
                //passwordInput.text = "";
                //courseIdInput.text = "";

            }
            else
            {
                Debug.LogError("Canvas de Login no asignado en el Inspector de Unity.");
            }
        }
        else
        {



        }
    }
    void MostrarError(string mensaje, TMP_Text campoTexto, Color color)
    {
        campoTexto.text = mensaje;
        campoTexto.color = color;
    }

    bool ValidarNombre()
    {
        string name = nameInput.text;

        if (name.Length < 3)
        {
            MostrarError("El nombre debe tener al menos 3 caracteres", textonombreV, Color.red);
            return false;
        }
        MostrarError("Nombre", textonombreV, Color.white);
        return true;
    }

    bool ValidarApellido()
    {

        string lastName = lastNameInput.text;

        if (lastName.Length < 3)
        {
            MostrarError("El apellido debe tener al menos 3 caracteres", textoapellidoV, Color.red);
            return false;
        }
        MostrarError("Apellido", textoapellidoV, Color.white);
        return true;
    }

    bool ValidarCorreo()
    {

        string email = emailInput.text;

        if (string.IsNullOrWhiteSpace(email))
        {
            MostrarError("El campo de correo no puede estar vac�o", resultadoTexto, Color.red);
            return false;
        }
        else if (email.Length < 14)
        {
            MostrarError("El correo debe tener al menos 14 caracteres", resultadoTexto, Color.red);
            return false;
        }
        else if (!email.EndsWith("@uao.edu.co"))
        {
            MostrarError("El correo debe terminar con @uao.edu.co", resultadoTexto, Color.red);
            return false;
        }
        MostrarError("Correo electrónico ", resultadoTexto, Color.white);
        return true;
    }

    bool ValidarContraseña()
    {

        string password = passwordInput.text;

        if (string.IsNullOrWhiteSpace(password))
        {
            MostrarError("El campo de contraseña no puede estar vac�o", textocontraseñaV, Color.red);
            return false;
        }
        else if (password.Length < 8)
        {
            MostrarError("La contraseña debe tener al menos 8 caracteres", textocontraseñaV, Color.red);
            return false;
        }
        MostrarError("Contraseña", textocontraseñaV, Color.white);
        return true;
    }

    bool ValidarClase()
    {
        string courseId = courseIdInput.text;
        if (string.IsNullOrWhiteSpace(courseId) )
        {
            MostrarError("El campo de codigo de clase no puede estar vacío", textoclaseV, Color.red);
            return false;
        }
        else if (courseId.Length <= 1)
        {
            MostrarError("El codigo debe tener al menos 2 caracteres", textoclaseV, Color.red);
            return false;
        }

        MostrarError("Codigo de clase", textoclaseV, Color.white);
        return true;
    }


    bool ValidarToggle()
    {
        // Verifica que el Toggle est� marcado
        if (aceptarToggle.isOn == false)
        {
            // Si el Toggle no est� marcado, muestra un mensaje de error
            MostrarError("Es necesario que aceptes", textotoggleV, Color.red);
            return false;
        }
        else
        {
            // Si el Toggle no est� marcado, muestra un mensaje de error
            MostrarError("Estoy de acuerdo con los  ", textotoggleV, Color.white);
            return true;
        }
    }


    void ValidarCampos()
    {
        if (ValidarNombre() && ValidarApellido() && ValidarCorreo() && ValidarContraseña() && ValidarClase() && ValidarToggle())
        {
            // Todas las validaciones pasaron, puedes proceder con tu l�gica de registro
            
        }
        else
        {
            Debug.LogError("Error en el registro. Verifica los campos.");
        }
    }


    //void GuardarJSONEnEscritorio(string json)
    //{
    //    // Obtener la ruta del escritorio
    //    string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

    //    // Combinar la ruta del escritorio con el nombre del archivo
    //    string filePath = Path.Combine(desktopPath, "datos_registro.json");

    //    // Escribir el JSON en el archivo
    //    File.WriteAllText(filePath, json);

    //    Debug.Log("JSON guardado en: " + filePath);
    //}

    IEnumerator EnviarRegistro(string name, string lastName, string email, string password, int courseId)
    {
        // Configurar la solicitud POST
        UnityWebRequest request = UnityWebRequest.Post("https://edu-tech-git-dev-santiagomc2k16.vercel.app/api/users/register", "POST");

        // Crear el JSON con los datos de registro
        string jsonBody = $"{{\"name\":\"{name}\",\"last_name\":\"{lastName}\",\"email\":\"{email}\",\"password\":\"{password}\",\"role\":\"{role}\",\"course_id\":{courseId}}}";

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");


        // Enviar la solicitud y esperar la respuesta
        yield return request.SendWebRequest();

        // Verificar si hay alg�n error
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error al registrar estudiante: " + request.error);
        }
        else
        {
            Debug.Log("Estudiante registrado exitosamente");


        }
    }
}

public static class TMP_InputFieldExtensions
{
    public delegate char ValidarInputDelegate(string text, int charIndex, char addedChar);

    public static void SetInputValidator(this TMP_InputField inputField, ValidarInputDelegate validator)
    {

        inputField.contentType = TMP_InputField.ContentType.Alphanumeric;
        inputField.onValidateInput += delegate (string input, int charIndex, char addedChar) { return ValidateName(addedChar); };
    }

    private static char ValidateName(char charToValidate)
    {
        if (char.IsLetter(charToValidate))
        {
            return charToValidate;
        }
        else
        {
            return '\0'; // Carácter no valido
        }
    }
}


public class EmailInputValidator : TMP_InputValidator
{
    public override char Validate(ref string text, ref int pos, char ch)
    {
        // Validar longitud minima y maxima
        if (text.Length >= 255 || text.Length < 3)
        {
            return '\0'; // CCarácter no valido
        }

        // Validar formato de correo electrónico
        if (ch == '@' && text.IndexOf('@') == -1)
        {
            return ch;
        }
        else if (ch == '.' && text.IndexOf('@') != -1 && text.IndexOf('.') > text.IndexOf('@'))
        {
            return ch;
        }
        else if (char.IsLetterOrDigit(ch) || ch == '@' || ch == '.' || ch == '-' || ch == '_')
        {
            Debug.Log("Carácter valido: " + ch); // Imprimir car�cter v�lido en consola
            return ch;
        }
        else
        {
            Debug.Log("Carácter valido: " + ch); // Imprimir car�cter no v�lido en consola
            return '\0'; // Car�cter no v�lido
        }
    }
}


