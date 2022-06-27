using System;
using System.Collections.Generic;
using Zenject;

namespace UISystem
{
    public class UiAttachSystem : IInitializable
    {
        private readonly ICanvasContainer _canvasContainer;
        private readonly List<IAttachableUi> _attachables;

        public UiAttachSystem(ICanvasContainer canvasContainer, List<IAttachableUi> attachables)
        {
            _canvasContainer = canvasContainer;
            _attachables = attachables;
        }
        
        public void Initialize()
        {
            foreach (var item in _attachables)
            {
                _canvasContainer.Attach(item);
            }
        }
    }
}