using System;
using System.Timers;

namespace BlazorShop.Services
{
    public class ToastService : IDisposable
    {
        // 1. Event to update the UI
        public event Action? OnShow;
        public event Action? OnHide;

        // 2. Properties of the current toast
        public string Message { get; private set; } = "";
        public string Type { get; private set; } = "success"; // success, error, info
        public bool IsVisible { get; private set; }

        private System.Timers.Timer? _countdown;

        public void ShowToast(string message, string type = "success")
        {
            Message = message;
            Type = type;
            IsVisible = true;
            OnShow?.Invoke();
            
            // Start a 3-second timer to auto-hide
            StartTimer();
        }

        private void StartTimer()
        {
            _countdown?.Stop();
            _countdown?.Dispose();

            _countdown = new System.Timers.Timer(3000); // 3 seconds
            _countdown.Elapsed += HideToast;
            _countdown.AutoReset = false;
            _countdown.Start();
        }

        private void HideToast(object? source, ElapsedEventArgs e)
        {
            IsVisible = false;
            OnHide?.Invoke();
        }

        public void Dispose()
        {
            _countdown?.Dispose();
        }
    }
}