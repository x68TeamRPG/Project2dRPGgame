using UnityEngine;

public struct SelectedAction
{
    public string skill;
    public Waza waza;
    public Item item;

    public SelectedAction(string skill, Waza waza = null, Item item = null)
    {
        this.skill = skill;
        this.waza = waza;
        this.item = item;
    }

    public void SetAction(string skill = "attack", Waza waza = null, Item item = null)
    {
        this.skill = skill;
        this.waza = waza;
        this.item = item;
        Debug.Log($"SelectedAction set: skill={skill}, waza={(waza != null ? waza.name : "<none>")}, item={(item != null ? item.name : "<none>")}");
    }
};