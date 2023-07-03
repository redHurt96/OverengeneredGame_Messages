using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace _Project.Framework
{
    public class MessagesParser
    {
        public (Type, object) Execute(string data)
        {
            string[] splitData = data.Split(';');
            Assembly messagesAssemble = AppDomain.CurrentDomain
                .GetAssemblies()
                .First(x => x.FullName.Contains("OverengeeneredGame.Messages"));
            Type target = messagesAssemble.GetType(splitData[0]);
            object fromJson = JsonUtility.FromJson(splitData[1], target);

            return (target, fromJson);
        }
    }
}