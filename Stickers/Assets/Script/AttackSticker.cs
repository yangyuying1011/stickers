using UnityEngine;

public class AttackSticker : MonoBehaviour
{
    public float aHealth = 100f; // 攻击贴纸的血量
    public float aAttack = 10f; // 攻击贴纸的攻击力
    public float aRange = 5f; // 攻击贴纸的范围

    private Vector3 offset; // 拖拽的偏移量
    private bool isDragging; // 鼠标是否正在拖拽
    private float transY;

    void Start()
    {
        transY = transform.position.y;
    }

    void Update()
    {
        
        // 如果鼠标左键被按下并且当前没有在拖拽物体
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            // 创建一个从鼠标位置到摄像机的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 如果射线碰到了物体
            if (Physics.Raycast(ray, out hit))
            {
                // 计算鼠标位置与物体位置的偏移量
                offset = transform.position - hit.point;
                
                // 物体向上提起1m
                //transform.position = new Vector3(transform.position.x, transY + 0.14f, transform.position.z);
                
                // 如果碰到的物体是当前物体
                if (hit.transform == transform)
                {
                    // 开始拖拽
                    isDragging = true;
                    
                    
                }
            }
        }
        // 如果鼠标左键被松开，停止拖拽并放下物体
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            // 物体向下放下1m
            //transform.position = new Vector3(transform.position.x, transY , transform.position.z);
        }

        // 如果正在拖拽，更新物体位置到鼠标位置加上偏移量
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                print("hit: "+hit.point+", off: "+offset);
                transform.position = hit.point + offset;
            }
        }
    }
}
