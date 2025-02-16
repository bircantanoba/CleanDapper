﻿using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using FluentValidation;
using System.Drawing;

namespace DapperORM.Application.Validations.Common
{
    public static class ProductRules
    {
        public static IRuleBuilderOptions<T, string> CheckProductName<T>(this IRuleBuilder<T, string> ruleBuilder) where T: Product
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Product_Name_Length_Error)
                .MinimumLength(3).WithMessage(ValidationMessages.Product_Name_Length_Error)
                .MaximumLength(70).WithMessage(ValidationMessages.Product_Name_Length_Error);

        }

        public static IRuleBuilderOptions<T, string> CheckProductColor<T>(this IRuleBuilder<T, string> ruleBuilder) where T : Product
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Product_Color_Must_be_Known_Color)
                .IsEnumName(typeof(KnownColor)).WithMessage(ValidationMessages.Product_Color_Must_be_Known_Color);
        }

        public static IRuleBuilderOptions<T, int> CheckProductQuantity<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Product
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Product_Quantity_Must_Greater_Than_Zero)
                .GreaterThan(0).WithMessage(ValidationMessages.Product_Quantity_Must_Greater_Than_Zero);
        }

        public static IRuleBuilderOptions<T, int> CheckProductPrice<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Product
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Product_Price_Must_Greater_Than_Or_Equal_To_Zero)
                .GreaterThan(0).WithMessage(ValidationMessages.Product_Price_Must_Greater_Than_Or_Equal_To_Zero);
        }

        public static IRuleBuilderOptions<T, int> CheckProductStock<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Product
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Product_Stock_Must_Greater_Than_Zero)
                .GreaterThan(0).WithMessage(ValidationMessages.Product_Stock_Must_Greater_Than_Zero);
        }

        public static IRuleBuilderOptions<T, int> CheckProductCategoryId<T>(this IRuleBuilder<T, int> ruleBuilder) where T : Product
        {
            return ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.Product_Category_Id_Cannot_Be_Empty)
                .GreaterThan(0).WithMessage(ValidationMessages.Product_Category_Id_Cannot_Be_Empty);

        }
    }
}
