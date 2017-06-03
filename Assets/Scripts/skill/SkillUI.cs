using UnityEngine;
using System.Collections;

public class SkillUI : MonoBehaviour {

    public static SkillUI _instance;
    private TweenPosition tween;
    private bool isShow = false;
    private PlayerStatus ps;

    public UIGrid grid;
    public GameObject skillItemPrefab;
    public int[] magicianSkillIdList;
    public int[] swordmanSkillIdList;


    void Awake() {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
    }
    void Start() {
        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
        int[] idList = null;
        switch (ps.heroType) {
            case HeroType.Magician:
                idList = magicianSkillIdList;
                break;
            case HeroType.Swordman:
                idList = swordmanSkillIdList;
                break;
        }
        foreach (int id in idList) {
            GameObject itemGo = NGUITools.AddChild(grid.gameObject, skillItemPrefab);
            grid.AddChild(itemGo.transform);
            itemGo.GetComponent<SkillItem>().SetId(id);
        }

    }


    public void TransformState() {
        if (isShow) {
            tween.PlayReverse(); isShow = false;
        } else {
            tween.PlayForward(); isShow = true;
            UpdateShow();
        }
    }

    void UpdateShow() {
        SkillItem[] items = this.GetComponentsInChildren<SkillItem>();
        foreach (SkillItem item in items) {
            item.UpdateShow(ps.level);
        }
    }
}
