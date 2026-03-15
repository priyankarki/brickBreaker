using UnityEngine;

public class InstructionsPopup : MonoBehaviour
{
    public GameObject instructionsPanel;

    public void ShowInstructions()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);
    }
}
