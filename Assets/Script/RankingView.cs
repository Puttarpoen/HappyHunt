using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(ScrollRect))]
public class RankingView : MonoBehaviour
{
    public static RankingView instance { get; private set; }

    private ScrollRect sr;
    public GameObject prefab;
    public SelectGame sg;

    public List<Sprite> topRankSprite = new List<Sprite>();
    private void Awake()
    {
        sr = transform.GetComponent<ScrollRect>();
    }
    private void OnEnable()
    {
        instance = this;
        GameService.instance.GetRankingScore(sg.indexGame);
    }

    public void SetView(List<RankingScore> list)
    {
        ClearObjInParent();
        int index = 0;
        list.ForEach(s =>
        {
            var player = Instantiate(prefab.GetComponent<RankItemObj>(), sr.content);
            if(index < 3)
            {
                player.topRankImg.sprite = topRankSprite[index];
            }
            player.name.text = s.username;
            player.score.text = s.score.ToString();
            index++;
        });
    }

    private void ClearObjInParent()
    {
        foreach (Transform child in sr.content)
        {
            Destroy(child.gameObject);
        }
    }
}
