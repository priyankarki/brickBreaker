using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [Header("Brick Settings")]
    public GameObject brickPrefab;
    public int rows = 6;
    public int cols = 10;
    public float spacing = 0.2f;
    public float brickWidth = 1.5f;
    public float brickHeight = 0.6f;

    [Header("Walls")]
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;

    [Header("UI")]
    public GameObject winPanel;

    [Header("Offsets")]
    public float topPadding = 0.5f; // space between top wall and first row


    private int totalBricks;

    private Color[] rowColors = new Color[]
    {
        new Color(0.2f, 0.2f, 0.2f), // dark grey
        Color.red,
        Color.yellow,
        new Color(1f, 0.5f, 0f),   // orange
        new Color(1f, 0.4f, 0.8f), // pink
        Color.green,
    };

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false); // hide win panel at start

        GenerateBricks();
    }

    void GenerateBricks()
    {
        if (brickPrefab == null || leftWall == null || rightWall == null || topWall == null)
        {
            Debug.LogError("Assign brickPrefab and all walls in the Inspector!");
            return;
        }

        totalBricks = rows * cols;

        // Wall positions and half widths/heights
        float leftLimit = leftWall.transform.position.x + (leftWall.transform.localScale.x / 2f) + (brickWidth / 2f);
        float rightLimit = rightWall.transform.position.x - (rightWall.transform.localScale.x / 2f) - (brickWidth / 2f);
        float topLimitY = topWall.transform.position.y 
                    - (topWall.transform.localScale.y / 2f)  // half wall height
                    - (brickHeight / 2f)                    // half brick height
                    - topPadding;                            // extra padding


        float availableWidth = rightLimit - leftLimit;
        float requiredWidth = cols * brickWidth + (cols - 1) * spacing;

        // Reducing columns if required width is too big
        if (requiredWidth > availableWidth)
        {
            int maxCols = Mathf.FloorToInt((availableWidth + spacing) / (brickWidth + spacing));
            cols = Mathf.Max(1, maxCols); // ensure at least 1 column
            totalBricks = rows * cols;
        }

        // Make bricks centered witin X axis
        float totalBricksWidth = cols * brickWidth + (cols - 1) * spacing;
        float startX = leftLimit + (availableWidth - totalBricksWidth) / 2f + brickWidth / 2f;

        for (int row = 0; row < rows; row++)
        {
            Color rowColor = rowColors[row % rowColors.Length];

            for (int col = 0; col < cols; col++)
            {
                float x = startX + col * (brickWidth + spacing);
                float y = topLimitY - row * (brickHeight + spacing);
                Vector3 pos = new Vector3(x, y, 0f);

                GameObject brick = Instantiate(brickPrefab, pos, Quaternion.identity, transform);
                brick.tag = "Brick";

                // Add Brick script
                Brick brickScript = brick.AddComponent<Brick>();
                brickScript.Init(this);

                // Set color & remove shadows
                Renderer rend = brick.GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material.color = rowColor;
                    rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    rend.receiveShadows = false;
                }
            }
        }
    }

    public void BrickDestroyed()
    {
        totalBricks--;

        if (totalBricks <= 0 && winPanel != null)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f; // pause game
        }
    }
}
