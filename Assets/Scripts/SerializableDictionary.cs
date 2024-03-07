using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TK,TV> : Dictionary<TK,TV> , ISerializationCallbackReceiver
{
    //public Dictionary<TK, TV> _Dictionary = this; 
    public List<TK> _Keys = new List<TK>();
    public List<TV> _Values = new List<TV>();
    
    public void OnBeforeSerialize()//pour "sauvegarder"
    {
        _Keys.Clear();
        _Values.Clear();
        foreach (var kvp in this)
        {
            _Keys.Add(kvp.Key);
            _Values.Add(kvp.Value);
        }
    }
    public void OnAfterDeserialize()//pour "charger"
    {
        this.Clear();
        for(int i =0; i !=Math.Min(_Keys.Count, _Values.Count); i++)
        {
            this.Add(_Keys[i], _Values[i]);
        }
    }
}
