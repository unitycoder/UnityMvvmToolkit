﻿using UnityEngine.UIElements;

namespace BindableUIElements
{
    public partial class BindableTaskScrollView
    {
        public string BindingItemsSourcePath { get; private set; }
        public string BindingItemTemplatePath { get; private set; }

        public new class UxmlFactory : UxmlFactory<BindableTaskScrollView, UxmlTraits>
        {
        }

        public new class UxmlTraits : ScrollView.UxmlTraits
        {
            private readonly UxmlStringAttributeDescription _bindingItemsSourceAttribute = new()
                { name = "binding-items-source-path", defaultValue = "" };

            private readonly UxmlStringAttributeDescription _bindingItemTemplateAttribute = new()
                { name = "binding-item-template-path", defaultValue = "" };

            public override void Init(VisualElement visualElement, IUxmlAttributes bag, CreationContext context)
            {
                base.Init(visualElement, bag, context);

                var bindableScrollView = (BindableTaskScrollView) visualElement;
                bindableScrollView.BindingItemsSourcePath = _bindingItemsSourceAttribute.GetValueFromBag(bag, context);
                bindableScrollView.BindingItemTemplatePath = _bindingItemTemplateAttribute.GetValueFromBag(bag, context);
            }
        }
    }
}