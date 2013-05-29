using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using Rs.Dnevnik.Ris.Core.Annotations;
using System.Linq;

namespace Rs.Dnevnik.Ris.Core.Model
{
    public class Entity : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> fErrors = new Dictionary<string, List<string>>(); 

        private readonly StringBuilder fStringBuilder = new StringBuilder();

        private readonly List<ValidationResult> fValidationResults = new List<ValidationResult>();
        

        public Entity()
        {
            Validate();
        }

        public int ID { get; set; }

        public bool JeNovi { get { return ID == 0; } }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            Validate();
        }

        protected void Validate()
        {
            fErrors.Clear();
            fValidationResults.Clear();
            Validator.TryValidateObject(this, new ValidationContext(this, null, null), fValidationResults, true);
            foreach (var validationResult in fValidationResults)
            {
                foreach (var property in validationResult.MemberNames)
                {
                    if (!fErrors.ContainsKey(property))
                    {
                        fErrors.Add(property, new List<string>());
                    }
                    fErrors[property].Add(validationResult.ErrorMessage);
                }
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (fErrors.ContainsKey(columnName))
                {
                    fStringBuilder.Clear();
                    List<string> errors = fErrors[columnName];
                    foreach (var error in errors)
                    {
                        fStringBuilder.AppendLine(error);
                    }
                    return fStringBuilder.ToString();
                }
                return null;
            }
        }

        public string Error { get { return fErrors.Any() ? "Entitet nije validan" : null; } }

        public string GetAllErrors()
        {
            var sb = new StringBuilder();
            foreach (var error in fErrors.Values.SelectMany(x => x))
            {
                sb.AppendLine(error);
            }
            return sb.ToString();
        }

        public bool IsValid
        {
            get { return Error == null; }
        }

        protected bool Equals(Entity other)
        {
            return ID == other.ID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}