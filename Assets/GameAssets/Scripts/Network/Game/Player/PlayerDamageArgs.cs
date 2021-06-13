using System;
using UnityEngine;

public class PlayerDamageArgs
{
        public PlayerDamageArgs(string text) { Text = text; }
        public string Text { get; } // readonly
}
