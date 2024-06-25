using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class Counter: ComponentBase 
    {
        private int currentCount = 0;
        private int currentCount_2 = 0;
        bool rememberMe;


        private void IncrementCount(int value)
        {
            value++;
        }
        void OnRememberMeChanged(bool value)
        {
            rememberMe = value;
        }

    }
}
