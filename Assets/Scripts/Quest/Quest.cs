using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//시작 안된 상태, 진행 중, 완료, 포기, 완료 처리
public enum Q_State
{
    Inactive,
    Running,
    Complete,
    Cancel,
    OnComplete
}

[CreateAssetMenu(menuName = "Quest/Quest", fileName = "Quest_")]
public class Quest : ScriptableObject
{
    [Header("Category")]
    [SerializeField]
    private Category category;
    [SerializeField]
    private Sprite icon;

    [Header("ID")]
    [SerializeField]
    private string id;
    [SerializeField]
    private string ingame_id;
    [SerializeField, TextArea]
    private string description;

    [Header("Settings")]
    [SerializeField]
    private bool auto_complete;

    [Header("Task")]
    [SerializeField]
    TaskGroup[] taskGroups;

    private int idx;

    public Category Category => category;
    public Sprite Icon => icon;
    public string Id => id;
    public string Ingame_id => ingame_id;
    public string Description => description;

    public Q_State State {  get; private set; }
    public TaskGroup Current_Group => taskGroups[idx];
    public IReadOnlyList<TaskGroup> TaskGroups => taskGroups; 

    //상태에 따른 프로퍼티
    public bool InActive => State != Q_State.Inactive;
    public bool InComplete => State == Q_State.Complete;
    public bool InOnComplete => State == Q_State.OnComplete;
    public bool InCancel => State == Q_State.Cancel;

}