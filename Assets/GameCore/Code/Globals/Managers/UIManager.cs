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
        public void LoadPage(string prefabPath)
        {
            var go = Resources.Load<GameObject>(prefabPath);

            if (go != null)
            {
                var instance = Instantiate(go, transform.position, Quaternion.identity);
                instance.transform.SetParent(Page.transform);
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
            _ClearChild(BelowPage);
        }
        
        public void ClearPage()
        {
           _ClearChild(Page);
        }

        public void ClearAbovePage()
        {
            _ClearChild(AbovePage);
        }

        public void ClearDialog()
        {
            _ClearChild(Dialog);
        }

        public void ClearAboveDialog()
        {
            _ClearChild(AboveDialog);
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

        #region UnityBehavior

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

        public void OnEnable()
        {
            SuperDebug.Log("UIManager Enable");
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (BelowPage == null)
            {
                BelowPage = transform.Find("BelowPage").gameObject;
            }

            if (Page == null)
            {
                Page = transform.Find("BelowPage").gameObject;
            }

            if (AbovePage == null)
            {
                AbovePage = transform.Find("AbovePage").gameObject;
            }

            if (Dialog == null)
            {
                Dialog = transform.Find("Dialog").gameObject;
            }

            if (AboveDialog == null)
            {
                AboveDialog = transform.Find("AboveDialog").gameObject;
            }
        }

        #endregion UnityBehavior
  

        public static UIManager Instance;

        private List<UIControllerBase> _UIControllers = new List<UIControllerBase>();
        public GameObject BelowPage;
        public GameObject Page;
        public GameObject AbovePage;
        public GameObject Dialog;
        public GameObject AboveDialog;
    }
}