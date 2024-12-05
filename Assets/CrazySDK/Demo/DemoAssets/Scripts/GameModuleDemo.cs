﻿using System.Collections.Generic;
using UnityEngine;

namespace CrazyGames
{
    public class GameModuleDemo : MonoBehaviour
    {
        private void Start()
        {
            CrazySDK.Init(() => { }); // ensure if starting this scene from editor it is initialized
        }

        public void Happytime()
        {
            CrazySDK.Game.HappyTime();
        }

        public void GameplayStart()
        {
            CrazySDK.Game.GameplayStart();
        }

        public void GameplayStop()
        {
            CrazySDK.Game.GameplayStop();
        }

        public void InviteLink()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("roomId", "1234");
            var inviteLink = CrazySDK.Game.InviteLink(parameters);
            Debug.Log("Invite link (also copied to clipboard): " + inviteLink);
            CrazySDK.Game.CopyToClipboard(inviteLink);
        }

        public void ShowInviteButton()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("roomId", "1234");
            var inviteLink = CrazySDK.Game.ShowInviteButton(parameters);
            Debug.Log("Invite button link: " + inviteLink);
        }

        public void HideInviteButton()
        {
            CrazySDK.Game.HideInviteButton();
        }


        public void ParseInviteLink()
        {
            if (Application.isEditor)
            {
                Debug.Log("Cannot parse url in Unity editor, try running it in a browser");
            }
            else
            {
                var roomId = CrazySDK.Game.GetInviteLinkParameter("roomId");
                Debug.Log($"Invite link param roomId = {roomId}");
            }
        }
    }
}