using TMPro;
using UnityEngine;

public class TextExtensions : MonoBehaviour
{
    [Header("Configurables")]
    [SerializeField]
    private string preText = string.Empty;

    [SerializeField]
    private string postText = string.Empty;

    private TMP_Text currentText = null;

    private void Awake()
    {
        currentText = GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Preferred code would have been:
    /// 
    /// public void UpdateText<T>(T text) where T: IConvertible
    /// {
    ///     UpdateText(text.ToString());
    /// }
    /// 
    /// </summary>
    public void UpdateText(int text)
    {
        UpdateText(text.ToString());
    }

    public void UpdateText(string text)
    {
        currentText.text = $"{preText} {text} {postText}";
    }
}
