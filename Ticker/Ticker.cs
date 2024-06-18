using System;
using ITools.StarterPack.CoreLogic.Tools.Ticker.Interfaces;
using System.Collections.Generic;

namespace Tools.Ticker
{
    /// <summary>
    /// The Ticker class is a singleton MonoBehaviour in Unity that provides a centralized way to manage and invoke update events.
    /// </summary>
    public class Ticker : MonoBehaviour
    { 
        private event Action OnUpdate;
        private event Action OnLateUpdate;
        private event Action OnFixedUpdate;

        private static Ticker _instance;
        
        private void Awake() =>
            _instance = this;

        /// <summary>
        /// Registers an IUpdateable object to the OnUpdate event.
        /// </summary>
        /// <param name="updateable">The IUpdateable object to register.</param>
        public static void RegisterUpdateable(IUpdateable updateable)
        {
            _instance.OnUpdate -= updateable.OnUpdate;
            _instance.OnUpdate += updateable.OnUpdate;
        }

        /// <summary>
        /// Registers an ILateUpdateable object to the OnLateUpdate event.
        /// </summary>
        /// <param name="lateUpdateable">The ILateUpdateable object to register.</param>
        public static void RegisterLateUpdateable(ILateUpdateable lateUpdateable)
        {
            _instance.OnLateUpdate -= lateUpdateable.OnLateUpdate;
            _instance.OnLateUpdate += lateUpdateable.OnLateUpdate;
        }

        /// <summary>
        /// Registers an IFixedUpdateable object to the OnFixedUpdate event.
        /// </summary>
        /// <param name="fixedUpdateable">The IFixedUpdateable object to register.</param>
        public static void RegisterFixedUpdateable(IFixedUpdateable fixedUpdateable)
        {
            _instance.OnLateUpdate -= fixedUpdateable.OnFixedUpdate;
            _instance.OnFixedUpdate += fixedUpdateable.OnFixedUpdate;
        }

        
        /// <summary>
        /// Unregisters an IUpdateable object from the OnUpdate event.
        /// </summary>
        /// <param name="updateable">The IUpdateable object to unregister.</param>
        public static void UnregisterUpdateable(IUpdateable updateable) =>
            _instance.OnUpdate -= updateable.OnUpdate;

        /// <summary>
        /// Unregisters an ILateUpdateable object from the OnLateUpdate event.
        /// </summary>
        /// <param name="lateUpdateable">The ILateUpdateable object to unregister.</param>
        public static void UnregisterLateUpdateable(ILateUpdateable lateUpdateable) =>
            _instance.OnLateUpdate -= lateUpdateable.OnLateUpdate;

        /// <summary>
        /// Unregisters an IFixedUpdateable object from the OnFixedUpdate event.
        /// </summary>
        /// <param name="fixedUpdateable">The IFixedUpdateable object to unregister.</param>
        public static void UnregisterFixedUpdateable(IFixedUpdateable fixedUpdateable) =>
            _instance.OnFixedUpdate -= fixedUpdateable.OnFixedUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
    }
}