using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour
{
    
    public Animator[] panelAnimator;
    public Image[] panelImage;
    private int Index = -1;

    public string sceneName = "Sample Scene 1";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewPanels();
    }
    
    private void NewPanels()
    {
        if (panelImage != null && panelImage.Length > 0)
        {
            for (int i = 0; i < panelImage.Length; i++)
                panelImage[i].gameObject.SetActive(false);

            Index = -1;
        }

        if (panelAnimator != null && panelAnimator.Length > 0)
        {
            for (int i = 0; i < panelAnimator.Length; i++)
            {
                if (panelAnimator[i] != null)
                    panelAnimator[i].gameObject.SetActive(false);
            }

            Index = -1;
        }
        bool hasImages = panelImage != null && panelImage.Length > 0;
        bool hasAnimators = panelAnimator != null && panelAnimator.Length > 0;

        if (!hasImages && !hasAnimators)
        {
            
            SceneManager.LoadSceneAsync("Sample Scene 1");
        }

    }

    public void ContinueButton()
    {
        Index++;

        int imageCount = panelImage != null ? panelImage.Length : 0;
        int animCount = panelAnimator != null ? panelAnimator.Length : 0;
        int totalPanels = Mathf.Max(imageCount, animCount);

        // If we've shown all panels, go to next scene
        if (Index >= totalPanels)
        {
            SceneManager.LoadSceneAsync(sceneName);
            return;
        }

        if (panelImage != null && Index < imageCount)
        {
            panelImage[Index].gameObject.SetActive(true);
        }

        if (panelAnimator != null && Index < animCount)
        {
            panelAnimator[Index].gameObject.SetActive(true);
        }
    }

}
