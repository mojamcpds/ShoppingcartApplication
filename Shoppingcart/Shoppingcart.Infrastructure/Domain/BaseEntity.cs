using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppingcart.Infrastructure.Domain
{
    public abstract class BaseEntity<TId> : IEquatable<BaseEntity<TId>>
    {
        protected BaseEntity(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the type's default value.", "id");
            }

            this.Id = id;
        }

        // EF requires an empty constructor
        protected BaseEntity()
        {
        }

        private readonly List<ValidationRule> _brokenRules = new List<ValidationRule>();

        public TId Id { get; set; }

        protected abstract void Validate();

        public IEnumerable<ValidationRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void AddBrokenRule(ValidationRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        // For simple entities, this may suffice
        // As Evans notes equality of Entities is frequently not a simple operation
        public override bool Equals(object otherObject)
        {
            var entity = otherObject as BaseEntity<TId>;
            if (entity != null)
            {
                return this.Equals(entity);
            }
            return base.Equals(otherObject);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(BaseEntity<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }
    }
}
