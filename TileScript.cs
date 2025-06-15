using UnityEngine;

public class TileScript : MonoBehaviour
{
    public FieldScript fieldScript;
    private bool available = true;

    public LayerMask layerTile;

    void Start()
    {
        fieldScript = FindObjectOfType<FieldScript>();
    }

    void OnMouseDown()
    {
       if (available) fieldScript.SelectTile(gameObject);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((layerTile.value & (1 << collision.gameObject.layer)) != 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
            available = false;
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        available = true;
    }
}
