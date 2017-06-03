using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public static Inventory _instance;
    
    private TweenPosition tween;
    private int coinCount = 1000;//金币数量

    public List<InventoryItemGrid> itemGridList = new List<InventoryItemGrid>();
    public UILabel coinNumberLabel;
    public GameObject inventoryItem;

    void Awake() {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            GetId(Random.Range(2001, 2023));
        }
    }

    //拾取到id的物品，并添加到物品栏里面
    //处理拾取物品的功能
    public void GetId(int id,int count =1) {
        //第一步是查找在所有的物品中是否存在该物品
            //第二 如果存在，让num +1
            
        InventoryItemGrid grid = null;
        foreach (InventoryItemGrid temp in itemGridList) {
            if (temp.id == id) {
                grid = temp; break;
            }
        }
        if (grid != null) {//存在的情况 
            grid.PlusNumber(count);
        } else {//不存在的情况
            foreach (InventoryItemGrid temp in itemGridList) {
                if (temp.id == 0) {
                    grid = temp; break;
                }
            }
            if (grid != null) {//第三 不过不存在，查找空的方格，然后把新创建的Inventoryitem放到这个空的方格里面
                GameObject itemGo = NGUITools.AddChild(grid.gameObject, inventoryItem);
                itemGo.transform.localPosition = Vector3.zero;
                itemGo.GetComponent<UISprite>().depth = 4;
                grid.SetId(id,count);
            }
        }
    }

    public bool MinusId(int id, int count = 1) {
        InventoryItemGrid grid = null;
        foreach (InventoryItemGrid temp in itemGridList) {
            if (temp.id == id) {
                grid = temp; break;
            }
        }
        if (grid == null) {
            return false;
        } else {
            bool isSuccess = grid.MinusNumber(count);
            return isSuccess;
        }
    }

    private bool isShow = false;

    void Show() {
        isShow = true;
        tween.PlayForward();
    }

    void Hide() {
        isShow = false;
        tween.PlayReverse();
    }


    public void TransformState() {// 转变状态
        if (isShow == false) {
            Show();
        } else {
            Hide();
        }
    }

    public void AddCoin(int count) {   
        coinCount += count;
        coinNumberLabel.text = coinCount.ToString();//更新金币的显示
    }

    //这个是取款方法，返回true表示取款成功，返回false取款失败
    public bool GetCoin(int count) {
        if (coinCount >= count) {
            coinCount -= count;
            coinNumberLabel.text = coinCount.ToString();//更新金币的显示
            return true;
        }
        return false;
    }
	
}
