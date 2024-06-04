using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WriteGender : MonoBehaviour
{
    public Toggle maleToggle;
    public Toggle femaleToggle;

    public void OnToggleChanged()
    {
        if (femaleToggle.isOn)
        {
            File.WriteAllText("Assets/Resources/CharacterRecipes/Gender.txt", "Female");
        }
        else
        {
            File.WriteAllText("Assets/Resources/CharacterRecipes/Gender.txt", "Male");
        }
    }
}
