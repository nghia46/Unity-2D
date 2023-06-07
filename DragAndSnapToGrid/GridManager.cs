using UnityEngine;

public class GridManager : MonoBehaviour
{  public int numRows = 8;  // Number of rows in the grid
    public int numColumns = 8;  // Number of columns in the grid
    public GameObject gridCellPrefab;  // Prefab or sprite for the grid cell
    public Color evenCellColor = Color.white;  // Color of even-numbered cells
    public Color oddCellColor = Color.black;  // Color of odd-numbered cells

    private void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numColumns; column++)
            {
                Vector3 cellPosition = new Vector3(column, row, 0);  // Calculate the position of each grid cell
                GameObject gridCell = Instantiate(gridCellPrefab, cellPosition, Quaternion.identity, transform);  // Instantiate a grid cell at the calculated position
                gridCell.name = "GridCell (" + row + ", " + column + ")";  // Assign a name or identifier to the grid cell GameObject

                // Set the color of the grid cell based on the row and column indices
                Renderer renderer = gridCell.GetComponent<Renderer>();
                if ((row + column) % 2 == 0)
                {
                    renderer.material.color = evenCellColor;
                }
                else
                {
                    renderer.material.color = oddCellColor;
                }
            }
        }
    }
}
