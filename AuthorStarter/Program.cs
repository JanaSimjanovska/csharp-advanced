using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace AuthorStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new AuthorRepo();
            var authors = repo.GetAuthors();

            #region Number of Authors and Books

            int numOfAuthors = authors.Count;
            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"Number of authors: {numOfAuthors}");

            var allBooks = authors    
                            .SelectMany(x => x.Books)
                            .Select(x => new {
                                BookTitle = x.Title,
                                BookId = x.ID
                            });

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"Total number od books: {allBooks.Count()}");

            var authorsAndBooksLight = authors
                            .Select(x => new{
                                AuthorsName = x.Name,
                                NumOfBooksWithWins = x.Books.Where(y => y.Wins > 0).Count(),
                                NumOfBooksWithNoms = x.Books.Where(y => y.Nominations > 0).Count(),
                                BookId = x.Books.Select(x => x.ID),
                                BookCount = x.Books.Count, 
                                PercentageNoms = x.Books.Where(x => x.Nominations > 0).Count() * 100 / x.Books.Count
                            });
            
            // var bookTitleIdWinsAndNoms = allBooks
            //                 .Select(x => new{
            //                     BookTitle = x.Title,
            //                     BookId = x.ID,
            //                     BookWins = x.Wins,
            //                     BookNoms = x.Nominations
            //                 });

            #endregion


            #region Task 01

            // - How many books are collaborations(have more than one author)?

            IEnumerable<IGrouping<int, int>> collabs = allBooks
                        .Select(x => x.BookId)
                        .GroupBy(x => x)
                        .Where(x => x.Count() > 1);

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"There are {collabs.Count()} books that are collaborations.");

            #endregion


            #region Task 02

            // - Which book has the most authors(and how many)?
                           
            int howManyAuthors = collabs
                            .OrderByDescending(x => x.Count())
                            .Select(x => x.Count())
                            .First();

            int idOfBookWithMostAuthors = collabs
                            .OrderByDescending(x => x.Count())
                            .Select(x => x.Key)
                            .First();
            var bookWithMostAuthors = allBooks
                            .First(x => x.BookId == idOfBookWithMostAuthors);             

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"The book with the most authors is \"{bookWithMostAuthors.BookTitle}\". It has {howManyAuthors} authors.");

            #endregion


            #region Task 04

            // - In what year were published most books in a specific genre? Which genre?

            // Ovde malku racno dojdov do rezultatot, sigurno moze da se dobie poinaku i poprakticno, ama ete vaka go smisliv, prvo da najdam od sekoj zanr kolku knigi vo koja godina ima, pa ottamu fakticki ja naogjame i godinata so najmnogu knigi vo toj zanr (neli zemame eden zanr, ja selektirame samo godinata i grupirame godina so godina, za da mozeme da izbroime koja godina se povtoruva najvekje i vo sustina koga kje go naredime kauntot po descending, ako posle gi selektirame od grupingot samo kauntite i go zememe prviot, sme go dobile brojot na knigi vo toj zanr vo godinata so najvekje od toj zanr, a ako go selektirame key (godinata) otkako sme gi naredile opagjacki po kaunt, kje ja dobieme samata godina vo koja od toj zanr ima najvekje knigi). E sega osven sto jas gi gleam broevite i mozam da vidam koj e najgolemiot broj, pa da vidam na koj zanr se odnesuva i od tamu da znam za koj zanr da ja baram soodvetnata godina, drugacie ne mi tekna kako da gi povrzam, pa ako ima pokulturno resenie, i am looking forward to it

            var booksYearAndGenre = authors
                            .SelectMany(x => x.Books)
                            .Select (x => new {
                                BookYear = x.Year,
                                BookGenres = x.Genres
                            });

            int numOfBooksInYearWithMostSciFiBooks = booksYearAndGenre     
                        .Where(x => x.BookGenres.Any(y => y == Genre.ScienceFiction))
                        .Select(x => x.BookYear)
                        .GroupBy(x => x)
                        .OrderByDescending(x => x.Count())
                        .Select(x => x.Count())
                        .First();

            int numOfBooksInYearWithMostFantasyBooks = booksYearAndGenre     
                        .Where(x => x.BookGenres.Any(y => y == Genre.Fantasy))
                        .Select(x => x.BookYear)
                        .GroupBy(x => x)
                        .OrderByDescending(x => x.Count())
                        .Select(x => x.Count())
                        .First();
            
            int numOfBooksInYearWithMostHorrorBooks = booksYearAndGenre     
                        .Where(x => x.BookGenres.Any(y => y == Genre.Horror))
                        .Select(x => x.BookYear)
                        .GroupBy(x => x)
                        .OrderByDescending(x => x.Count())
                        .Select(x => x.Count())
                        .First();

            // List<int> countsOfBooksInYearWithMostBooksPerGenre = new List<int>(){
            //     numOfBooksInYearWithMostFantasyBooks,
            //     numOfBooksInYearWithMostHorrorBooks,
            //     numOfBooksInYearWithMostSciFiBooks
            // };

            // int mostBooksInAGenreInAYear = countsOfBooksInYearWithMostBooksPerGenre.Max(); // ova cisto da vidam koj zanr ima najmnogu vo edna god, iako bese jasno od trite koa gi konzollogirav, ama mislev deka nekako kje moze preku ova da ja najdam godinata, ne uspeav, pa zatoa vaka prostacki kako podole hahaha
           
            int yearWithMostFantasyBooks = booksYearAndGenre     
                        .Where(x => x.BookGenres.Any(y => y == Genre.Fantasy))
                        .Select(x => x.BookYear)
                        .GroupBy(x => x)
                        .OrderByDescending(x => x.Count())
                        .Select(x => x.Key)
                        .ToList()
                        .First();

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            Console.WriteLine($"Most books in a specific genre were published in year {yearWithMostFantasyBooks}. In this year {                numOfBooksInYearWithMostFantasyBooks} fantasy books were published.");

            #endregion


            #region Task 05

            var authorWithMostBooksWithNominations = authorsAndBooksLight
                                            .Where(x => x.NumOfBooksWithNoms > 0)
                                            .OrderByDescending(x => x.NumOfBooksWithNoms)
                                            .FirstOrDefault();

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"The author with most books nominated for an award is {authorWithMostBooksWithNominations.AuthorsName}, with a total of {authorWithMostBooksWithNominations.NumOfBooksWithNoms} nominations.");

            #endregion

                
            #region Task 06

            var authorWithMostBooksWithAwards = authorsAndBooksLight
                                            .Where(x => x.NumOfBooksWithWins > 0)
                                            .OrderByDescending(x => x.NumOfBooksWithWins)
                                            .FirstOrDefault();

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"The author with most books that have won an award is {authorWithMostBooksWithAwards.AuthorsName}, with a total of {authorWithMostBooksWithAwards.NumOfBooksWithWins} awards.");

            #endregion
            

            #region Task 07

            var authorWithMostBookNomsNoAwards = authorsAndBooksLight
                                            .Where(x => x.NumOfBooksWithWins == 0 && x.NumOfBooksWithNoms > 0)
                                            .OrderByDescending(x => x.NumOfBooksWithNoms)
                                            .FirstOrDefault();

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"The author with most books nominated for an award, without winning a single award is {authorWithMostBookNomsNoAwards.AuthorsName}, with a total of {authorWithMostBookNomsNoAwards.NumOfBooksWithNoms} nominations and zero awarded books.");

            #endregion
            
            
            #region Task 08

            //- Make a histogram of books published per decade per genre
            
            var booksDecadeAndGenre = authors
                            .SelectMany(x => x.Books)
                            .Select (x => new {
                                BookDecade = int.Parse(x.Year.ToString().Remove(x.Year.ToString().Length -1, 1) + "0"),
                                SciFiCount = x.Genres.Where(x => x == Genre.ScienceFiction).Count(),
                                FantasyCount = x.Genres.Where(x => x == Genre.Fantasy).Count(),
                                HorrorCount = x.Genres.Where(x => x == Genre.Horror).Count()
                            }).
                            OrderBy(x => x.BookDecade);

            IEnumerable<int> sciFiByDecades = booksDecadeAndGenre     
                        .GroupBy(x => x.BookDecade)
                        .Select(x => x.Select(y => y.SciFiCount).Sum());
                        
            IEnumerable<int> fantasyByDecades = booksDecadeAndGenre     
                        .GroupBy(x => x.BookDecade)
                        .Select(x => x.Select(y => y.FantasyCount).Sum());

            IEnumerable<int> horrorByDecades = booksDecadeAndGenre     
                        .GroupBy(x => x.BookDecade)
                        .Select(x => x.Select(y => y.HorrorCount).Sum());

            IEnumerable<int> decades = booksDecadeAndGenre
                        .Select(x => x.BookDecade)
                        .Distinct();

            IEnumerable<string> results = decades.Zip(sciFiByDecades, (x, y) => $"{x} {y}").Zip(fantasyByDecades, (x, y) => $"{x} {y}").Zip(horrorByDecades, (x, y) => $"{x} {y}");

            IEnumerable<string[]> test = results
                        .Select(x => x.Split(" "));

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");

            Console.WriteLine($"A histogram of books published per decade per genre\n");

            Console.WriteLine($"            Sci-fi      Fantasy     Horror\n");

                        test.ToList().ForEach(x => {
                            string afterDecade = x[0].Length == 2 ? "          " : x[0].Length == 3 ? "         " : "        ";
                            string afterSciFi = x[1].Length == 1 ? "           " : x[1].Length == 2 ? "          " : x[1].Length == 3 ? "         " : "        ";
                            string afterFantasy = x[2].Length == 1 ? "           " : x[2].Length == 2 ? "          " : x[2].Length == 3 ? "         " : "        ";

                            Console.WriteLine($"{x[0]}{afterDecade}{x[1]}{afterSciFi}{x[2]}{afterFantasy}{x[3]}");
                        });
          
           
            #endregion


            #region Task 09

            int highestPercentage = authorsAndBooksLight
                                .OrderByDescending(x => x.PercentageNoms)
                                .Select(x => x.PercentageNoms)
                                .FirstOrDefault();

            var authorWithHighestPercentNomBooksMostBooksAndWins = authorsAndBooksLight 
                                            .Where(x => x.PercentageNoms == highestPercentage)
                                            .OrderByDescending(x => x.BookCount)
                                            .ThenByDescending(x => x.NumOfBooksWithWins)
                                            .FirstOrDefault();

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            Console.WriteLine($"The author with a highest percentage of nominated books ({authorWithHighestPercentNomBooksMostBooksAndWins.PercentageNoms}%) and most books and wins is {authorWithHighestPercentNomBooksMostBooksAndWins.AuthorsName}.");

            #endregion


            #region Task 03 - Namerno e na kraj, zasto gi koci site pred nea

            //- What author wrote most collaborations? 

            IEnumerable<int> allIdsOfCollabs = collabs.Select(x => x.Key);
                
            var authorsOfCollaborations = authorsAndBooksLight
                                    .Where(x => x.BookId.Select(y => allIdsOfCollabs.Any(b => b == y)).Count() != 0);

            int maxCountOfCollabIds = authorsOfCollaborations
                            .Select(x => x.BookId.Where(y => allIdsOfCollabs.Any(b => b == y)).Count())
                            .GroupBy(x => x)
                            .OrderByDescending(x => x.Key)
                            .Select(x => x.Key)
                            .First();

            var authWithMostCollabs = authorsOfCollaborations
                            .First(x => x.BookId.Where(y => allIdsOfCollabs.Any(b => b == y)).Count() == maxCountOfCollabIds);

            System.Console.WriteLine("\n---------------------------------------------------------------------\n");
            System.Console.WriteLine($"The author with most collaborations is {authWithMostCollabs.AuthorsName}. He has {maxCountOfCollabIds} collaborations.");

            #endregion

            
            Console.ReadLine();
            

        }
    }
}
