using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Infrastructure.Domain
{
    public abstract class ValueObjectBase
    {
        private readonly List<ValidationRule> _brokenRules = new List<ValidationRule>();

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();
            if (_brokenRules.Any())
            {
                var issues = new StringBuilder();
                foreach (ValidationRule businessRule in _brokenRules)
                    issues.AppendLine(businessRule.Rule);

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        protected void AddBrokenRule(ValidationRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}
