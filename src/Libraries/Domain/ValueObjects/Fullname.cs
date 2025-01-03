﻿namespace ContractorDocuments.Domain.ValueObjects
{
    public class Fullname : ValueObject
    {
        #region Ctor

        public Fullname()
        {

        }
        public Fullname(string? name, string? surname)
        {
            if (name != null)
            {
                if (name.Length > 50)
                    throw new ArgumentOutOfRangeException("name can not be more than 50 characters");
                Name = name.Trim();
            }

            if (surname != null)
            {
                if (surname.Length > 50)
                    throw new ArgumentOutOfRangeException("surname can not be more than 50 characters");
                Surname = surname.Trim();
            }
        }

        #endregion

        public string? Name { get; private set; } = null;
        public string? Surname { get; private set; } = null;

        public string? GetName() => Name;
        public string? GetSurname() => Surname;
        public string GetFullName()
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Surname))
                return string.Empty;
            if (string.IsNullOrEmpty(Name))
                return Surname!;
            if (string.IsNullOrEmpty(Surname))
                return Name;
            return $"{Name} {Surname}";
        }
        public void SetFullName(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        #region Overrides

        public static bool operator ==(Fullname left, Fullname right)
        {
            if (left is null || right is null)
            {
                if (left is null)
                {
                    return right is null;
                }

                return left.Equals(right);
            }

            return $"{left.Name}{left.Surname}" == $"{right.Name}{right.Surname}";
        }

        public static bool operator !=(Fullname left, Fullname right)
            => $"{left.Name}{left.Surname}" != $"{right.Name}{right.Surname}";

        protected override IEnumerable<object> GetEqualityComponents()
        {
            if (string.IsNullOrEmpty(Name))
                yield return string.Empty;
            else
                yield return Name;

            if (string.IsNullOrEmpty(Surname))
                yield return string.Empty;
            else
                yield return Surname;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return (Fullname)obj == this;
        }

        public override int GetHashCode() => this!.GetHashCode();

        #endregion
    }
}
