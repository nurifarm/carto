using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
	private static PopupManager _instance;
	public static PopupManager Instance
	{
		get
		{
			if(_instance == null)
			{
				// TODO: 게임 오브젝트와 매니저 분리
				var go = new GameObject("PopupRoot");
				_instance = go.AddComponent<PopupManager>();
			}

			return _instance;
		}
	}

	Dictionary<string, PopupBase> popups = new Dictionary<string, PopupBase>();

	Stack<PopupBase> openPopups = new Stack<PopupBase>();

    public void Show(string popupName, object param = null)
	{
		if(popups.ContainsKey(popupName) == false)
		{
			var popup = Resources.Load<PopupBase>(popupName);

			popups.Add(popupName, Instantiate(popup));
		}

		openPopups.Push(popups[popupName]);
		popups[popupName].gameObject.SetActive(true);
		popups[popupName].Show(param);
	}

	public void Hide()
	{
		var currentPopup = openPopups.Peek();
		currentPopup.Hide();
		currentPopup.gameObject.SetActive(false);
		openPopups.Pop();
	}

	public bool IsActive(string popupName)
	{
		if (popups.ContainsKey(popupName) == false) return false;

		return openPopups.Contains(popups[popupName]);
	}
}
