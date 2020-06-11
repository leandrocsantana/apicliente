using APICliente.Context;
using APICliente.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIClientexUnitTests
{
    class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        {
        }

        public void Seed(AppDbContext context)
        {
            context.Clientes.Add(new Cliente { ClienteId = 1, Cpf = "111.222.333.444-55", DataNascimento = Convert.ToDateTime("1981-01-01"), Nome = "Alan"  });
            context.Clientes.Add(new Cliente { ClienteId = 2, Cpf = "222.333.444.555-66", DataNascimento = Convert.ToDateTime("1982-02-02"), Nome = "Bruna"  });
            context.Clientes.Add(new Cliente { ClienteId = 3, Cpf = "333.444.555.666-77", DataNascimento = Convert.ToDateTime("1983-03-03"), Nome = "Celia"  });
            context.Clientes.Add(new Cliente { ClienteId = 4, Cpf = "444.555.666.777-88", DataNascimento = Convert.ToDateTime("1984-04-04"), Nome = "Daniele"  });
            context.Clientes.Add(new Cliente { ClienteId = 5, Cpf = "555.666.777.888-99", DataNascimento = Convert.ToDateTime("1985-05-05"), Nome = "Elias"  });

            context.SaveChanges();
        }
    }
}
