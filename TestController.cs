using Microsoft.AspNetCore.Mvc;

namespace TptInheritanceTest;

[Route("[controller]")]
[ApiController]
public class TestController
{
    [HttpGet]
    public ActionResult<string> GetResults()
    {
        var db = new TestContext();
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        var derived = new Derived()
        {
            Id = -100,
            Name = "name",
            AnotherName = "anothername"
        };

        db.Deriveds.Add(derived);
        db.SaveChanges();

        return "Ok";
    }
}