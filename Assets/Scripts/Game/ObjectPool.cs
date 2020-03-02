using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对象池
/// </summary>
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    public int initSpawnCount = 5;
    //各物体对象池
    private List<GameObject> normalPlatformList = new List<GameObject>();
    private List<GameObject> commonPlatformList = new List<GameObject>();
    private List<GameObject> grassPlatformList = new List<GameObject>();
    private List<GameObject> winterPlatformList = new List<GameObject>();
    private List<GameObject> spikePlatformLeftList = new List<GameObject>();
    private List<GameObject> spikePlatformRightList = new List<GameObject>();
    private List<GameObject> deathEffectList = new List<GameObject>();
    private List<GameObject> diamondList = new List<GameObject>();
    private ManagerVars vars;

    private void Awake()
    {
        Instance = this;
        vars = ManagerVars.GetManagerVars();
        Init();
    }
    /// <summary>
    /// 初始化对象池
    /// </summary>
    private void Init()
    {
        //单个普通
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.normalPlatformPre, ref normalPlatformList);
        }
        //多个普通
        for (int i = 0; i < initSpawnCount; i++)
        {
            for (int j = 0; j < vars.commonPlatformGroup.Count; j++)
            {
                InstantiateObject(vars.commonPlatformGroup[j], ref commonPlatformList);
            }
        }
        //草地
        for (int i = 0; i < initSpawnCount; i++)
        {
            for (int j = 0; j < vars.grassPlatformGroup.Count; j++)
            {
                InstantiateObject(vars.grassPlatformGroup[j], ref grassPlatformList);
            }
        }
        //冬天
        for (int i = 0; i < initSpawnCount; i++)
        {
            for (int j = 0; j < vars.winterPlatformGroup.Count; j++)
            {
                InstantiateObject(vars.winterPlatformGroup[j], ref winterPlatformList);
            }
        }
        //钉子 左边
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.spikePlatformLeft, ref spikePlatformLeftList);
        }
        //钉子 右边
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.spikePlatformRight, ref spikePlatformRightList);
        }
        //死亡动态
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.deathEffect, ref deathEffectList);
        }
        //钻石
        for (int i = 0; i < initSpawnCount; i++)
        {
            InstantiateObject(vars.diamondPre, ref diamondList);
        }
    }

    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <param name="prefab">预制体</param>
    /// <param name="addList">各对象池集合</param>
    /// <returns></returns>
    private GameObject InstantiateObject(GameObject prefab, ref List<GameObject> addList)
    {
        GameObject go = Instantiate(prefab, transform);
        go.SetActive(false);
        addList.Add(go);
        return go;
    }

    /// <summary>
    /// 从对象池中拿 单个平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetNormalPlatform()
    {
        for (int i = 0; i < normalPlatformList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (normalPlatformList[i].activeInHierarchy == false)
            {
                return normalPlatformList[i];
            }
        }
        return InstantiateObject(vars.normalPlatformPre, ref normalPlatformList);
    }
    /// <summary>
    ///从对象池中拿 组合平台
    /// </summary>
    /// <returns></returns>
    public GameObject GetCommonPlatformGroup()
    {
        for (int i = 0; i < commonPlatformList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (commonPlatformList[i].activeInHierarchy == false)
            {
                return commonPlatformList[i];
            }
        }
        int ran = Random.Range(0, vars.commonPlatformGroup.Count);
        return InstantiateObject(vars.commonPlatformGroup[ran], ref commonPlatformList);
    }
    /// <summary>
    /// 从对象池中拿 草地
    /// </summary>
    /// <returns></returns>
    public GameObject GetGrassPlatformGroup()
    {
        for (int i = 0; i < grassPlatformList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (grassPlatformList[i].activeInHierarchy == false)
            {
                return grassPlatformList[i];
            }
        }
        int ran = Random.Range(0, vars.grassPlatformGroup.Count);
        return InstantiateObject(vars.grassPlatformGroup[ran], ref grassPlatformList);
    }
    /// <summary>
    /// 从对象池中拿 冬天
    /// </summary>
    /// <returns></returns>
    public GameObject GetWinterPlatformGroup()
    {
        for (int i = 0; i < winterPlatformList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (winterPlatformList[i].activeInHierarchy == false)
            {
                return winterPlatformList[i];
            }
        }
        int ran = Random.Range(0, vars.winterPlatformGroup.Count);
        return InstantiateObject(vars.winterPlatformGroup[ran], ref winterPlatformList);
    }

    /// <summary>
    /// 从对象池中拿 左钉子
    /// </summary>
    /// <returns></returns>
    public GameObject GetLeftSpikePlatform()
    {
        for (int i = 0; i < spikePlatformLeftList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (spikePlatformLeftList[i].activeInHierarchy == false)
            {
                return spikePlatformLeftList[i];
            }
        }
        return InstantiateObject(vars.spikePlatformLeft, ref spikePlatformLeftList);
    }
    /// <summary>
    /// 从对象池中拿 右钉子
    /// </summary>
    /// <returns></returns>
    public GameObject GetRightSpikePlatform()
    {
        for (int i = 0; i < spikePlatformRightList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (spikePlatformRightList[i].activeInHierarchy == false)
            {
                return spikePlatformRightList[i];
            }
        }
        return InstantiateObject(vars.spikePlatformRight, ref spikePlatformRightList);
    }
    /// <summary>
    /// 从对象池中拿 特效
    /// </summary>
    /// <returns></returns>
    public GameObject GetDeathEffect()
    {
        for (int i = 0; i < deathEffectList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (deathEffectList[i].activeInHierarchy == false)
            {
                return deathEffectList[i];
            }
        }
        return InstantiateObject(vars.deathEffect, ref deathEffectList);
    }
    /// <summary>
    /// 从对象池中拿 钻石
    /// </summary>
    /// <returns></returns>
    public GameObject GetDiamond()
    {
        for (int i = 0; i < diamondList.Count; i++)
        {
            //如果生成物体不在场景中显示,则返回继续使用
            if (diamondList[i].activeInHierarchy == false)
            {
                return diamondList[i];
            }
        }
        return InstantiateObject(vars.diamondPre, ref diamondList);
    }
}
