using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Model;
using Assets.Scripts.Networking;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BotsController : MonoBehaviour
    {
        private readonly Dictionary<Guid, BotController> _bots = new Dictionary<Guid, BotController>();
        private GameObject _floor;
        private ArenaController _arenaController;

        public Single RefreshRate = 2;
        public GameObject BotPrefab;

        void Start()
        {
            InvokeRepeating(nameof(RefreshBots), RefreshRate, RefreshRate);
            _floor = GameObject.Find("Floor");
            _arenaController = GetComponent<ArenaController>();
        }

        private void RefreshBots()
        {
            var bots = ApiClient.GetBots();
            CleanKilledBots(bots);
            foreach (var bot in bots)
            {
                if (!_bots.ContainsKey(bot.Id))
                {
                    var newBot = Instantiate(BotPrefab);
                    newBot.transform.parent = transform;
                    newBot.name = $"Bot-{bot.PlayerName}-{bot.Name}";
                    var botController = newBot.GetComponent<BotController>();
                    botController.SetBot(bot);
                    botController.SetArenaController(_arenaController);
                    botController.InstantRefresh();
                    _bots.Add(bot.Id, botController);
                }
                else
                {
                    var botController = _bots[bot.Id];
                    botController.UpdateBot(bot);
                }
            }
        }

        private void CleanKilledBots(List<Bot> bots)
        {
            var botIdsToClean = new List<Guid>();
            foreach (var botId in _bots.Keys)
            {
                if (bots.All(b => b.Id != botId))
                {
                    botIdsToClean.Add(botId);
                }
            }

            foreach (var botId in botIdsToClean)
            {
                var botController = _bots[botId];
                _bots.Remove(botId);
                botController.Destroy();
            }
        }
    }
}