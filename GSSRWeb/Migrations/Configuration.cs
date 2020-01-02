namespace GSSRWeb.Migrations
{
    using GSSRWeb.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using Website.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GSSRWeb.DAL.GSSRWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GSSRWeb.DAL.GSSRWebContext context)
        {

            List<Genre> genres = new List<Genre>();
            genres.Add(new Genre { GenreId = 1, GenreName = "Action" });
            genres.Add(new Genre { GenreId = 2, GenreName = "Drama" });
            genres.Add(new Genre { GenreId = 3, GenreName = "Comedy" });
            genres.Add(new Genre { GenreId = 4, GenreName = "Sci-Fi" });
            genres.Add(new Genre { GenreId = 5, GenreName = "Thrillers" });
            genres.Add(new Genre { GenreId = 6, GenreName = "Animation" });
            genres.Add(new Genre { GenreId = 7, GenreName = "Family" });
            context.Genre.AddRange(genres);

            List<Picture> pictures = new List<Picture>();
            pictures.Add(new Picture { PictureId = 1, PictureName = "https://m.media-amazon.com/images/M/MV5BZjU2Y2E3NGYtZTk2My00NWEzLTlhNzMtMjBmZmIzOTBlMzgxXkEyXkFqcGdeQXVyNzQwMzAwNTI@._V1_.jpg" });
            pictures.Add(new Picture { PictureId = 2, PictureName = "https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_SY1000_CR0,0,675,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 3, PictureName = "https://m.media-amazon.com/images/M/MV5BMDg2YzI0ODctYjliMy00NTU0LTkxODYtYTNkNjQwMzVmOTcxXkEyXkFqcGdeQXVyNjg2NjQwMDQ@._V1_SY1000_CR0,0,648,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 4, PictureName = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 5, PictureName = "https://m.media-amazon.com/images/M/MV5BMzA0YWMwMTUtMTVhNC00NjRkLWE2ZTgtOWEzNjJhYzNiMTlkXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SY1000_CR0,0,668,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 6, PictureName = "https://m.media-amazon.com/images/M/MV5BMTY0NDY3MDMxN15BMl5BanBnXkFtZTcwOTM5NzMzOQ@@._V1_SY1000_CR0,0,642,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 7, PictureName = "https://m.media-amazon.com/images/M/MV5BMmRhMmI3ZWItMDRlNC00NWIwLWI1MzItMGYzNjMyMGFiOTA3XkEyXkFqcGdeQXVyNjg3MDMxNzU@._V1_SY1000_CR0,0,712,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 8, PictureName = "https://m.media-amazon.com/images/M/MV5BOTg4ZTNkZmUtMzNlZi00YmFjLTk1MmUtNWQwNTM0YjcyNTNkXkEyXkFqcGdeQXVyNjg2NjQwMDQ@._V1_SY1000_CR0,0,674,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 9, PictureName = "https://m.media-amazon.com/images/M/MV5BYzdkNGJhNzQtMjY1OC00MDI3LTk0ZDUtNzU0MGZiY2YwZGUxXkEyXkFqcGdeQXVyNzMxNjQxMTk@._V1_.jpg" });
            pictures.Add(new Picture { PictureId = 10, PictureName = "https://m.media-amazon.com/images/M/MV5BMTc1NjIzODAxMF5BMl5BanBnXkFtZTgwMTgzNzk1NzM@._V1_SY1000_CR0,0,631,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 11, PictureName = "https://m.media-amazon.com/images/M/MV5BOTIzYmUyMmEtMWQzNC00YzExLTk3MzYtZTUzYjMyMmRiYzIwXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_SY1000_CR0,0,685,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 12, PictureName = "https://m.media-amazon.com/images/M/MV5BOGI4NGRlNjEtZDUwOC00ZmRkLWI1ZTgtOGZmMTk3MzQ0ODVhXkEyXkFqcGdeQXVyNDExMzMxNjE@._V1_SY1000_CR0,0,673,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 13, PictureName = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,666,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 14, PictureName = "https://m.media-amazon.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SY1000_CR0,0,674,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 15, PictureName = "https://m.media-amazon.com/images/M/MV5BMjE4NTA1NzExN15BMl5BanBnXkFtZTYwNjc3MjM3._V1_.jpg" });
            pictures.Add(new Picture { PictureId = 16, PictureName = "https://m.media-amazon.com/images/M/MV5BMjIwMjE1Nzc4NV5BMl5BanBnXkFtZTgwNDg4OTA1NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 17, PictureName = "https://m.media-amazon.com/images/M/MV5BNTk4ODQ1MzgzNl5BMl5BanBnXkFtZTgwMTMyMzM4MTI@._V1_SY1000_CR0,0,658,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 18, PictureName = "https://m.media-amazon.com/images/M/MV5BMTYzMDM4NzkxOV5BMl5BanBnXkFtZTgwNzM1Mzg2NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 19, PictureName = "https://m.media-amazon.com/images/M/MV5BMTA2NDc3Njg5NDVeQTJeQWpwZ15BbWU4MDc1NDcxNTUz._V1_SY1000_CR0,0,674,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 20, PictureName = "https://m.media-amazon.com/images/M/MV5BOTk5ODg0OTU5M15BMl5BanBnXkFtZTgwMDQ3MDY3NjM@._V1_SY1000_CR0,0,674,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 21, PictureName = "https://m.media-amazon.com/images/M/MV5BMjE2NDkxNTY2M15BMl5BanBnXkFtZTgwMDc2NzE0MTI@._V1_SY1000_CR0,0,648,1000_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 22, PictureName = "https://m.media-amazon.com/images/M/MV5BMzE2MzEzNDc5M15BMl5BanBnXkFtZTcwMzYxOTA3MQ@@._V1_.jpg" });
            pictures.Add(new Picture { PictureId = 23, PictureName = "https://m.media-amazon.com/images/M/MV5BMjUwMjczMzY5OV5BMl5BanBnXkFtZTgwMjgyMTczNTM@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 24, PictureName = "https://m.media-amazon.com/images/M/MV5BMTY1NDIwMjQ1OF5BMl5BanBnXkFtZTgwMzUzMjI4MTI@._V1_UY268_CR4,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 25, PictureName = "https://m.media-amazon.com/images/M/MV5BMTU2NjA1ODgzMF5BMl5BanBnXkFtZTgwMTM2MTI4MjE@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 26, PictureName = "https://m.media-amazon.com/images/M/MV5BMTY1ODI5NzQ1NF5BMl5BanBnXkFtZTgwMzQ5NDM5NTM@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 27, PictureName = "https://m.media-amazon.com/images/M/MV5BMTYxMzM4NDY5N15BMl5BanBnXkFtZTgwNzg1NTI3MzE@._V1_UY268_CR4,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 28, PictureName = "https://m.media-amazon.com/images/M/MV5BMTA1MTUxNDY4NzReQTJeQWpwZ15BbWU2MDE3ODAxNw@@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 29, PictureName = "https://m.media-amazon.com/images/M/MV5BMTM4NDQ3NDQ3Nl5BMl5BanBnXkFtZTcwMjE4NjY0MQ@@._V1_UY268_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 30, PictureName = "https://m.media-amazon.com/images/M/MV5BMjIzNTg4ODM3OV5BMl5BanBnXkFtZTgwMTk0MjkxMzE@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 31, PictureName = "https://m.media-amazon.com/images/M/MV5BMTc1NTQyNDk2NV5BMl5BanBnXkFtZTcwOTE2OTQzMw@@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 32, PictureName = "https://m.media-amazon.com/images/M/MV5BMzA0NTcxODEyN15BMl5BanBnXkFtZTcwOTA4MjI0MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 33, PictureName = "https://m.media-amazon.com/images/M/MV5BZDg1NWMyMGUtZTYwMS00MTM2LWJjYmEtMjVjMWQ1YWE4ODc3XkEyXkFqcGdeQXVyMTMxMTY0OTQ@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 34, PictureName = "https://m.media-amazon.com/images/M/MV5BMjQ1MzcxNjg4N15BMl5BanBnXkFtZTgwNzgwMjY4MzI@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 35, PictureName = "https://m.media-amazon.com/images/M/MV5BMTk4ODQzNDY3Ml5BMl5BanBnXkFtZTcwODA0NTM4Nw@@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 36, PictureName = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 37, PictureName = "https://m.media-amazon.com/images/M/MV5BMGZlNTY1ZWUtYTMzNC00ZjUyLWE0MjQtMTMxN2E3ODYxMWVmXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 38, PictureName = "https://m.media-amazon.com/images/M/MV5BYzE5MjY1ZDgtMTkyNC00MTMyLThhMjAtZGI5OTE1NzFlZGJjXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_UX182_CR0,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 39, PictureName = "https://m.media-amazon.com/images/M/MV5BNjk1Njk3YjctMmMyYS00Y2I4LThhMzktN2U0MTMyZTFlYWQ5XkEyXkFqcGdeQXVyODM2ODEzMDA@._V1_UY268_CR43,0,182,268_AL_.jpg" });
            pictures.Add(new Picture { PictureId = 40, PictureName = "https://m.media-amazon.com/images/M/MV5BMTg0ODc4Mzk2OF5BMl5BanBnXkFtZTgwNDk2MDkyODE@._V1_UX182_CR0,0,182,268_AL_.jpg" });

            context.Picture.AddRange(pictures);



            List<Movie> movies = new List<Movie>();
            Movie m1 = new Movie { PictureId = 1, YoutubeId = null, MovieId = 1, MovieName = "Ali Baba", MovieDuration = 102, GenreId = 3, YearOfPublish = 2018, Summary = "Ali Baba revolves around an opportunistic person seeking to achieve his interests even at the expense of others, including those who are closest to his heart." };
            movies.Add(m1);
            Movie m2 = new Movie { PictureId = 2, YoutubeId = "eOrNdBpGMv8", MovieId = 2, MovieName = "The Avengers", MovieDuration = 143, GenreId = 4, YearOfPublish = 2012, Summary = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity." };
            movies.Add(m2);
            Movie m3 = new Movie { PictureId = 3, YoutubeId = "pU8-7BX9uxs", MovieId = 3, MovieName = "John Wick 3", MovieDuration = 130, GenreId = 1, YearOfPublish = 2019, Summary = "Super-assassin John Wick is on the run after killing a member of the international assassin's guild, and with a $14 million price tag on his head - he is the target of hit men and women everywhere." };
            movies.Add(m3);
            Movie m4 = new Movie { PictureId = 4, YoutubeId = "m8e-FF8MsqU", MovieId = 4, MovieName = "The Matrix", MovieDuration = 150, GenreId = 4, YearOfPublish = 1999, Summary = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers." };
            movies.Add(m4);
            Movie m5 = new Movie { PictureId = 5, YoutubeId = "3y9qKMLjBfc", MovieId = 5, MovieName = "Superman", MovieDuration = 188, GenreId = 1, YearOfPublish = 1978, Summary = "An alien orphan is sent from his dying planet to Earth, where he grows up to become his adoptive home's first and greatest superhero." };
            movies.Add(m5);
            Movie m6 = new Movie { PictureId = 6, YoutubeId = "4OtM9j2lcUA", MovieId = 6, MovieName = "Now You See Me", MovieDuration = 115, GenreId = 5, YearOfPublish = 2013, Summary = "An F.B.I. Agent and an Interpol Detective track a team of illusionists who pull off bank heists during their performances, and reward their audiences with the money." };
            movies.Add(m6);
            Movie m7 = new Movie { PictureId = 7, YoutubeId = "Vlya92LZqZw", MovieId = 7, MovieName = "Scary Stories to Tell in the Dark", MovieDuration = 111, GenreId = 5, YearOfPublish = 2019, Summary = "It's 1968 in America. Change is blowing in the wind...but seemingly far removed from the unrest in the cities is the small town of Mill Valley where for generations, the shadow of the Bellows family has loomed large." };
            movies.Add(m7);
            Movie m8 = new Movie { PictureId = 8, YoutubeId = "ELeMaP8EPAA", MovieId = 8, MovieName = "Once Upon a Time in Hollywood", MovieDuration = 161, GenreId = 2, YearOfPublish = 2019, Summary = "A faded television actor and his stunt double strive to achieve fame and success in the film industry during the final years of Hollywood's Golden Age in 1969 Los Angeles." };
            movies.Add(m8);
            Movie m9 = new Movie { PictureId = 9, YoutubeId = "RDj8Y2K0ODA", MovieId = 9, MovieName = "The Angry Birds Movie 2", MovieDuration = 96, GenreId = 6, YearOfPublish = 2019, Summary = "The flightless birds and scheming green pigs take their feud to the next level." };
            movies.Add(m9);

            Movie m10 = new Movie { PictureId = 10, YoutubeId = "O-FGqfdCkOM", MovieId = 10, MovieName = "Good Boys", MovieDuration = 89, GenreId = 3, YearOfPublish = 2019, Summary = "Three sixth grade boys ditch school and embark on an epic journey while carrying accidentally stolen drugs, being hunted by teenage girls, and trying to make their way home in time for a long-awaited party." };
            movies.Add(m10);

            Movie m11 = new Movie { PictureId = 11, YoutubeId = "HZ7PAyCDwEg", MovieId = 11, MovieName = "Fast & Furious Presents: Hobbs & Shaw", MovieDuration = 137, GenreId = 1, YearOfPublish = 2019, Summary = "Lawman Luke Hobbs and outcast Deckard Shaw form an unlikely alliance when a cyber-genetically enhanced villain threatens the future of humanity." };
            movies.Add(m11);

            Movie m12 = new Movie { PictureId = 12, YoutubeId = "k9-PqY5pEeo", MovieId = 12, MovieName = "Brian Banks", MovieDuration = 99, GenreId = 2, YearOfPublish = 2018, Summary = "A football player's dreams to play in the NFL are halted when he is wrongly convicted and sent to prison. Years later, he fights to clear his name within an unjust system." };
            movies.Add(m12);

            Movie m13 = new Movie { PictureId = 13, YoutubeId = "SUXWAEX2jlg", MovieId = 13, MovieName = "Fight Club", MovieDuration = 139, GenreId = 2, YearOfPublish = 1999, Summary = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more." };
            movies.Add(m13);


            Movie m14 = new Movie { PictureId = 14, YoutubeId = "iszwuX1AK6A", MovieId = 14, MovieName = "The Wolf of Wall Street", MovieDuration = 180, GenreId = 2, YearOfPublish = 2013, Summary = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government." };
            movies.Add(m14);

            Movie m15 = new Movie { PictureId = 15, YoutubeId = "EFGr2_cOOTk", MovieId = 15, MovieName = "How to Lose a Guy in 10 Days", MovieDuration = 116, GenreId = 3, YearOfPublish = 2003, Summary = "Benjamin Barry is an advertising executive and ladies' man who, to win a big campaign, bets that he can make a woman fall in love with him in 10 days." };
            movies.Add(m15);

            Movie m16 = new Movie { PictureId = 16, YoutubeId = "7TavVZMewpY", MovieId = 16, MovieName = "The Lion King", MovieDuration = 118, GenreId = 6, YearOfPublish = 2019, Summary = "After the murder of his father, a young lion prince flees his kingdom only to learn the true meaning of responsibility and bravery." };
            movies.Add(m16);


            Movie m17 = new Movie { PictureId = 17, YoutubeId = "Nt9L1jCKGnE", MovieId = 17, MovieName = "Spider-Man: Homecoming", MovieDuration = 133, GenreId = 1, YearOfPublish = 2017, Summary = "Peter Parker balances his life as an ordinary high school student in Queens with his superhero alter-ego Spider-Man, and finds himself on the trail of a new menace prowling the skies of New York City." };
            movies.Add(m17);

            Movie m18 = new Movie { PictureId = 18, YoutubeId = "wmiIUN-7qhE", MovieId = 18, MovieName = "Toy Story 4", MovieDuration = 100, GenreId = 6, YearOfPublish = 2019, Summary = "When a new toy called Forky joins Woody and the gang, a road trip alongside old and new friends reveals how big the world can be for a toy." };
            movies.Add(m18);

            Movie m19 = new Movie { PictureId = 19, YoutubeId = "mP0VHJYFOAU", MovieId = 19, MovieName = "Bohemian Rhapsody", MovieDuration = 134, GenreId = 2, YearOfPublish = 2018, Summary = "The story of the legendary rock band Queen and lead singer Freddie Mercury, leading up to their famous performance at Live Aid (1985)." };
            movies.Add(m19);

            Movie m20 = new Movie { PictureId = 20, YoutubeId = "WDkg3h8PCVU", MovieId = 20, MovieName = "Aquaman", MovieDuration = 143, GenreId = 1, YearOfPublish = 2018, Summary = "Arthur Curry, the human-born heir to the underwater kingdom of Atlantis, goes on a quest to prevent a war between the worlds of ocean and land." };
            movies.Add(m20);

            Movie m21 = new Movie { PictureId = 21, YoutubeId = "XGk2EfbD_Ps", MovieId = 21, MovieName = "John Wick 2", MovieDuration = 122, GenreId = 1, YearOfPublish = 2017, Summary = "Super-assassin John Wick is on the run after killing a member of the international assassin's guild, After returning to the criminal underworld to repay a debt, John Wick discovers that a large bounty has been put on his life." };
            movies.Add(m21);
            Movie m22 = new Movie { PictureId = 22, YoutubeId = "Sb8ufI6z0zM", MovieId = 22, MovieName = "Dont Miss With The Zohan", MovieDuration = 113, GenreId = 3, YearOfPublish = 2008, Summary = "An Israeli Special Forces Soldier fakes his death so he can re-emerge in New York City as a hair stylist." };
            movies.Add(m22);
            Movie m23 = new Movie { PictureId = 23, YoutubeId = "zorS5PaV7vg", MovieId = 23, MovieName = "The Week Of", MovieDuration = 116, GenreId = 3, YearOfPublish = 2018, Summary = "Two fathers with opposing personalities come together to celebrate the wedding of their children. They are forced to spend the longest week of their lives together, and the big day cannot come soon enough." };
            movies.Add(m23);
            Movie m24 = new Movie { PictureId = 24, YoutubeId = "wBPBSroi_VE", MovieId = 24, MovieName = "Sandy Wexler", MovieDuration = 130, GenreId = 3, YearOfPublish = 2017, Summary = "Sandy Wexler is a talent manager working in Los Angeles in the 1990s, diligently representing a group of eccentric clients on the fringes of show business." };
            movies.Add(m24);
            Movie m25 = new Movie { PictureId = 25, YoutubeId = "C0BMx-qxsP4", MovieId = 25, MovieName = "Jhon Wick", MovieDuration = 101, GenreId = 1, YearOfPublish = 2014, Summary = "An ex-hit-man comes out of retirement to track down the gangsters that killed his dog and took everything from him." };
            movies.Add(m25);
            Movie m26 = new Movie { PictureId = 26, YoutubeId = "FRHe5J63ClM", MovieId = 26, MovieName = "Sibir", MovieDuration = 104, GenreId = 2, YearOfPublish = 2018, Summary = "When an American diamond trader's Russian partner goes missing, he journeys to Siberia in search of him, but instead begins a love affair." };
            movies.Add(m26);
            Movie m27 = new Movie { PictureId = 27, YoutubeId = "XAHprLW48no", MovieId = 27, MovieName = "Pixels", MovieDuration = 105, GenreId = 3, YearOfPublish = 2015, Summary = "When aliens misinterpret video feeds of classic arcade games as a declaration of war, they attack the Earth in the form of the video games." };
            movies.Add(m27);
            Movie m28 = new Movie { PictureId = 28, YoutubeId = "zZNC5emNyEQ", MovieId = 28, MovieName = "Click", MovieDuration = 107, GenreId = 3, YearOfPublish = 2005, Summary = "A workaholic architect finds a universal remote that allows him to fast-forward and rewind to different parts of his life. Complications arise when the remote starts to overrule his choices." };
            movies.Add(m28);
            Movie m29 = new Movie { PictureId = 29, YoutubeId = "5LKTlIcmA0Q", MovieId = 29, MovieName = "I Now Pronounce You Chuck Larry", MovieDuration = 115, GenreId = 3, YearOfPublish = 2007, Summary = "Two straight, single Brooklyn firefighters pretend to be a gay couple in order to receive domestic partner benefits." };
            movies.Add(m29);
            Movie m30 = new Movie { PictureId = 30, YoutubeId = "wJ0Qhbm3Xj8", MovieId = 30, MovieName = "Top Five", MovieDuration = 102, GenreId = 3, YearOfPublish = 2007, Summary = "A comedian tries to make it as a serious actor when his reality television star fiance talks him into broadcasting their wedding on her television show." };
            movies.Add(m30);
            Movie m31 = new Movie { PictureId = 31, YoutubeId = "l1BF53bXP8I", MovieId = 31, MovieName = "The Longest Yard", MovieDuration = 113, GenreId = 3, YearOfPublish = 2005, Summary = "Prison inmates form a football team to challenge the prison guards." };
            movies.Add(m31);
            Movie m32 = new Movie { PictureId = 32, YoutubeId = "ZEdpZNYuf2Y", MovieId = 32, MovieName = "I Think I Love My Wife", MovieDuration = 94, GenreId = 3, YearOfPublish = 2007, Summary = "A married man who daydreams about being with other women finds his will and morals tested after he's visited by the ex-mistress of his old friend." };
            movies.Add(m32);
            Movie m33 = new Movie { PictureId = 33, YoutubeId = "UT6ARbhTjiU", MovieId = 33, MovieName = "Head of State", MovieDuration = 95, GenreId = 3, YearOfPublish = 2018, Summary = "When a presidential candidate dies unexpectedly in the middle of the campaign, Washington, D.C. alderman, Mays Gilliam is unexpectedly picked as his replacement." };
            movies.Add(m33);
            Movie m34 = new Movie { PictureId = 34, YoutubeId = "Q0CbN8sfihY", MovieId = 34, MovieName = "Star Wars: Episode VIII - The Last Jedi", MovieDuration = 154, GenreId = 1, YearOfPublish = 2017, Summary = "Rey develops her newly discovered abilities with the guidance of Luke Skywalker, who is unsettled by the strength of her powers. Meanwhile, the Resistance prepares for battle with the First Order." };
            movies.Add(m34);
            Movie m35 = new Movie { PictureId = 35, YoutubeId = "GokKUqLcvD8", MovieId = 35, MovieName = "The Dark Knight Rises", MovieDuration = 164, GenreId = 1, YearOfPublish = 2012, Summary = "Eight years after the Joker's reign of anarchy, Batman, with the help of the enigmatic Catwoman, is forced from his exile to save Gotham City, now on the edge of total annihilation, from the brutal guerrilla terrorist Bane." };
            movies.Add(m35);
            Movie m36 = new Movie { PictureId = 36, YoutubeId = "EXeTwQWrcwY", MovieId = 36, MovieName = "The Dark Knight", MovieDuration = 152, GenreId = 1, YearOfPublish = 2008, Summary = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham." };
            movies.Add(m36);
            Movie m37 = new Movie { PictureId = 37, YoutubeId = "Nt9L1jCKGnE", MovieId = 37, MovieName = "Spider-Man: Far from Home", MovieDuration = 129, GenreId = 1, YearOfPublish = 2019, Summary = "Spider-Man must step up to take on new threats in a world that has changed forever." };
            movies.Add(m37);
            Movie m38 = new Movie { PictureId = 38, YoutubeId = "Sy8nPI85Ih4", MovieId = 38, MovieName = "Deadpool", MovieDuration = 118, GenreId = 1, YearOfPublish = 2016, Summary = "A wisecracking mercenary gets experimented on and becomes immortal but ugly, and sets out to track down the man who ruined his looks." };
            movies.Add(m38);
            Movie m39 = new Movie { PictureId = 39, YoutubeId = "D86RtevtfrA", MovieId = 39, MovieName = "Deadpool 2", MovieDuration = 119, GenreId = 1, YearOfPublish = 2018, Summary = "Foul-mouthed mutant mercenary Wade Wilson (AKA. Deadpool), brings together a team of fellow mutant rogues to protect a young boy with supernatural abilities from the brutal, time-traveling cyborg, Cable." };
            movies.Add(m39);
            Movie m40 = new Movie { PictureId = 40, YoutubeId = "3bvnoqsvY-M", MovieId = 40, MovieName = "Criminal", MovieDuration = 113, GenreId = 2, YearOfPublish = 2016, Summary = "In a last-ditch effort to stop a diabolical plot, a dead CIA operative's memories, secrets, and skills are implanted into a death-row inmate in hopes that he will complete the operative's mission." };
            movies.Add(m40);


            context.Movie.AddRange(movies);

            List<Actor> Actors = new List<Actor>();
            Actor m = new Actor { ActorId = 1, DateOfBirth = new DateTime(1986, 11, 22), ActorName = "Ayten Amer", PlaceOfBirth = "Eygpt", ActorIMDBPage = "https://www.imdb.com/name/nm4856970/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m1);
            Actors.Add(m);

            m = new Actor { ActorId = 2, DateOfBirth = new DateTime(1965, 4, 4), ActorName = "Robert Downey Jr.", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0000375/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m2);
            Actors.Add(m);

            m = new Actor { ActorId = 3, DateOfBirth = new DateTime(1981, 6, 13), ActorName = "Chris Evans", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0262635/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m2);
            Actors.Add(m);

            m = new Actor { ActorId = 4, DateOfBirth = new DateTime(1984, 11, 22), ActorName = "Scarlett Johansson", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0424060/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m2);
            Actors.Add(m);

            m = new Actor { ActorId = 5, DateOfBirth = new DateTime(1964, 9, 2), ActorName = "Keanu Reeves", PlaceOfBirth = "Lebanon", ActorIMDBPage = "https://www.imdb.com/name/nm0000206/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m3);
            m.Movie.Add(m4);
            m.Movie.Add(m21);
            m.Movie.Add(m25);
            m.Movie.Add(m26);
            Actors.Add(m);

            m = new Actor { ActorId = 6, DateOfBirth = new DateTime(1966, 8, 14), ActorName = "Halle Berry", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0000932/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m4);
            Actors.Add(m);

            m = new Actor { ActorId = 7, DateOfBirth = new DateTime(1952, 9, 25), ActorName = "Christopher Reeve", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0001659/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m5);
            Actors.Add(m);

            m = new Actor { ActorId = 8, DateOfBirth = new DateTime(1983, 10, 5), ActorName = "Jesse Eisenberg", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0251986/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m6);
            Actors.Add(m);

            m = new Actor { ActorId = 9, DateOfBirth = new DateTime(2001, 11, 27), ActorName = "Zoe Margaret Colletti", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm2292661/?ref_=nmbio_bio_nm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m7);
            Actors.Add(m);
            m = new Actor { ActorId = 10, DateOfBirth = new DateTime(2000, 2, 1), ActorName = "Gabriel Rush", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm3585613/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m7);
            Actors.Add(m);

            m = new Actor { ActorId = 11, DateOfBirth = new DateTime(1974, 11, 11), ActorName = "Leonardo DiCaprio", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0000138/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m8);
            m.Movie.Add(m14);
            Actors.Add(m);

            m = new Actor { ActorId = 12, DateOfBirth = new DateTime(1963, 12, 18), ActorName = "Brad Pitt", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0000093/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m8);
            Actors.Add(m);

            m = new Actor { ActorId = 13, DateOfBirth = new DateTime(1990, 6, 2), ActorName = "Margot Robbie", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm3053338/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m8);
            m.Movie.Add(m7);
            m.Movie.Add(m14);
            Actors.Add(m);

            m = new Actor { ActorId = 14, DateOfBirth = new DateTime(1975, 9, 18), ActorName = "Jason Sudeikis", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0837177/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m9);
            m.Movie.Add(m13);
            Actors.Add(m);

            m = new Actor { ActorId = 15, DateOfBirth = new DateTime(1981, 2, 23), ActorName = "Josh Gad", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm1265802/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m9);
            Actors.Add(m);

            m = new Actor { ActorId = 16, DateOfBirth = new DateTime(1967, 9, 7), ActorName = "Leslie Jones", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm0428656/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m9);
            Actors.Add(m);

            m = new Actor { ActorId = 17, DateOfBirth = new DateTime(2006, 10, 5), ActorName = "Jacob Tremblay", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm5016878/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m10);
            Actors.Add(m);

            m = new Actor { ActorId = 18, DateOfBirth = new DateTime(1995, 12, 6), ActorName = "Molly Gordon", PlaceOfBirth = "USA,new York", ActorIMDBPage = "https://www.imdb.com/name/nm1094137/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m10);
            Actors.Add(m);

            m = new Actor { ActorId = 19, DateOfBirth = new DateTime(1980, 2, 1), ActorName = "Lina Renna", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm6615984/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m10);
            Actors.Add(m);

            m = new Actor { ActorId = 20, DateOfBirth = new DateTime(1972, 5, 2), ActorName = "Dwayne Johnson", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm0425005/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m11);
            Actors.Add(m);

            m = new Actor { ActorId = 21, DateOfBirth = new DateTime(1967, 6, 26), ActorName = "Jason Statham", PlaceOfBirth = "UK,London", ActorIMDBPage = "https://www.imdb.com/name/nm0005458/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m11);
            Actors.Add(m);

            m = new Actor { ActorId = 22, DateOfBirth = new DateTime(1972, 9, 6), ActorName = "Idris Elba", PlaceOfBirth = "UK,London", ActorIMDBPage = "https://www.imdb.com/name/nm0252961/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m11);
            Actors.Add(m);

            //Brain Banks Movie
            m = new Actor { ActorId = 23, DateOfBirth = new DateTime(1986, 9, 20), ActorName = "Aldis Hodge", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm0388038/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m12);
            Actors.Add(m);

            m = new Actor { ActorId = 24, DateOfBirth = new DateTime(1963, 6, 17), ActorName = "Greg Kinnear", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm0001427/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m12);
            Actors.Add(m);

            m = new Actor { ActorId = 25, DateOfBirth = new DateTime(1967, 4, 22), ActorName = "Sherri Shepherd", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm0791868/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m12);
            Actors.Add(m);

            //fight club
            m = new Actor { ActorId = 26, DateOfBirth = new DateTime(1969, 8, 18), ActorName = "Edward Norton", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0001570/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m13);
            Actors.Add(m);

            m = new Actor { ActorId = 27, DateOfBirth = new DateTime(1947, 9, 27), ActorName = "Meat Loaf", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0001533/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m13);
            Actors.Add(m);

            //The Wolf of Wall Street
            m = new Actor { ActorId = 28, DateOfBirth = new DateTime(1983, 12, 20), ActorName = "Jonah Hill", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm1706767/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m14);
            Actors.Add(m);

            //How to Lose a Guy in 10 Days
            m = new Actor { ActorId = 29, DateOfBirth = new DateTime(1979, 4, 19), ActorName = "Kate Hudson", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0005028/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m15);
            Actors.Add(m);

            m = new Actor { ActorId = 30, DateOfBirth = new DateTime(1969, 11, 4), ActorName = "Matthew McConaughey", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0000190/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m15);
            Actors.Add(m);

            m = new Actor { ActorId = 31, DateOfBirth = new DateTime(1970, 10, 25), ActorName = "Adam Goldberg", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0004965/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m15);
            Actors.Add(m);

            //the lion king
            m = new Actor { ActorId = 32, DateOfBirth = new DateTime(1983, 9, 25), ActorName = "Donald Glover", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm2255973/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m16);
            Actors.Add(m);

            m = new Actor { ActorId = 33, DateOfBirth = new DateTime(1981, 9, 4), ActorName = "Beyonce", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0461498/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m16);
            Actors.Add(m);

            m = new Actor { ActorId = 34, DateOfBirth = new DateTime(1982, 4, 15), ActorName = "Seth Rogen", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0736622/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m16);
            Actors.Add(m);


            //Spider-Man: Homecoming
            m = new Actor { ActorId = 35, DateOfBirth = new DateTime(1996, 6, 1), ActorName = "Tom Holland", PlaceOfBirth = "UK,London", ActorIMDBPage = "https://www.imdb.com/name/nm4043618/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m17);
            m.Movie.Add(m37);
            Actors.Add(m);

            m = new Actor { ActorId = 36, DateOfBirth = new DateTime(1951, 9, 5), ActorName = "Michael Keaton", PlaceOfBirth = "USA,Texes", ActorIMDBPage = "https://www.imdb.com/name/nm0000474/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m17);
            Actors.Add(m);

            m = new Actor { ActorId = 37, DateOfBirth = new DateTime(1965, 4, 4), ActorName = "Robert Downey Jr.", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0000375/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m17);
            Actors.Add(m);


            //toy story
            m = new Actor { ActorId = 38, DateOfBirth = new DateTime(1956, 7, 9), ActorName = "Tom Hanks", PlaceOfBirth = "USA,Texes", ActorIMDBPage = "https://www.imdb.com/name/nm0000158/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m18);
            Actors.Add(m);

            m = new Actor { ActorId = 39, DateOfBirth = new DateTime(1953, 6, 13), ActorName = "Tim Allen", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0000741/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m18);
            Actors.Add(m);

            m = new Actor { ActorId = 40, DateOfBirth = new DateTime(1952, 10, 28), ActorName = "Annie Potts", PlaceOfBirth = "USA,Texes", ActorIMDBPage = "https://www.imdb.com/name/nm0001633/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m18);
            Actors.Add(m);

            //Bohemian Rhapsody
            m = new Actor { ActorId = 41, DateOfBirth = new DateTime(1981, 5, 12), ActorName = "Rami Malek", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm1785339/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m19);
            m.Movie.Add(m35);
            Actors.Add(m);

            m = new Actor { ActorId = 42, DateOfBirth = new DateTime(1994, 1, 17), ActorName = "Lucy Boynton", PlaceOfBirth = "USA,Texes", ActorIMDBPage = "https://www.imdb.com/name/nm2377903/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m19);
            Actors.Add(m);

            m = new Actor { ActorId = 43, DateOfBirth = new DateTime(1983, 11, 24), ActorName = "Gwilym Lee", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm3152605/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m19);
            Actors.Add(m);


            //aquaman
            m = new Actor { ActorId = 44, DateOfBirth = new DateTime(1979, 8, 1), ActorName = "Jason Momoa", PlaceOfBirth = "USA,Texes", ActorIMDBPage = "https://www.imdb.com/name/nm0597388/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m20);
            Actors.Add(m);

            m = new Actor { ActorId = 45, DateOfBirth = new DateTime(1986, 4, 22), ActorName = "Amber Heard", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm1720028/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m20);
            Actors.Add(m);

            m = new Actor { ActorId = 46, DateOfBirth = new DateTime(1995, 6, 22), ActorName = "Willem Dafoe", PlaceOfBirth = "USA", ActorIMDBPage = "https://www.imdb.com/name/nm0000353/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m20);
            m.Movie.Add(m25);
            Actors.Add(m);

            m = new Actor { ActorId = 47, DateOfBirth = new DateTime(1960, 11, 8), ActorName = "Michael Nyqvist", PlaceOfBirth = "SWEDEN", ActorIMDBPage = "https://www.imdb.com/name/nm0638824/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m21);
            m.Movie.Add(m3);
            m.Movie.Add(m25);
            Actors.Add(m);
            m = new Actor { ActorId = 48, DateOfBirth = new DateTime(1962, 12, 10), ActorName = "Lance Reddick", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0714698/?ref_=ttfc_fc_cl_t14" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m21);
            m.Movie.Add(m3);
            m.Movie.Add(m25);
            Actors.Add(m);
            m = new Actor { ActorId = 49, DateOfBirth = new DateTime(1966, 9, 9), ActorName = "Adam Sandler", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0001191/?ref_=tt_cl_t1" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m22);
            m.Movie.Add(m23);
            m.Movie.Add(m24);
            m.Movie.Add(m27);
            m.Movie.Add(m28);
            m.Movie.Add(m29);
            m.Movie.Add(m30);
            m.Movie.Add(m31);
            Actors.Add(m);
            m = new Actor { ActorId = 50, DateOfBirth = new DateTime(1957, 2, 28), ActorName = "John Turturro", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0001806/?ref_=tt_cl_t2" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m22);
            Actors.Add(m);
            m = new Actor { ActorId = 51, DateOfBirth = new DateTime(1975, 12, 10), ActorName = "Emmanuelle Chriqui", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0004825/?ref_=tt_cl_t3" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m21);
            m.Movie.Add(m3);
            m.Movie.Add(m22);
            Actors.Add(m);
            m = new Actor { ActorId = 52, DateOfBirth = new DateTime(1965, 2, 7), ActorName = "Chris Rock", PlaceOfBirth = "USA,South Carolina", ActorIMDBPage = "https://www.imdb.com/name/nm0001674/?ref_=tt_cl_t2" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m22);
            m.Movie.Add(m23);
            m.Movie.Add(m30);
            m.Movie.Add(m31);
            m.Movie.Add(m32);
            m.Movie.Add(m33);
            Actors.Add(m);

            m = new Actor { ActorId = 53, DateOfBirth = new DateTime(1981, 12, 1), ActorName = "Boris Gulyarian", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm8969966/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m26);
            m.Movie.Add(m37);
            Actors.Add(m);
            m = new Actor { ActorId = 54, DateOfBirth = new DateTime(1983, 12, 3), ActorName = "Ashley st Gorrge", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm4244567/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m26);
            m.Movie.Add(m35);
            Actors.Add(m);
            m = new Actor { ActorId = 55, DateOfBirth = new DateTime(1965, 4, 26), ActorName = "Kevin James", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0416673/?ref_=tt_cl_t2" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m27);
            m.Movie.Add(m29);
            m.Movie.Add(m30);
            m.Movie.Add(m31);
            Actors.Add(m);
            m = new Actor { ActorId = 56, DateOfBirth = new DateTime(1976, 3, 23), ActorName = "Michelle Monaghan", PlaceOfBirth = "USA,Iowa", ActorIMDBPage = "https://www.imdb.com/name/nm1157358/?ref_=tt_cl_t3" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m27);
            Actors.Add(m);
            m = new Actor { ActorId = 57, DateOfBirth = new DateTime(2000, 2, 1), ActorName = "Michael Garza", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm3585613/bio?ref_=nm_ov_bio_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m7);
            Actors.Add(m);
            m = new Actor { ActorId = 58, DateOfBirth = new DateTime(1969, 6, 11), ActorName = "Peter Dinklage", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm0227759/?ref_=tt_cl_t4" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m27);
            Actors.Add(m);
            m = new Actor { ActorId = 59, DateOfBirth = new DateTime(1973, 7, 26), ActorName = "Kate Beckinsale", PlaceOfBirth = "USA,New Jersey", ActorIMDBPage = "https://www.imdb.com/name/nm0000295/?ref_=tt_cl_t2" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m28);
            Actors.Add(m);
            m = new Actor { ActorId = 60, DateOfBirth = new DateTime(1943, 3, 31), ActorName = "Christopher Walken", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0000686/?ref_=tt_cl_t3" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m28);
            Actors.Add(m);
            m = new Actor { ActorId = 61, DateOfBirth = new DateTime(1945, 10, 30), ActorName = "Henry Winkler", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0001857/?ref_=tt_cl_t5" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m28);
            Actors.Add(m);
            m = new Actor { ActorId = 62, DateOfBirth = new DateTime(1982, 3, 3), ActorName = "Jessica Biel", PlaceOfBirth = "USA,Minnesota", ActorIMDBPage = "https://www.imdb.com/name/nm0004754/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m29);
            Actors.Add(m);
            m = new Actor { ActorId = 63, DateOfBirth = new DateTime(1977, 1, 31), ActorName = "Kerry Washington", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0004754/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m32);
            Actors.Add(m);
            m = new Actor { ActorId = 64, DateOfBirth = new DateTime(1977, 4, 25), ActorName = "Gina Torres", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0868659/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m32);
            Actors.Add(m);
            m = new Actor { ActorId = 65, DateOfBirth = new DateTime(1955, 4, 25), ActorName = "Mark Hamill", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0000434/?ref_=tt_cl_t1" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m34);
            Actors.Add(m);
            m = new Actor { ActorId = 66, DateOfBirth = new DateTime(1956, 10, 21), ActorName = "Carrie Fisher", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm0000402/?ref_=tt_cl_t2" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m34);
            Actors.Add(m);
            m = new Actor { ActorId = 67, DateOfBirth = new DateTime(1983, 11, 19), ActorName = "Adam Driver", PlaceOfBirth = "USA,California", ActorIMDBPage = "https://www.imdb.com/name/nm3485845/?ref_=tt_cl_t3" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m34);
            Actors.Add(m);

            m = new Actor { ActorId = 68, DateOfBirth = new DateTime(1974, 1, 30), ActorName = "Christian Bale", PlaceOfBirth = "UK,WALES", ActorIMDBPage = "https://www.imdb.com/name/nm3485845/?ref_=tt_cl_t3" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m35);
            m.Movie.Add(m36);
            Actors.Add(m);
            m = new Actor { ActorId = 69, DateOfBirth = new DateTime(1977, 9, 15), ActorName = "Tom Hardy", PlaceOfBirth = "UK,WALES", ActorIMDBPage = "https://www.imdb.com/name/nm0362766/?ref_=tt_cl_t3" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m35);
            Actors.Add(m);
            m = new Actor { ActorId = 70, DateOfBirth = new DateTime(1979, 4, 4), ActorName = "Heath Ledger", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0005132/?ref_=tt_cl_t2" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m36);
            Actors.Add(m);
            m = new Actor { ActorId = 71, DateOfBirth = new DateTime(1948, 12, 21), ActorName = "Samuel L. Jackson", PlaceOfBirth = "USA,colombia", ActorIMDBPage = "https://www.imdb.com/name/nm0000168/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m37);
            Actors.Add(m);
            m = new Actor { ActorId = 72, DateOfBirth = new DateTime(1980, 12, 19), ActorName = "Jake Gyllenhaal", PlaceOfBirth = "USA,Colombia", ActorIMDBPage = "https://www.imdb.com/name/nm0350453/?ref_=tt_cl_t3" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m37);
            Actors.Add(m);
            m = new Actor { ActorId = 73, DateOfBirth = new DateTime(1976, 10, 23), ActorName = "Ryan Reynolds", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0005351/?ref_=tt_ov_st_sm" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m38);
            m.Movie.Add(m39);
            m.Movie.Add(m40);
            Actors.Add(m);
            m = new Actor { ActorId = 74, DateOfBirth = new DateTime(1996, 8, 14), ActorName = "Brianna Hildebrand", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm6552202/?ref_=tt_cl_t6" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m38);
            m.Movie.Add(m39);
            Actors.Add(m);
            m = new Actor { ActorId = 75, DateOfBirth = new DateTime(1980, 12, 23), ActorName = "Style Dayne", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm4406623/?ref_=tt_cl_t7" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m38);
            m.Movie.Add(m39);
            Actors.Add(m);
            m = new Actor { ActorId = 76, DateOfBirth = new DateTime(1955, 1, 18), ActorName = "Kevin Costner", PlaceOfBirth = "USA,New York", ActorIMDBPage = "https://www.imdb.com/name/nm0000126/?ref_=tt_cl_t1" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m40);
            Actors.Add(m);
            m = new Actor { ActorId = 77, DateOfBirth = new DateTime(1955, 1, 18), ActorName = "Gal Gadot", PlaceOfBirth = "Isreal,Tel Aviv", ActorIMDBPage = "https://www.imdb.com/name/nm2933757/?ref_=tt_cl_t6" };
            m.Movie = new List<Movie>();
            m.Movie.Add(m40);
            Actors.Add(m);

            context.Actor.AddRange(Actors);

            List<ActorLocation> al = new List<ActorLocation>();
            ActorLocation a = new ActorLocation { ActorLocationId = 1, ActorId = 1, Lat = 30.043489, Long = 31.235291 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 2, ActorId = 2, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 3, ActorId = 3, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 4, ActorId = 4, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 5, ActorId = 5, Lat = 32.664478, Long = -81.249817 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 6, ActorId = 6, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 7, ActorId = 7, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 8, ActorId = 8, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 9, ActorId = 9, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 10, ActorId = 10, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 11, ActorId = 11, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 12, ActorId = 12, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 13, ActorId = 13, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 14, ActorId = 14, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 15, ActorId = 15, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 16, ActorId = 16, Lat = 40.058323, Long = -74.405663 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 17, ActorId = 17, Lat = 40.058323, Long = -74.405663 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 18, ActorId = 18, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 19, ActorId = 19, Lat = 40.058323, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 20, ActorId = 20, Lat = 40.058323, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 21, ActorId = 21, Lat = 51.507351, Long = -0.127758 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 22, ActorId = 22, Lat = 51.507351, Long = -0.127758 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 23, ActorId = 23, Lat = 40.058323, Long = -74.405663 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 24, ActorId = 24, Lat = 40.058323, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 25, ActorId = 25, Lat = 51.500150, Long = -0.126240 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 26, ActorId = 26, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 27, ActorId = 27, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 28, ActorId = 28, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 29, ActorId = 29, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 30, ActorId = 30, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 31, ActorId = 31, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 32, ActorId = 32, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 33, ActorId = 33, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 34, ActorId = 34, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);

            a = new ActorLocation { ActorLocationId = 35, ActorId = 35, Lat = 51.500150, Long = -0.126240 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 36, ActorId = 36, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 37, ActorId = 37, Lat = 51.500150, Long = -0.126240 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 38, ActorId = 38, Lat = 42.201020, Long = -85.706310 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 39, ActorId = 39, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);

            a = new ActorLocation { ActorLocationId = 40, ActorId = 40, Lat = 42.201020, Long = -85.706310 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 41, ActorId = 41, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 42, ActorId = 42, Lat = 42.201020, Long = -85.706310 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 43, ActorId = 43, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 44, ActorId = 44, Lat = 42.201020, Long = -85.706310 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 45, ActorId = 45, Lat = 36.778259, Long = -119.417931 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 46, ActorId = 46, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 47, ActorId = 47, Lat = 60.128162, Long = 18.643501 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 48, ActorId = 48, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 49, ActorId = 49, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 50, ActorId = 50, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 51, ActorId = 51, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 52, ActorId = 52, Lat = 33.631180, Long = -80.947430 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 53, ActorId = 53, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 54, ActorId = 54, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 55, ActorId = 55, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 56, ActorId = 56, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 57, ActorId = 63, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 58, ActorId = 64, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 59, ActorId = 65, Lat = 33.925100, Long = -118.024450 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 60, ActorId = 66, Lat = 33.925100, Long = -118.024450 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 61, ActorId = 67, Lat = 33.925100, Long = -118.024450 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 62, ActorId = 68, Lat = 36.144910, Long = -5.353250 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 63, ActorId = 69, Lat = 36.144910, Long = -5.353250 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 64, ActorId = 70, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 65, ActorId = 71, Lat = 33.855540, Long = -118.032640 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 66, ActorId = 72, Lat = 33.855540, Long = -118.032640 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 67, ActorId = 73, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 68, ActorId = 74, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 69, ActorId = 75, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 70, ActorId = 76, Lat = 40.713050, Long = -74.007230 };
            al.Add(a);
            a = new ActorLocation { ActorLocationId = 71, ActorId = 77, Lat = 32.085300, Long = 34.781769 };
            al.Add(a);
            context.ActorLocation.AddRange(al);






            List<Director> directors = new List<Director>();
            Director d = new Director { DirectorId = 1, DirectorName = "Walid El-Halafawi", DateOfBirth = new DateTime(1980, 10, 1), PlaceOfBirth = "Eygpt" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m1);
            directors.Add(d);

            d = new Director { DirectorId = 2, DirectorName = "Joss Whedon", DateOfBirth = new DateTime(1964, 6, 23), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m2);
            directors.Add(d);

            d = new Director { DirectorId = 3, DirectorName = "Chad Stahelski", DateOfBirth = new DateTime(1968, 9, 20), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m3);
            d.Movie.Add(m21);
            d.Movie.Add(m25);
            directors.Add(d);

            d = new Director { DirectorId = 4, DirectorName = "Lana Wachowski", DateOfBirth = new DateTime(1965, 6, 21), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m4);
            d.Movie.Add(m26);
            directors.Add(d);

            d = new Director { DirectorId = 5, DirectorName = "Richard Donner", DateOfBirth = new DateTime(1930, 4, 24), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m5);
            directors.Add(d);

            d = new Director { DirectorId = 6, DirectorName = "Louis Leterrier", DateOfBirth = new DateTime(1973, 6, 17), PlaceOfBirth = "France" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m6);
            directors.Add(d);

            d = new Director { DirectorId = 7, DirectorName = "Andre Ovredal", DateOfBirth = new DateTime(1973, 5, 6), PlaceOfBirth = "Norvegia" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m7);
            d.Movie.Add(m40);
            directors.Add(d);

            d = new Director { DirectorId = 8, DirectorName = "Quentin Tarantino", DateOfBirth = new DateTime(1963, 3, 27), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m8);
            directors.Add(d);

            d = new Director { DirectorId = 9, DirectorName = "Thurop Van Orman", DateOfBirth = new DateTime(1976, 4, 26), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m8);
            directors.Add(d);

            d = new Director { DirectorId = 10, DirectorName = "Gene Stupnitsky", DateOfBirth = new DateTime(1977, 8, 26), PlaceOfBirth = "Ukraine" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m10);
            directors.Add(d);

            d = new Director { DirectorId = 11, DirectorName = "David Leitch", DateOfBirth = new DateTime(1969, 12, 31), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m11);
            directors.Add(d);

            d = new Director { DirectorId = 12, DirectorName = "Tom Shadyac", DateOfBirth = new DateTime(1958, 12, 11), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m12);
            d.Movie.Add(m28);
            directors.Add(d);

            d = new Director { DirectorId = 13, DirectorName = "David Fincher", DateOfBirth = new DateTime(1962, 8, 28), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m13);
            directors.Add(d);

            d = new Director { DirectorId = 14, DirectorName = "Martin Scorsese", DateOfBirth = new DateTime(1942, 11, 17), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m14);
            directors.Add(d);

            d = new Director { DirectorId = 15, DirectorName = "Donald Petrie", DateOfBirth = new DateTime(1954, 4, 2), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m15);
            directors.Add(d);

            d = new Director { DirectorId = 16, DirectorName = "Jon Favreau", DateOfBirth = new DateTime(1966, 10, 19), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m16);
            directors.Add(d);

            d = new Director { DirectorId = 17, DirectorName = "Jon Watts", DateOfBirth = new DateTime(1981, 7, 28), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m17);
            d.Movie.Add(m37);
            directors.Add(d);

            d = new Director { DirectorId = 18, DirectorName = "Josh Cooley", DateOfBirth = new DateTime(1980, 5, 23), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m18);
            directors.Add(d);

            d = new Director { DirectorId = 19, DirectorName = "Bryan Singer", DateOfBirth = new DateTime(1965, 9, 17), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m19);
            d.Movie.Add(m34);
            directors.Add(d);

            d = new Director { DirectorId = 20, DirectorName = "James Wan", DateOfBirth = new DateTime(1997, 2, 26), PlaceOfBirth = "Kuching" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m20);
            directors.Add(d);

            d = new Director { DirectorId = 21, DirectorName = "Dennis Dugan", DateOfBirth = new DateTime(1946, 9, 15), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m22);
            d.Movie.Add(m29);
            directors.Add(d);

            d = new Director { DirectorId = 22, DirectorName = "Robert Smigel", DateOfBirth = new DateTime(1960, 2, 7), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m23);
            directors.Add(d);
            d = new Director { DirectorId = 23, DirectorName = "Steven Brill", DateOfBirth = new DateTime(1962, 5, 27), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m24);
            d.Movie.Add(m27);
            directors.Add(d);

            d = new Director { DirectorId = 24, DirectorName = "Chris Rock ", DateOfBirth = new DateTime(1965, 2, 7), PlaceOfBirth = "USA" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m30);
            d.Movie.Add(m31);
            d.Movie.Add(m32);
            d.Movie.Add(m33);
            directors.Add(d);
            d = new Director { DirectorId = 25, DirectorName = "Christopher Nolan", DateOfBirth = new DateTime(1970, 7, 30), PlaceOfBirth = "England" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m35);
            d.Movie.Add(m36);
            directors.Add(d);
            d = new Director { DirectorId = 25, DirectorName = "Tim Miller", DateOfBirth = new DateTime(1962, 7, 30), PlaceOfBirth = "England" };
            d.Movie = new List<Movie>();
            d.Movie.Add(m38);
            d.Movie.Add(m39);
            directors.Add(d);
            context.Director.AddRange(directors);


            List<Writer> Writers = new List<Writer>();
            Writer p = new Writer { WriterId = 1, WriterName = "Karim Fahmy", DateOfBirth = new DateTime(1970, 2, 2), PlaceOfBirth = "Eygpt" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m1);
            Writers.Add(p);

            p = new Writer { WriterId = 2, WriterName = "Joss Whedon", DateOfBirth = new DateTime(1964, 6, 23), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m2);
            Writers.Add(p);

            p = new Writer { WriterId = 3, WriterName = "Derek Kolstad", DateOfBirth = new DateTime(1972, 3, 2), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m3);
            p.Movie.Add(m21);
            p.Movie.Add(m25);
            Writers.Add(p);

            p = new Writer { WriterId = 4, WriterName = "Lana Wachowski", DateOfBirth = new DateTime(1965, 6, 21), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m4);
            p.Movie.Add(m26);
            Writers.Add(p);

            p = new Writer { WriterId = 5, WriterName = "Jerry Siegel", DateOfBirth = new DateTime(1914, 10, 17), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m5);
            Writers.Add(p);

            p = new Writer { WriterId = 6, WriterName = "Ed Solomon", DateOfBirth = new DateTime(1960, 9, 15), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m6);
            Writers.Add(p);

            p = new Writer { WriterId = 7, WriterName = "Dan Hageman", DateOfBirth = new DateTime(1960, 9, 15), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m7);
            Writers.Add(p);

            p = new Writer { WriterId = 8, WriterName = "Quentin Tarantino", DateOfBirth = new DateTime(1963, 3, 27), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m8);
            Writers.Add(p);

            p = new Writer { WriterId = 9, WriterName = "Peter Ackerman", DateOfBirth = new DateTime(1946, 11, 6), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m9);
            Writers.Add(p);

            p = new Writer { WriterId = 10, WriterName = "Lee Eisenberg", DateOfBirth = new DateTime(1977, 4, 5), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m10);
            Writers.Add(p);

            p = new Writer { WriterId = 11, WriterName = "Chris Morgan", DateOfBirth = new DateTime(1966, 11, 24), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m11);
            p.Movie.Add(m37);
            Writers.Add(p);

            p = new Writer { WriterId = 12, WriterName = "Doug Atchison", PlaceOfBirth = "USA", DateOfBirth = new DateTime(1976, 4, 1) };
            p.Movie = new List<Movie>();
            p.Movie.Add(m12);
            Writers.Add(p);

            p = new Writer { WriterId = 13, WriterName = "Chuck Palahniuk", DateOfBirth = new DateTime(1962, 2, 21), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m13);
            Writers.Add(p);

            p = new Writer { WriterId = 14, WriterName = "Terence Winter", DateOfBirth = new DateTime(1960, 10, 2), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m14);
            Writers.Add(p);

            p = new Writer { WriterId = 15, WriterName = "Michele Alexander", PlaceOfBirth = "USA", DateOfBirth = new DateTime(1986, 3, 2) };
            p.Movie = new List<Movie>();
            p.Movie.Add(m15);
            Writers.Add(p);

            p = new Writer { WriterId = 16, WriterName = "Jeff Nathanson", DateOfBirth = new DateTime(1965, 10, 12), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m16);
            Writers.Add(p);

            p = new Writer { WriterId = 17, WriterName = "Jonathan Goldstein", DateOfBirth = new DateTime(1969, 8, 22), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m17);
            Writers.Add(p);

            p = new Writer { WriterId = 18, WriterName = "John Lasseter", DateOfBirth = new DateTime(1957, 1, 12), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m18);
            Writers.Add(p);

            p = new Writer { WriterId = 19, WriterName = "Anthony McCarten", DateOfBirth = new DateTime(1961, 4, 28), PlaceOfBirth = "New Zealand" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m19);
            p.Movie.Add(m40);
            Writers.Add(p);

            p = new Writer { WriterId = 20, WriterName = "David Leslie Johnson-McGoldrick", PlaceOfBirth = "USA", DateOfBirth = new DateTime(1990, 2, 1) };
            p.Movie = new List<Movie>();
            p.Movie.Add(m19);
            p.Movie.Add(m34);
            Writers.Add(p);
            p = new Writer { WriterId = 21, WriterName = "Adem Sandler", PlaceOfBirth = "USA", DateOfBirth = new DateTime(1966, 9, 9) };
            p.Movie = new List<Movie>();
            p.Movie.Add(m22);
            p.Movie.Add(m23);
            p.Movie.Add(m24);
            p.Movie.Add(m27);
            p.Movie.Add(m28);
            Writers.Add(p);
            p = new Writer { WriterId = 22, WriterName = "Chris Rock", PlaceOfBirth = "USA", DateOfBirth = new DateTime(1965, 2, 7) };
            p.Movie = new List<Movie>();
            p.Movie.Add(m30);
            p.Movie.Add(m31);
            p.Movie.Add(m32);
            p.Movie.Add(m33);
            Writers.Add(p);
            p = new Writer { WriterId = 23, WriterName = "Christopher Nolan", DateOfBirth = new DateTime(1970, 7, 30), PlaceOfBirth = "ENGLAED" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m35);
            p.Movie.Add(m36);
            Writers.Add(p);
            p = new Writer { WriterId = 24, WriterName = "Rhett Reese", DateOfBirth = new DateTime(1961, 7, 30), PlaceOfBirth = "USA" };
            p.Movie = new List<Movie>();
            p.Movie.Add(m38);
            p.Movie.Add(m39);
            Writers.Add(p);




            context.Writer.AddRange(Writers);

            List<Review> reviews = new List<Review>();
            reviews.Add(new Review { ReviewId = 1, MovieId = 1, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "I did not expect another  here. But I knew once learning about the plot and seeing the film poster that I might feel the familiarity. " });
            reviews.Add(new Review { ReviewId = 2, MovieId = 1, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "The only reason this movie has a leg to stand on is because of a Hollywood budget! Strip away that veneer, and you're left with a mediocre B movie." });
            reviews.Add(new Review { ReviewId = 3, MovieId = 2, ReviewRating = 5, UserName = "Ran", ReviewDate = new DateTime(2019, 10, 23, 19, 0, 0), ReviewText = "There is no way this movie is 8 stars as it ranked currently! The movies story was lacking, and just smh bad. A lot of the stunts were slow, repetitive, and sloppy." });
            reviews.Add(new Review { ReviewId = 28, MovieId = 2, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "I did not expect another  here. But I knew once learning about the plot and seeing the film poster that I might feel the familiarity. " });
            reviews.Add(new Review { ReviewId = 4, MovieId = 3, ReviewRating = 1, UserName = "Sagi", ReviewDate = new DateTime(2019, 10, 23, 19, 0, 0), ReviewText = "It's not the worse movie, but far from the best." });
            reviews.Add(new Review { ReviewId = 29, MovieId = 3, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "with movie like this i not think i will able to go to movie center again" });
            reviews.Add(new Review { ReviewId = 30, MovieId = 4, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "with movie like this i not think i will able to go to movie center again" });
            reviews.Add(new Review { ReviewId = 5, MovieId = 4, ReviewRating = 2, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "Maybe they wanted to keep it low. If you observe the ending, who had ended where, there's more to come. The season two could get even bigger. I feel they could get back to what Marvel is famous for." });
            reviews.Add(new Review { ReviewId = 6, MovieId = 5, ReviewRating = 5, UserName = "Sagi", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "is now deciding to claim back their glory by bringing down the New York City. Within them, they have differences, but their vision is same. " });
            reviews.Add(new Review { ReviewId = 31, MovieId = 5, ReviewRating = 3, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 25, 19, 0, 0), ReviewText = "It was like, came five years ago. One of the most unexpected films from a debutant director to succeed commercially, as well as to grab as many as the German Academy Awards." });
            reviews.Add(new Review { ReviewId = 32, MovieId = 6, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 26, 16, 0, 0), ReviewText = "The only reason this movie has a leg to stand on is because of a Hollywood budget! Strip away that veneer, and you're left with a mediocre B movie." });
            reviews.Add(new Review { ReviewId = 7, MovieId = 6, ReviewRating = 2, UserName = "Gal", ReviewDate = new DateTime(2019, 10, 23, 19, 0, 0), ReviewText = "It's not the worse movie, but far from the best." });
            reviews.Add(new Review { ReviewId = 8, MovieId = 7, ReviewRating = 2, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "he best thing about it is, this was not from your watchlist director's film or big name actor's. Most of people do not care if the film fails or succeeds, but if they get a chance to see it" });
            reviews.Add(new Review { ReviewId = 33, MovieId = 7, ReviewRating = 3, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "Overall, I enjoyed John Wick as a pure action film. It doesn't have a storyline like The Matrix or Speed, but it was visually entertaining and the simplicity of the story allowed for appreciation of the action. This movie is manly and primitive, and proves that at the age of 50, Keanu Reeves can still mix it up as an action star." });
            reviews.Add(new Review { ReviewId = 34, MovieId = 8, ReviewRating = 3, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "It was like, came five years ago. One of the most unexpected films from a debutant director to succeed commercially, as well as to grab as many as the German Academy Awards." });
            reviews.Add(new Review { ReviewId = 9, MovieId = 8, ReviewRating = 5, UserName = "Shunit", ReviewDate = new DateTime(2019, 10, 23, 19, 0, 0), ReviewText = " don't dislike it, but this is not my kind of entertainment. Not anymore. The 90s films made some sense, but this one looked too innocent to portray such young people in a such a cruel shade." });
            reviews.Add(new Review { ReviewId = 10, MovieId = 9, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "it's already fourth from a film franchise made for television. A couple of months ago I reviewed the previous film," });
            reviews.Add(new Review { ReviewId = 35, MovieId = 9, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 8, 22, 20, 0, 0), ReviewText = "This is a Christian film and like usual, I did not mind that. I cherish film for what it narrates than on what it all was all built on. " });
            reviews.Add(new Review { ReviewId = 36, MovieId = 10, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 24, 16, 0, 0), ReviewText = "the worse movie ever" });
            reviews.Add(new Review { ReviewId = 11, MovieId = 10, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "The only reason this movie has a leg to stand on is because of a Hollywood budget! Strip away that veneer, and you're left with a mediocre B movie." });
            reviews.Add(new Review { ReviewId = 12, MovieId = 11, ReviewRating = 5, UserName = "Ran", ReviewDate = new DateTime(2019, 10, 23, 19, 0, 0), ReviewText = "it is very sad to know that only blind people have seen it. Otherwise, this is not a response the film deserved. It was almost a solid 10 out of 10 film. Superfast narration. Beautiful setting" });
            reviews.Add(new Review { ReviewId = 66, MovieId = 11, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 24, 20, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 13, MovieId = 12, ReviewRating = 5, UserName = "Sagi", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "It was like, came five years ago. One of the most unexpected films from a debutant director to succeed commercially, as well as to grab as many as the German Academy Awards." });
            reviews.Add(new Review { ReviewId = 67, MovieId = 12, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 21, 16, 0, 0), ReviewText = "This film has been saved by its stars: Ryan Reynolds first and Kevin Costner few minutes later will make you forget most of plot's unbelievable logical holes," });
            reviews.Add(new Review { ReviewId = 14, MovieId = 13, ReviewRating = 3, UserName = "Shunit", ReviewDate = new DateTime(2019, 10, 23, 19, 0, 0), ReviewText = "Every year a film was made, particularly by the black filmmakers about how black people had struggled in the previous centuries." });
            reviews.Add(new Review { ReviewId = 68, MovieId = 13, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 22, 21, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 69, MovieId = 14, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 23, 16, 0, 0), ReviewText = "not reccomended at all." });
            reviews.Add(new Review { ReviewId = 15, MovieId = 14, ReviewRating = 3, UserName = "Sagi", ReviewDate = new DateTime(2019, 8, 22, 17, 0, 0), ReviewText = "Actually not a bad film. Seeing the poster, you can expect the kids films like 'ET', 'Stand By Me', 'Goonies', et cetera kind. But it was a different." });
            reviews.Add(new Review { ReviewId = 16, MovieId = 15, ReviewRating = 5, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "It was like, came five years ago. One of the most unexpected films from a debutant director to succeed commercially, as well as to grab as many as the German Academy Awards." });
            reviews.Add(new Review { ReviewId = 70, MovieId = 15, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 6, 24, 14, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 71, MovieId = 16, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 24, 16, 0, 0), ReviewText = "I had the honor of watching TDK during a screening and was completely blown away!" });
            reviews.Add(new Review { ReviewId = 17, MovieId = 16, ReviewRating = 5, UserName = "Sagi", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "best movie ever" });
            reviews.Add(new Review { ReviewId = 18, MovieId = 17, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "with movie like this i not think i will able to go to movie center again" });
            reviews.Add(new Review { ReviewId = 72, MovieId = 17, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 7, 24, 11, 0, 0), ReviewText = "They all succeed in saving the day and in the end you won't fall asleep or leave theater in contempt. But on your way home you could probably comment that this is one of the most useless (or unconvincing) films you ever watched." });
            reviews.Add(new Review { ReviewId = 73, MovieId = 18, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 6, 24, 12, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 19, MovieId = 18, ReviewRating = 2, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "The storyline seems just okay. Since it is not fresh enough, they did not even overuse the concept to build plot with cliches." });
            reviews.Add(new Review { ReviewId = 20, MovieId = 19, ReviewRating = 2, UserName = "Shunit", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "It's true that Sandler had lost his Midas touch, but last few films suggest he's back. Still, he's not the same old what he used to be. The time has changed, so he has to adapt to it and I think he's doing okay. Only haters/film critics keep hating him" });
            reviews.Add(new Review { ReviewId = 74, MovieId = 19, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 8, 24, 13, 0, 0), ReviewText = "I had the honor of watching TDK during a screening and was completely blown away!" });
            reviews.Add(new Review { ReviewId = 75, MovieId = 20, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 9, 24, 14, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 21, MovieId = 20, ReviewRating = 2, UserName = "Gal", ReviewDate = new DateTime(2019, 8, 22, 17, 0, 0), ReviewText = "the best movie ever!!" });
            reviews.Add(new Review { ReviewId = 22, MovieId = 21, ReviewRating = 4, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "Overall, I enjoyed John Wick as a pure action film. It doesn't have a storyline like The Matrix or Speed, but it was visually entertaining and the simplicity of the story allowed for appreciation of the action. This movie is manly and primitive, and proves that at the age of 50, Keanu Reeves can still mix it up as an action star." });
            reviews.Add(new Review { ReviewId = 78, MovieId = 21, ReviewRating = 1, UserName = "Sagi", ReviewDate = new DateTime(2019, 6, 22, 16, 0, 0), ReviewText = "Overall, I enjoyed the movie, but the plot was confusing" });
            reviews.Add(new Review { ReviewId = 23, MovieId = 22, ReviewRating = 4, UserName = "Sagi", ReviewDate = new DateTime(2019, 8, 22, 17, 0, 0), ReviewText = "I think some people have their genres confused when they start talking about 'shedding light on conflict' blah blah. What the hell? It's an Adam Sandler movie not Schindler's list." });
            reviews.Add(new Review { ReviewId = 79, MovieId = 22, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 3, 22, 17, 0, 0), ReviewText = "This movie was boring as hell" });
            reviews.Add(new Review { ReviewId = 24, MovieId = 23, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 9, 23, 18, 0, 0), ReviewText = "Overall it was stressful to watch. I felt as if I was put in an acquired situation for over an hour and couldn't get out, but tried to pretend everything was ok. " });
            reviews.Add(new Review { ReviewId = 25, MovieId = 23, ReviewRating = 3, UserName = "Ran", ReviewDate = new DateTime(2019, 10, 23, 17, 0, 0), ReviewText = "It's not the worse movie, but far from the best. Try to watch it if you can. Just go in with zero expectations and try to have a good time. " });
            reviews.Add(new Review { ReviewId = 26, MovieId = 24, ReviewRating = 3, UserName = "Shunit", ReviewDate = new DateTime(2019, 10, 23, 19, 0, 0), ReviewText = "It's just a T.V movie, as same as most of Adam Sandler movies that composed of silly and funny jokes. " });
            reviews.Add(new Review { ReviewId = 27, MovieId = 24, ReviewRating = 5, UserName = "Sagi", ReviewDate = new DateTime(2019, 7, 22, 16, 0, 0), ReviewText = "best movie ever" });
            reviews.Add(new Review { ReviewId = 37, MovieId = 25, ReviewRating = 2, UserName = "Ran", ReviewDate = new DateTime(2019, 6, 22, 16, 0, 0), ReviewText = "It looks as if the filmmakers realized that the public was sick of certain movies. Most movies nowadays are full of wire work, sci-fi, etc. " });
            reviews.Add(new Review { ReviewId = 38, MovieId = 25, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 24, 16, 0, 0), ReviewText = "othing of that is in John Wick. John Wick adds hardly a story, no character development, no needless character or background, no misplaced drama, no misplaced humor and not too much eye candy, nothing of that." });
            reviews.Add(new Review { ReviewId = 39, MovieId = 26, ReviewRating = 4, UserName = "Sagi", ReviewDate = new DateTime(2019, 5, 24, 16, 0, 0), ReviewText = "The story is absolutely useless and unnecessary from start to midpoint. The remainder of the scenes where convoluted (especially the ending) and so dragged out - especially the lame sex scenes." });
            reviews.Add(new Review { ReviewId = 76, MovieId = 26, ReviewRating = 4, UserName = "Sagi", ReviewDate = new DateTime(2019, 4, 24, 16, 0, 0), ReviewText = "I didn't get the movie" });
            reviews.Add(new Review { ReviewId = 40, MovieId = 27, ReviewRating = 1, UserName = "Gal", ReviewDate = new DateTime(2019, 6, 24, 16, 0, 0), ReviewText = "I had to fast forward most of the long scenes as I was losing my interest and patience. What were the writers thinking? A 5th grader could have written this better." });
            reviews.Add(new Review { ReviewId = 41, MovieId = 27, ReviewRating = 3, UserName = "Ran", ReviewDate = new DateTime(2019, 7, 24, 16, 0, 0), ReviewText = "That's one of the things about theater vs. film--with theater, actors have a little more control, and one of the disappointing things about films is that once you're done" });
            reviews.Add(new Review { ReviewId = 42, MovieId = 28, ReviewRating = 5, UserName = "Shunit", ReviewDate = new DateTime(2019, 7, 24, 16, 0, 0), ReviewText = "This was a funny and - near the end - a touching movie. That's a nice combination to have. My only complaint is that it certainly isn't  for a nice story " });
            reviews.Add(new Review { ReviewId = 43, MovieId = 28, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 8, 24, 16, 0, 0), ReviewText = "the best movie and funny ever." });
            reviews.Add(new Review { ReviewId = 44, MovieId = 29, ReviewRating = 3, UserName = "Sagi", ReviewDate = new DateTime(2019, 5, 24, 16, 0, 0), ReviewText = "I have a gay friend who doesn't fit the stereotype in that he loves the WWE and usually watches crude comedies like this latest Adam Sandler comedy." });
            reviews.Add(new Review { ReviewId = 45, MovieId = 29, ReviewRating = 4, UserName = "Ran", ReviewDate = new DateTime(2019, 5, 24, 16, 0, 0), ReviewText = "laughed enough and enjoyed enough to at least recommend this to anyone who can laugh at almost anything. P.S. My gay friend absolutely loved this!" });
            reviews.Add(new Review { ReviewId = 46, MovieId = 30, ReviewRating = 3, UserName = "Shunit", ReviewDate = new DateTime(2019, 5, 24, 16, 0, 0), ReviewText = "Andre Allen (Chris Rock) is a standup comedian who became famous for a movie franchise character Hammy The Bear. " });
            reviews.Add(new Review { ReviewId = 47, MovieId = 30, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 3, 24, 16, 0, 0), ReviewText = "There are some funny moments but in general, the characters feel fake." });
            reviews.Add(new Review { ReviewId = 48, MovieId = 31, ReviewRating = 5, UserName = "Sagi", ReviewDate = new DateTime(2019, 5, 21, 16, 0, 0), ReviewText = "Paul Wrecking Crewe was a revered football superstar back in his day, but that time has since faded. " });
            reviews.Add(new Review { ReviewId = 49, MovieId = 31, ReviewRating = 1, UserName = "Gal", ReviewDate = new DateTime(2019, 8, 24, 16, 0, 0), ReviewText = "It's only the warden and the guards who have no idea who or what they're up against, with Paul the driving force behind the new team." });
            reviews.Add(new Review { ReviewId = 50, MovieId = 32, ReviewRating = 2, UserName = "Ran", ReviewDate = new DateTime(2019, 5, 22, 16, 0, 0), ReviewText = ".. And, it's Chris Rock at center. The movie was amusing to watch. There are some good laugh-out-loud moments, " });
            reviews.Add(new Review { ReviewId = 51, MovieId = 33, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 6, 24, 16, 0, 0), ReviewText = "Here's the setup: Rock plays a banker who has an effectively empty marriage ... his wife is focused on raising their two kids and is at the point of shunning any kind of physical intimacy." });
            reviews.Add(new Review { ReviewId = 52, MovieId = 33, ReviewRating = 4, UserName = "Ran", ReviewDate = new DateTime(2019, 5, 18, 16, 0, 0), ReviewText = "I thought it was really funny but they should have taken out some really stupid parts." });
            reviews.Add(new Review { ReviewId = 53, MovieId = 34, ReviewRating = 3, UserName = "Gal", ReviewDate = new DateTime(2019, 2, 19, 16, 0, 0), ReviewText = "Some of the dialouge Chris Rock said was supposed to be funny but it wasn't." });
            reviews.Add(new Review { ReviewId = 54, MovieId = 34, ReviewRating = 5, UserName = "Sagi", ReviewDate = new DateTime(2019, 5, 20, 16, 0, 0), ReviewText = " HOT this movie was." });
            reviews.Add(new Review { ReviewId = 55, MovieId = 35, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 3, 21, 16, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 56, MovieId = 35, ReviewRating = 4, UserName = "Sagi", ReviewDate = new DateTime(2019, 5, 14, 16, 0, 0), ReviewText = "I'm going to start off by saying that this was probably one of my most anticipated movies of all time. I went in the theater hoping for a masterpiece." });
            reviews.Add(new Review { ReviewId = 57, MovieId = 36, ReviewRating = 2, UserName = "Gal", ReviewDate = new DateTime(2019, 4, 15, 16, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 58, MovieId = 36, ReviewRating = 3, UserName = "Ran", ReviewDate = new DateTime(2019, 5, 16, 16, 0, 0), ReviewText = "I had the honor of watching TDK during a screening and was completely blown away!" });
            reviews.Add(new Review { ReviewId = 59, MovieId = 37, ReviewRating = 5, UserName = "Shunit", ReviewDate = new DateTime(2019, 6, 17, 16, 0, 0), ReviewText = "the worse movie for friday evning." });
            reviews.Add(new Review { ReviewId = 60, MovieId = 37, ReviewRating = 4, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 28, 16, 0, 0), ReviewText = "Great second installment. The acting was great, was able to connect with characters, and the CGI was surprising!" });
            reviews.Add(new Review { ReviewId = 61, MovieId = 38, ReviewRating = 4, UserName = "Ran", ReviewDate = new DateTime(2019, 5, 20, 16, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 62, MovieId = 38, ReviewRating = 5, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 20, 16, 0, 0), ReviewText = "At first glance, Deadpool seems like a typical superhero movie due to it being made by Marvel." });
            reviews.Add(new Review { ReviewId = 63, MovieId = 39, ReviewRating = 1, UserName = "Sagi", ReviewDate = new DateTime(2019, 5, 20, 16, 0, 0), ReviewText = "the best movie ever seen" });
            reviews.Add(new Review { ReviewId = 64, MovieId = 39, ReviewRating = 2, UserName = "Gal", ReviewDate = new DateTime(2019, 5, 22, 18, 0, 0), ReviewText = "At first glance, Deadpool seems like a typical superhero movie due to it being made by Marvel." });
            reviews.Add(new Review { ReviewId = 65, MovieId = 40, ReviewRating = 3, UserName = "Ran", ReviewDate = new DateTime(2019, 5, 24, 16, 0, 0), ReviewText = "I had the honor of watching TDK during a screening and was completely blown away!" });
            reviews.Add(new Review { ReviewId = 77, MovieId = 40, ReviewRating = 3, UserName = "Sagi", ReviewDate = new DateTime(2019, 5, 24, 13, 0, 0), ReviewText = "The moview was boring.." });

            context.Review.AddRange(reviews);
            SaveChanges(context);
        }
        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }

}
