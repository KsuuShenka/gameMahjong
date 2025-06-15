using UnityEngine;

public class FieldScript : MonoBehaviour
{
    public GameObject firstSelectedTile;
    public GameObject secondSelectedTile;
    private ManagerGame tileScript;
    [SerializeField] GameObject winPanel;


    private void Start()
    {
        tileScript = GetComponent<ManagerGame>();
    }

    public void SelectTile(GameObject tile)
    {
        if (firstSelectedTile == null)
        {
            firstSelectedTile = tile;
            HighlightTile(tile);
            
        }
        else if (secondSelectedTile == null)
        {
            secondSelectedTile = tile;
            HighlightTile(tile);
            ComparisonTiles();
        }
      
    }
    private void HighlightTile(GameObject tile)
    {
        tile.GetComponent<Renderer>().material.color = new Color(0.7589048f, 0.9396226f, 0.6435528f, 1);
    }

    public void ComparisonTiles ()
    {
        if (firstSelectedTile.name != secondSelectedTile.name)
        {
            SpriteRenderer spriteRenderer1 = firstSelectedTile.GetComponent<SpriteRenderer>();
            SpriteRenderer spriteRenderer2 = secondSelectedTile.GetComponent<SpriteRenderer>();
            string name1 = spriteRenderer1.sprite.name;
            string name2 = spriteRenderer2.sprite.name;
            Debug.Log(name1 + " è " + name2);
            if (name1 == name2)
            {
                Destroy(firstSelectedTile, 0.2f);
                Destroy(secondSelectedTile, 0.2f);               
                firstSelectedTile = null;
                secondSelectedTile = null;
                tileScript.tilesScore -= 2;
                if (tileScript.tilesScore<=0)
                {
                    winPanel.SetActive(true);
                }
            }
            else DeselectAll();
        }
        else DeselectAll();

    }

    private void DeselectAll()
    {

        if (firstSelectedTile != null)
        {
            firstSelectedTile.GetComponent<Renderer>().material.color = Color.white;
            firstSelectedTile = null;
        }

        if (secondSelectedTile != null)
        {
            secondSelectedTile.GetComponent<Renderer>().material.color = Color.white;
            secondSelectedTile = null;
        }
    }
  }
