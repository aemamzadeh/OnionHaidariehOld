using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace _0_Framework.Application
{
    public class ValidateDropdownAttribute : ValidationAttribute,IClientModelValidator
    {
        private readonly SelectList _validateDropdown;
        public ValidateDropdownAttribute(SelectList validateDropdown)
        {
            _validateDropdown = validateDropdown;
        }

        public override bool IsValid(object value)
        {
            //var selectList = value as SelectList;
            if (_validateDropdown.SelectedValue == null) return false;
            return true;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-validateDropdown", ErrorMessage);
        }
    }
}
