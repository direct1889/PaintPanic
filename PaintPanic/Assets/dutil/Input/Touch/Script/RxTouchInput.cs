﻿using UnityEngine;
using UniRx;
using System;
using System.Collections.Generic;

namespace du.di {


	public static class DragInfoManager {

		#region field

		static int a;

		#endregion


		#region public

		public static void Update() {

		}

		public static void StartNewDrag(string name, Vector3 enterPos) {

		}

		#endregion

	}

	public class PreDragInfo {

		#region field

		public Vector3 Enter { get; }
		private readonly float timer;
		public Vector3 Previous { private set; get; }
		public Vector3 Current { private set; get; }

		#endregion


		#region public

		public void FixedUpdate() {

		}

		#endregion

	}

	public struct DragInfo {

		#region field

		public Vector3 Enter { get; }
		public Vector3 Exit { get; }
		public float Duration { get; }

		#endregion


		#region property

		public Vector3 Vector { get { return Exit - Enter; } }
		public Vector3 Velocity { get { return Vector / Duration; } }

		#endregion


		#region ctor/dtor

		public DragInfo(Vector3 enterPos, Vector3 exitPos, float duration) {
			Enter = enterPos;
			Exit = exitPos;
			Duration = duration;
		}

		#endregion

	}


	public static class RxTouchInput {

		#region field

		static ISubject<Vector3> s_onTouchEnter = new Subject<Vector3>();
		static ISubject<Vector3> s_onTouchExit = new Subject<Vector3>();

		static Vector3 s_dragged = Vector3.zero;

		#endregion


		#region public

		public static void Initialize() {
			Mgr.App.RegisterFixedUpdatedAction(FixedUpdate);
		}

		public static IObservable<Vector3> OnTouchEnter() {
			return s_onTouchEnter;
		}
		public static IObservable<Vector3> OnTouchExit() {
			return s_onTouchExit;
		}

		#endregion


		#region private

		private static void FixedUpdate() {
			switch (Touch.GetTouch(0)) {
				case TouchInfo.None: break;
				case TouchInfo.Began: {
						s_onTouchEnter.OnNext(Touch.LastTouchedPosition);
					}
					break;
				case TouchInfo.Moved: break;
				case TouchInfo.Stationary: break;
				case TouchInfo.Ended: {
						s_onTouchExit.OnNext(Touch.LastTouchedPosition);
					}
					break;
				case TouchInfo.Canceled: break;
			}
		}

		#endregion


	}

}
