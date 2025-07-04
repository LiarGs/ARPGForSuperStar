/* UI管理器 By ashenguo
   2025/7/4
*/

using System.Collections.Generic;
using GameCore.Code.BaseClass;
using GameCore.Code.Log;
using UnityEngine;

namespace GameCore.Code.Globals.Managers
{
    public class UIManager : MonoBehaviour
    {
        public void Init()
        {
            SuperDebug.Log("UIManager Init");
            LoadPage("Prefabs/UI/GameStartPage");
        }

        public void LoadPage(string prefabPath)
        {
            var go = Resources.Load<GameObject>(prefabPath);

            if (go != null)
            {
                var instance = Instantiate(go, transform.position, Quaternion.identity);
                instance.transform.SetParent(_Page.transform);
            }
            else
            {
                SuperDebug.LogError($"Prefab not found in {prefabPath}");
            }

            _UIControllers.Add(go.GetComponentInChildren<UIControllerBase>());
        }

        public void ClearAll()
        {
            ClearBelowPage();
            ClearPage();
            ClearAbovePage();
            ClearDialog();
            ClearAboveDialog();
        }

        public void ClearBelowPage()
        {
            _ClearChild(_BelowPage);
        }
        
        public void ClearPage()
        {
           _ClearChild(_Page);
        }

        public void ClearAbovePage()
        {
            _ClearChild(_AbovePage);
        }

        public void ClearDialog()
        {
            _ClearChild(_Dialog);
        }

        public void ClearAboveDialog()
        {
            _ClearChild(_AboveDialog);
        }

        private void _ClearChild(GameObject go)
        {
            var allChildren = go.GetComponentsInChildren<Transform>();
            foreach (var child in allChildren)
            {
                if (child != go.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            _BelowPage = transform.Find("BelowPage").gameObject;
            _Page = transform.Find("Page").gameObject;
            _AbovePage = transform.Find("AbovePage").gameObject;
            _Dialog = transform.Find("Dialog").gameObject;
            _AboveDialog = transform.Find("AboveDialog").gameObject;
        }

        public static UIManager Instance;

        private List<UIControllerBase> _UIControllers = new List<UIControllerBase>();
        private GameObject _BelowPage;
        private GameObject _Page;
        private GameObject _AbovePage;
        private GameObject _Dialog;
        private GameObject _AboveDialog;
    }
}