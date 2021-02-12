using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Model.Tests
{
    public class ModelTests
    {
        /// <summary>
        /// Checks the data annotations of Models to make sure they aren't being violated
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private IList<ValidationResult> ValidateModel(object model)
        {
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, result, true);
            // if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            return result;
        }

        /// <summary>
        /// Makes sure LeagueArticle Model works with valid data
        /// </summary>
        [Fact]
        public void ValidateLeagueArticle()
        {
            var picture = new Picture
            {
                PictureID = Guid.NewGuid(),
                SubmitterID = "tom",
                ImageString = "basketball",
                ImageArray = new byte[1],
                IsPrimary = true,
                IsVisible = true,
                Rating = 3
            };

            var results = ValidateModel(picture);
            Assert.True(results.Count == 0);
        }
    }
}
