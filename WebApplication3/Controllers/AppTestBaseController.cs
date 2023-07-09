using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;

namespace PrimeiraApi.Controllers
{
    public class AppTestBaseController : ControllerBase
    {
        public SistemaTarefasDBContext TarefasDbContext { get; }

        public AppTestBaseController()
        {
            TarefasDbContext = new SistemaTarefasDBContext(new DbContextOptions<SistemaTarefasDBContext>());
        }


    }
}
