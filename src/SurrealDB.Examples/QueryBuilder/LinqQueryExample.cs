using System.Text;
using SurrealDB.QueryBuilder;
using SurrealDB.QueryBuilder.Enums;
using SurrealDB.QueryBuilder.Functions;

namespace SurrealDB.Examples.QueryBuilder;

using static BinaryOperators;
using static CountFunctions;
using static MathFunctions;

public class LinqQueryExample : IExample
{
	public string Name => "Linq query";

	public string Description => "Demonstrates how to use the Linq query builder to build queries.";

	public async Task RunAsync(CancellationToken cancellationToken = default)
	{
		Console.OutputEncoding = Encoding.UTF8;

		// SELECT age, name, email FROM user;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  user.Age,
			                  user.Name,
			                  user.Email
		                  })
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT age >= 18 AS adult FROM user;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  Adult = user.Age >= 18
		                  })
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT *, tags.*.value AS tags FROM article;
		Console.WriteLine(SurrealQL
		                  .Select<Article>(article => new
		                  {
			                  article,
			                  Tags = article.Tags.Select(tag => tag.Value)
		                  })
		                  .ExecuteAsync<Article>());

		Console.WriteLine();

		//  SELECT addresses[WHERE active = true] FROM customer;
		Console.WriteLine(SurrealQL
		                  .Select<Customer>(customer => new
		                  {
			                  Addresses = customer.Addresses.Where(address => address.Active)
		                  })
		                  .ExecuteAsync<Customer>());

		Console.WriteLine();

		// SELECT ( ( celsius * 2 ) + 30 ) AS fahrenheit FROM temperature;
		Console.WriteLine(SurrealQL
		                  .Select<Temperature>(temperature => new
		                  {
			                  Fahrenheit = temperature.Celsius * 2 + 30
		                  })
		                  .ExecuteAsync<Temperature>());

		Console.WriteLine();

		// SELECT { weekly: false, monthly: true } AS `marketing settings` FROM user;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  MarketingSettings = new
			                  {
				                  Weekly = false,
				                  Monthly = true
			                  }
		                  })
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT * FROM user, admin;
		Console.WriteLine(SurrealQL
		                  .Select<User>(userAndAdmin => new
		                  {
			                  userAndAdmin
		                  })
		                  .From(nameof(User), nameof(Admin))
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT * FROM article, post WHERE name CONTAINS 'SurrealDB';
		Console.WriteLine(SurrealQL
		                  .Select<Article>(articleAndPost => new
		                  {
			                  articleAndPost
		                  })
		                  .From(nameof(Article), nameof(Post))
		                  .Where(articleOrPost => Contains(articleOrPost.Name, "SurrealDB"))
		                  .ExecuteAsync<Article>());

		Console.WriteLine();

		// SELECT * FROM article WHERE published = true;
		Console.WriteLine(SurrealQL
		                  .Select<Article>(article => new
		                  {
			                  article
		                  })
		                  .Where(article => article.Published)
		                  .ExecuteAsync<Article>());

		Console.WriteLine();

		// SELECT * FROM user WHERE(admin AND active) OR owner = true;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  user
		                  })
		                  .Where(user => (user.Admin && user.Active) || user.Owner)
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT * FROM user SPLIT emails;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  user
		                  })
		                  .SplitAt(user => user.Emails)
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT * FROM country SPLIT locations.cities;
		Console.WriteLine(SurrealQL
		                  .Select<Country>(country => new
		                  {
			                  country
		                  })
		                  .SplitAt(country => country.Locations.Select(location => location.Cities))
		                  .ExecuteAsync<Country>());

		Console.WriteLine();

		// SELECT country FROM user GROUP BY country;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  user.Country
		                  })
		                  .GroupBy(user => user.Country!)
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT settings.published FROM article GROUP BY settings.published;
		Console.WriteLine(SurrealQL
		                  .Select<Article>(article => new
		                  {
			                  Published = article.Settings.Select(settings => settings.Published)
		                  })
		                  .GroupBy(article => article.Settings.Select(settings => settings.Published))
		                  .ExecuteAsync<Article>());

		Console.WriteLine();

		// SELECT gender, country, city FROM person GROUP BY gender, country, city;
		Console.WriteLine(SurrealQL
		                  .Select<Person>(person => new
		                  {
			                  person.Gender,
			                  person.Country,
			                  person.City
		                  })
		                  .GroupBy(person => person.Gender!, person => person.Country!, person => person.City!)
		                  .ExecuteAsync<Person>());

		Console.WriteLine();

		// SELECT count() AS total, math::sum(age), gender, country FROM person
		Console.WriteLine(SurrealQL
		                  .Select<Person>(person => new
		                  {
			                  Total = Count(), // using static
			                  Sum = Sum(person.Age), // using static
			                  person.Gender,
			                  person.Country
		                  })
		                  .ExecuteAsync<Person>());

		Console.WriteLine();

		// SELECT * FROM user ORDER BY RAND();
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  user
		                  })
		                  .OrderByRand()
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT * FROM song ORDER BY rating DESC;
		Console.WriteLine(SurrealQL
		                  .Select<Song>(song => new
		                  {
			                  song
		                  })
		                  .OrderBy(song => song.Rating, SortOrder.Desc)
		                  .ExecuteAsync<Song>());

		Console.WriteLine();

		// SELECT * FROM song ORDER By artist ASC, rating DESC;
		Console.WriteLine(SurrealQL
		                  .Select<Song>(song => new
		                  {
			                  song
		                  })
		                  .OrderBy(song => song.Artist!)
		                  .OrderBy(song => song.Rating, SortOrder.Desc)
		                  .ExecuteAsync<Song>());

		Console.WriteLine();

		// SELECT * FROM article ORDER BY title COLLATE ASC;
		Console.WriteLine(SurrealQL
		                  .Select<Article>(article => new
		                  {
			                  article
		                  })
		                  .OrderBy(article => article.Title!, textSortMethod: TextSortMethod.Collate)
		                  .ExecuteAsync<Article>());

		Console.WriteLine();

		// SELECT * FROM article ORDER BY title NUMERIC ASC;
		Console.WriteLine(SurrealQL
		                  .Select<Article>(article => new
		                  {
			                  article
		                  })
		                  .OrderBy(article => article.Title!, textSortMethod: TextSortMethod.Numeric)
		                  .ExecuteAsync<Article>());

		Console.WriteLine();

		// SELECT * FROM user LIMIT 50 START 50;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  user
		                  })
		                  .LimitBy(50)
		                  .StartAt(50)
		                  .ExecuteAsync<User>());

		Console.WriteLine();

		// SELECT * FROM user:tobie FETCH account, account.users;
		Console.WriteLine(SurrealQL
		                  .Select<User>(user => new
		                  {
			                  user
		                  })
		                  .From("User:tobie")
		                  .Fetch(user => user.Account!, user => user.Account!.Users)
		                  .ExecuteAsync<User>());

		// CREATE person SET name = 'Tobie', company = 'SurrealDB', skills = ['Rust', 'Go', 'JavaScript'] RETURN name, skills TIMEOUT 30s;
		Console.WriteLine(SurrealQL
		                  .Create<Person>()
		                  .Set(person => new Person
		                  {
			                  Name = "Tobie",
			                  Company = "SurrealDB",
			                  Skills = new[] { "Rust", "Go", "JavaScript" }
		                  })
		                  .Return(person => new
		                  {
			                  person.Name,
			                  person.Skills
		                  })
		                  .Timeout("30s") // or new Duration(seconds: 30)
		                  .Parallel()
		                  .ExecuteAsync<Person>());

		Console.WriteLine();

		Console.WriteLine(SurrealQL
		                  .Select<Arr1>(arr1 => new
		                  {
			                  nums = arr1.Arr2.Select(arr2 => arr2.Arr3).First().Select(arr3 => arr3.Id)
		                  })
		                  .ExecuteAsync<Arr1>());

		await Task.CompletedTask;
	}
}

internal class Song
{
	public int Id { get; set; }

	public string? Name { get; set; }

	public string? Artist { get; set; }

	public string? Album { get; set; }

	public int Rating { get; set; }
}

internal class Country
{
	public string? Name { get; set; }

	public Location[] Locations { get; set; } = Array.Empty<Location>();
}

internal class Location
{
	public string? Name { get; set; }

	public string[] Cities { get; set; } = Array.Empty<string>();
}

internal class Admin
{
	public int Id { get; set; }

	public string? Name { get; set; }

	public string? Email { get; set; }

	public int Age { get; set; }
}

internal class Person
{
	public int Id { get; set; }

	public string? Name { get; set; }

	public string? Company { get; set; }

	public int Age { get; set; }

	public string? Gender { get; set; }

	public Country? Country { get; set; }

	public string[] Skills { get; set; } = Array.Empty<string>();

	public City? City { get; set; }
}

internal class Temperature
{
	public int Celsius { get; set; }
}

internal class Customer
{
	public Address[] Addresses { get; set; } = Array.Empty<Address>();
}

internal class Address
{
	public bool Active { get; set; }
}

internal class Article
{
	public string? Title { get; set; }

	public string? Name { get; set; }

	public Tag[] Tags { get; set; } = Array.Empty<Tag>();

	public bool Published { get; internal set; }

	public Setting[] Settings { get; set; } = Array.Empty<Setting>();
}

internal class Setting
{
	public bool Published { get; set; }
}

internal class Post
{
	public string? Name { get; set; }
}

internal class Tag
{
	public string? Value { get; set; }
}

internal class User
{
	public Account? Account { get; set; }

	public string? Name { get; set; }

	public int Age { get; set; }

	public string? Email { get; set; }

	public bool Admin { get; internal set; }

	public bool Active { get; internal set; }

	public bool Owner { get; internal set; }

	public string[] Emails { get; set; } = Array.Empty<string>();

	public Country? Country { get; set; }
}

internal class Account
{
	public User[] Users { get; set; } = Array.Empty<User>();
}

internal class City { }

internal class Arr1
{
	public Arr2[] Arr2 { get; set; } = Array.Empty<Arr2>();
}

internal class Arr2
{
	public Arr3[] Arr3 { get; set; } = Array.Empty<Arr3>();
}

internal class Arr3
{
	public int Id { get; set; }
}
