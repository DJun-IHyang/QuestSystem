using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public enum TaskGroup_State
{
    InActive, Running, Complete
}

[Serializable]
public class TaskGroup
{
    [SerializeField]
    private Task[] task_Group;

    #region ������Ƽ
    //�б� ���� ����Ʈ
    public IReadOnlyList<Task> Tasks => task_Group;

    //�б� ���� ����Ʈ(private set)
    public Quest Owner { get; private set; }

    public bool AutoComplete => task_Group.All(x => x.IsComplete);

    public TaskGroup_State State { get; private set; }
    public bool IsComplete => State == TaskGroup_State.Complete;
    #endregion

    public void Setup(Quest owner)
    {
        Owner = owner;
        foreach (var task in task_Group)
        {
            task.Setup(owner);
        }
    }
    public void Start()
    {
        State = TaskGroup_State.Running;
        foreach (var task in task_Group)
        {
            task.Start();
        }
    }
    public void End()
    {
        State = TaskGroup_State.Complete;
        foreach (var task in task_Group)
        {
            task.End();
        }
    }

    public void Complete()
    {
        // �׷쿡�� Complete ó���� �Ǿ��ִٸ� �۾����� �ʵ���
        if (IsComplete)
            return;

        State = TaskGroup_State.Complete;
        foreach (var task in task_Group)
        {
            if(!task.IsComplete)
                task.Complete();
        }
    }

    public void Receive(string category, object target, int S_count)
    {
        foreach (var task in task_Group)
        {
            if (task.IsTarget(category, target))
            {
                task.Receive(S_count);
            }
        }
    }
}
