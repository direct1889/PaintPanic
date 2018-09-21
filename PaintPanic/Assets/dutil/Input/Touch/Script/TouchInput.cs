﻿using UnityEngine;
using UTouch = UnityEngine.Touch;


namespace du.di {

	public static class Touch {
		private static Vector3 TouchPosition = Vector3.zero;
		private static Vector3 PreviousPosition = Vector3.zero;

		public static int touchCount {
			get {
				if (Application.isEditor) {
					if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
						return 1;
					}
					else {
						return 0;
					}
				}
				else {
					return Input.touchCount;
				}
			}
		}

		/// <summary>
		/// タッチ情報を取得(エディタと実機を考慮)
		/// </summary>
		/// <returns>タッチ情報。タッチされていない場合は null</returns>
		public static TouchInfo GetTouch(int i) {
			if (Application.isEditor) {
				if (Input.GetMouseButtonDown(0)) { return TouchInfo.Began; }
				if (Input.GetMouseButton	(0)) { return TouchInfo.Moved; }
				if (Input.GetMouseButtonUp	(0)) { return TouchInfo.Ended; }
			}
			else {
				if (Input.touchCount >= i) {
					return (TouchInfo)((int)Input.GetTouch(i).phase);
				}
			}
			return TouchInfo.None;
		}

		/// <summary>
		/// タッチポジションを取得(エディタと実機を考慮)
		/// </summary>
		/// <returns>タッチポジション。タッチされていない場合は (0, 0, 0)</returns>
		public static Vector3 GetTouchPosition(int i) {
			if (Application.isEditor) {
				TouchInfo touch = GetTouch(i);
				if (touch != TouchInfo.None) {
					PreviousPosition = Input.mousePosition;
					return PreviousPosition;
				}
			}
			else {
				if (Input.touchCount >= i) {
					UTouch touch = Input.GetTouch(i);
					TouchPosition.x = touch.position.x;
					TouchPosition.y = touch.position.y;
					return TouchPosition;
				}
			}
			return Vector3.zero;
		}

		public static Vector3 GetDeltaPosition(int i) {
			if (Application.isEditor) {
				TouchInfo info = GetTouch(i);
				if (info != TouchInfo.None) {
					Vector3 currentPosition = Input.mousePosition;
					Vector3 delta = currentPosition - PreviousPosition;
					PreviousPosition = currentPosition;
					return delta;
				}
			}
			else {
				if (Input.touchCount >= i) {
					UTouch touch = Input.GetTouch(i);
					PreviousPosition.x = touch.deltaPosition.x;
					PreviousPosition.y = touch.deltaPosition.y;
					return PreviousPosition;
				}
			}
			return Vector3.zero;
		}

		public static int GetFingerId(int i) {
			if (Application.isEditor) {
				if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
					return 1;
				}
				else {
					return 0;
				}
			}
			else {
				return Input.GetTouch(i).fingerId;
			}
		}

		/// <summary>
		/// タッチワールドポジションを取得(エディタと実機を考慮)
		/// </summary>
		/// <param name='camera'>カメラ</param>
		/// <returns>タッチワールドポジション。タッチされていない場合は (0, 0, 0)</returns>
		public static Vector3 GetTouchWorldPosition(Camera camera, int i) {
			return camera.ScreenToWorldPoint(GetTouchPosition(i));
		}


		public static bool IsTouch { get { return GetTouch(0) != TouchInfo.None; }}

	}

	/// <summary>
	/// タッチ情報。UnityEngine.TouchPhase に None の情報を追加拡張。
	/// </summary>
	public enum TouchInfo {
		/// <summary>
		/// タッチなし
		/// </summary>
		None = -1,

		// 以下は UnityEngine.TouchPhase の値に対応
		/// <summary>
		/// タッチ開始
		/// </summary>
		Began = 0,
		/// <summary>
		/// タッチ移動
		/// </summary>
		Moved = 1,
		/// <summary>
		/// タッチ静止
		/// </summary>
		Stationary = 2,
		/// <summary>
		/// タッチ終了
		/// </summary>
		Ended = 3,
		/// <summary>
		/// タッチキャンセル
		/// </summary>
		Canceled = 4,
	}
}
