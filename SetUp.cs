using UnityEngine;

public class SetUp : MonoBehaviour
{
    public GameObject attackPrefab; // 攻击贴纸预制件引用
    public int numberOfAttack = 10; // 要生成的攻击贴纸预制件数量

    void Start()
    {
        GenerateSticker(attackPrefab, numberOfAttack);
    }

    /* 随机生成贴纸
    ** prefab:贴纸的预制体
    ** number:生成的数量
    */
    void GenerateSticker(GameObject prefab, int number)
    {
        for (int i = 0; i < number; i++)
        {
            // 生成随机位置
            float x = Random.Range(12.0f, 48.0f);
            float y = 0.2f;
            float z = Random.Range(-18.0f, 18.0f);

            Vector3 randomPosition = new Vector3(x, y, z);

            // 在随机位置实例化预制件
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }
}
