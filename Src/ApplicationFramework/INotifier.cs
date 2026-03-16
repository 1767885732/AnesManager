using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationFramework
{
    public interface INotifier
    {
        void Notify(bool isForce);
    }

    public interface IView : INotifier
    {
        bool IsFirstLoading { get; set; }
    }
}
