using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LoadLevelButton : ButtonBase
    {
        [SerializeField] private int levelNumber;
        [SerializeField] private Image blocker;
        private MainMenuManager manager;

        protected override void Awake()
        {
            base.Awake();
            manager = FindAnyObjectByType<MainMenuManager>();
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            SaveManager.OnLevelsDataChangedEvent += CheckLevel;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            SaveManager.OnLevelsDataChangedEvent -= CheckLevel;
        }
        protected override void OnButtonClick()
        {
            manager.LoadLevel(levelNumber);
        }
        private void CheckLevel(List<int> levels)
        {
            if (levels.Any(l => l == levelNumber))
                UnblockButton();
            else
                BlockButton();
        }
        private void BlockButton()
        {
            button.enabled = false;
            blocker.enabled = true;
        }
        private void UnblockButton()
        {
            button.enabled = true;
            blocker.enabled = false;
        }
    }
}