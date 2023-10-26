using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Task/Target/GameObject", fileName = "Go_Target_")]
public class ObjTarget : Target
{
    [SerializeField] GameObject value;

    public override object Value => value;

    /// <summary>
    /// ���� ������Ʈ�� ��� clone�� ���·� ��������� ��찡 ���ٺ��� Equal ���ٴ�
    /// �ش� �̸��� ���ԵǾ��ִ��� ������ üũ�ϴ°� �� �ڿ������� ������ ������ �� �����ϴ�.
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public override bool IsTarget(object target)
    {
        GameObject targetObj = target as GameObject;
        if (targetObj != null)
        {
            return targetObj.name.Contains(value.name);
        }
        return false;
    }
}