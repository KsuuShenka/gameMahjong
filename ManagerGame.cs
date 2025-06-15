using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    [SerializeField] GameObject[] tileElem;
    [SerializeField] GameObject playPanel;
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private List<Sprite> spriteTilles = new List<Sprite>();
    public int tilesScore;
    
    void CreateSprite()
    {

        for (int i = 0; i < sprites.Length; i++)
        {
            spriteTilles.Add(sprites[i]);
            spriteTilles.Add(sprites[i]); 
        }

        int[] counts = new int[sprites.Length];

        while (spriteTilles.Count < tileElem.Length)
        {
            for (int i = 0; i < sprites.Length; i++)
            {
                if (spriteTilles.Count >= tileElem.Length) break;

                spriteTilles.Add(sprites[i]);
                counts[i]++;

                if (counts[i] % 2 != 0)
                {
                    spriteTilles.Add(sprites[i]);
                    counts[i]++;
                }
            }
        }
    }

    public List<Sprite> ShuffleList(List<Sprite> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            Sprite temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }
    public void onClickReset()
    {
        tileElem = GameObject.FindGameObjectsWithTag("tilleTag");
        spriteTilles = ShuffleList(spriteTilles);

        for (int i = 0; i < tileElem.Length; i++)
        {
            spriteRenderer = tileElem[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = spriteTilles[i];
        }
    }

    public void onClickStartGame()
    {
        tileElem = GameObject.FindGameObjectsWithTag("tilleTag");
        tilesScore = tileElem.Length;
        CreateSprite();
        spriteTilles = ShuffleList(spriteTilles);

        for (int i = 0; i < tileElem.Length; i++)
        {
            spriteRenderer = tileElem[i].GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = spriteTilles[i];
        }
    }
}
