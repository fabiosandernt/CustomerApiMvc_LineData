using System.Text.RegularExpressions;

namespace CadastroCliente.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; set; }
        private string NormalizedStreet => Street?.Trim().Trim().ToUpper();

        public string City { get; set; }
        private string NormalizedCity => City?.Trim().ToUpper();

        public string State { get; set; }
        private string NormalizedState => State?.Trim().ToUpper();

        public override string ToString()
        {
            var value = new[]
            {
                Street,
                !string.IsNullOrWhiteSpace(City) && !string.IsNullOrWhiteSpace(State) ? $"{City}-{State}" :
                !string.IsNullOrWhiteSpace(City) ? City : ""
            };

            return string.Join(", ", value.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (!string.IsNullOrWhiteSpace(NormalizedState)
                    ? NormalizedStreet.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (!string.IsNullOrWhiteSpace(NormalizedCity)
                    ? NormalizedCity.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (!string.IsNullOrWhiteSpace(NormalizedState)
                    ? NormalizedState.GetHashCode()
                    : 0);
                return hashCode;
            }
        }
    }
}
