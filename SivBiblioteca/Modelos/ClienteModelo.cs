using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SivBiblioteca.Modelos
{
    public class ClienteModelo
    {
        string nombre;
        string apellido;
        public int Id { get; set; }
        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del cliente no debe estar en blanco o ser null.");
                }
                nombre = value.Trim();
            }
        }
        public string Apellido
        {
            get => apellido;
            set => apellido = value?.Trim();
        }

        public string NombreCompleto => $"{Nombre} {Apellido}";
        public string NumeroContacto { get; set; }    
    }
}
