using System;
using Assets.Scripts.Model;
using Assets.Scripts.Networking;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ArenaController : MonoBehaviour
    {
        private Arena _arena;
        private GameObject _floor;

        public Single GridToWorldScale = 1;
        public Single PlatformHeight = 1;

        void Start()
        {
            _arena = ApiClient.GetArena();
            _floor = GameObject.Find("Floor");
            _floor.transform.localScale = new Vector3(_arena.Width, PlatformHeight, _arena.Height);
            _floor.GetComponent<Renderer>().material.mainTextureScale = new Vector2(_arena.Width, _arena.Height);
        }

        public Vector3 ArenaToWorldPosition(int x, int y)
        {
            if (_arena != null)
            {
                return new Vector3(
                    (x + GridToWorldScale / 2 - (float)_arena.Width / 2 + _floor.transform.position.x) * GridToWorldScale,
                    PlatformHeight / 2 * GridToWorldScale,
                    (_arena.Height - y - GridToWorldScale / 2 - (float)_arena.Height / 2 + _floor.transform.position.z) * GridToWorldScale);
            }

            return Vector3.zero;
        }
    }
}