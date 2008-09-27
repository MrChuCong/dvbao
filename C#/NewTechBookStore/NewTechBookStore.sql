USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='NewTechBookStore')
BEGIN
	DROP DATABASE NewTechBookStore
END
GO

CREATE DATABASE NewTechBookStore
GO

USE NewTechBookStore
GO

CREATE TABLE Users
(
	UserID int identity(1, 1) PRIMARY KEY,
	Username varchar(20) UNIQUE NOT NULL,
	Password varchar(20) NOT NULL,
	Type int NOT NULL,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Address varchar(100),
	Email varchar(50),
	Phone varchar(20)
)
GO

INSERT INTO Users (Username, Password, Type, FirstName, LastName, Address, Email, Phone)
VALUES ('admin', 'admin', 0, 'Peter', 'Taylor', '', 'peter@ntbos.com', '')
SELECT * FROM Users WHERE UserID = @@IDENTITY
GO

INSERT INTO Users (Username, Password, Type, FirstName, LastName, Address, Email, Phone)
VALUES ('user1', 'user1', 1, 'John', 'Benson', '29 Spadina Avenue', 'johnbenson@gmail.com', '0944125763')
GO

INSERT INTO Users (Username, Password, Type, FirstName, LastName, Address, Email, Phone)
VALUES ('user2', 'user2', 1, 'Maryanne', 'Berger', '12 Spadina Avenue', 'mberger@yahoo.com', '0903124663')
GO

INSERT INTO Users (Username, Password, Type, FirstName, LastName, Address, Email, Phone)
VALUES ('user3', 'user3', 1, 'Bob', 'Bingham', '16 Spadina Avenue', 'bobbh@gmail.com', '0905552316')
GO

CREATE TABLE Categories
(
	CategoryID int identity(1, 1) PRIMARY KEY,
	CategoryName varchar(100) NOT NULL,
)
GO

INSERT INTO Categories (CategoryName)
VALUES ('Art')
GO

INSERT INTO Categories (CategoryName)
VALUES ('Business')
GO

INSERT INTO Categories (CategoryName)
VALUES ('Computer')
GO

INSERT INTO Categories (CategoryName)
VALUES ('History')
GO

INSERT INTO Categories (CategoryName)
VALUES ('Literature')
GO

CREATE TABLE BookDetails
(
	BookID int identity(1, 1) PRIMARY KEY,
	CategoryID int REFERENCES Categories(CategoryID),
	BookTitle varchar(100) NOT NULL,
	Author varchar(100) NOT NULL,
	Publisher varchar(100) NOT NULL,
	ISBN varchar(20) NOT NULL,
	Price float NOT NULL,
	Description text NOT NULL
)
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Art of Violin Playing', 'Carl Flesch', 'Carl Fischer Music Dist',
	'0825828228', 29.95, 'A monumental undertaking, this new translation of Carl Flesch''s essential The Art of Violin Playing, by Eric Rosenblith, preserves all the essential basic concepts of Flesch''s original, but presents them in more contemprary and idiomatic English. New hand diagrams have been added and a table for the consistent use of bowing and fingering symbols. The range of material covered by this massive book is enormous: Body Posture, The Left Arm, (position and fingerings), Vibrato, Bowing (including all varieties of strokes), Tone Production, Musical Memory and much, much more. This new edition of The Art of Violin Playing, Vol.1 will prove to be one of the most significant string publications of the new century.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Playing the Violin: An Illustrated Guide', 'Mark Rush', 'Routledge',
	'0415978866', 24.25, 'Playing the Violin is designed as a textbook for music education students in String Pedagogy courses. Elementary and secondary level music teachers are all involved with leading orchestras, and thus have to be conversant with basic techniques on a number of instruments, most notably the violin. Yet few understand the importance of "setup" for establishing proper technique. "Setup" refers to the basic physical elements of violin playing: How to hold the violin and bow; posture and position; movements left and right; and so forth. These are the fundamental components necessary for success. The earlier these concepts are established, the better. Unfortunately, many students reach the university level with bad habits and poor technique, and need to be re-educated about how to perform-and teach-proper violin technique.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Mel Bay Daily Scale Exercises for Violin', 'Herbert Chang', 'Mel Bay Publications',
	'0786657839', 10.73, 'Designed to help people master all 24 major and minor scales. In this book, first, all the violin scales are re-organized to be more simple, practical, and easy to learn. Then all the fingerings of the single-stop scales are classified into only a few basic patterns. When practicing, violinists can study these fingering patterns first and then use them to play all 24 scales easily. Finally, all the fingerings of the double-stop scales are also re-edited to make them as simple as possible. With this approach, the process of learning violin scales is much easier than before.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Violin Mastery: Interviews with Heifetz, Auer, Kreisler and Others (Dover Books on Music)', 'Frederick H. Martens', 'Dover Publications',
	'0486450414', 09.95, 'Twenty-four famous violinists reveal the secrets to their success, discuss the aesthetic and technical aspects of playing, and define their personal conceptions of violin mastery. Advice from the masters includes tips on efficient practice, improving bow technique, and refining intonation. A rare find in the musical literature, this volume is essential reading for every serious violinist.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Spring Awakening: In the Flesh', 'David Cote', 'Simon Spotlight Entertainment',
	'1416587829', 26.4, 'A heart-pounding score. A heartrending story. A barrier-breaking fusion of morality, sexuality, and rock&roll. No wonder Spring Awakening has awakened audiences like no other musical in years. Based on the infamous 1891 Frank Wedekind play and featuring an original score by Grammy-nominated recording star Duncan Sheik and Steven Sater, Spring Awakening is a story of uncontrollable emotions and undeniable passions.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Invincible: The Ultimate Collection Volume 4 (Hardcover)', 'Robert Kirkman', 'Image Comics',
	'1582409897', 23.09, 'Witness Invincible transition from new hero just starting out to an established superhero! This volume collects Invincible violent battle with the villainous Reanimen, the invasion attempt by the Sequis from Mars, and the introduction of the Viltrumite agent, Anissa.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Death in a Prairie House: Frank Lloyd Wright and the Taliesin Murders (Paperback)', 'William R. Drennan', 'University of Wisconsin Press',
	'0299222144', 11.53, 'The most pivotal and yet least understood event of Frank Lloyd Wright’s celebrated life involves the brutal murders in 1914 of seven adults and children dear to the architect and the destruction by fire of Taliesin, his landmark residence, near Spring Green, Wisconsin. Supplying both a gripping mystery story and a portrait of the artist in his prime, William Drennan wades through the myths surrounding Wright and the massacre, casting fresh light on the formulation of Wright’s architectural ideology and the cataclysmic effects that the Taliesin murders exerted on the fabled architect and on his subsequent designs.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Mixed-Media Self-Portraits: Inspiration & Techniques', 'Cate Coulacos Prato', 'Interweave Press',
	'1596680822', 15.61, 'Featuring artwork from a wide range of contributors, this resource explores creative self-portraits through fun and easy exercises and essays that instruct and inspire artists working in all media. Examples of collage, fiber arts, and mixed-media artwork offer visual inspiration while essays throughout the book act as a guide to personal and artistic self-discovery. Step-by-step techniques and creative prompts are used to direct artists through different approaches to creating self-portraits while exercises utilizing collage, drawing, photography, and stitching will jump-start the creative process and get ideas flowing on paper and fabric, encouraging artists to express themselves in new ways.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Liaigre (Hardcover)', 'Christian Liaigre', 'Flammarion',
	'208030061X', 78.75, 'Following his highly successful volume Maison, interior design guru Christian Liaigre takes us inside six exclusive properties to unveil his luxurious world of design. Liaigre unleashes his masterful eye on diverse, international settings—a hidden Spanish residence, a luxury yacht, a massive Swiss farmstead, a thatched-roof paradise in Bora Bora, a modern Canadian manor, and a villa in the South of France. He combines local materials with the personality of the owner, while remaining true to the signature style that has made him one of the most sought-after designers of our time. Close-up photographs feature a wealth of design details—embossed leather and velour upholstery, generously proportioned furniture, and splashes of jewel-tone accessories that sparkle against the warm earthy tones of the natural, local materials.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (1, 'Fighter: The Fighters of the UFC (Hardcover)', 'Reed Krakoff ', 'Studio',
	'0670020435', 29.70, 'In Fighter: The Fighters of the UFC, Reed Krakoff offers a unique look at these world-class athletes in a startling collection of black- and-white photographs. Krakoff, the president and executive creative director of Coach, a leading force in the fashion world, is also an accomplished photographer and a huge UFC fan. His pictures, shot with a medium-format Mamiya box camera, depict these fighters as they are rarely seen. Standing alone, without competitors or an audience, Krakoff’s subjects look gentle, warm, humble, and disarmed. But with their signature tattoos and resilient bodies, it’s also clear that they are built for the cage..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'Hot, Flat, and Crowded: Why We Need a Green Revolution--and How It Can Renew America (Hardcover)', 'Thomas L. Friedman', 'Farrar, Straus and Giroux',
	'0374166854', 15.37, 'Thomas L. Friedman’s phenomenal number-one bestseller The World Is Flat has helped millions of readers to see the world in a new way. In his brilliant, essential new book, Friedman takes a fresh and provocative look at two of the biggest challenges we face today: America’s surprising loss of focus and national purpose since 9/11; and the global environmental crisis, which is affecting everything from food to fuel to forests. In this groundbreaking account of where we stand now, he shows us how the solutions to these two big problems are linked--how we can restore the world and revive America at the same time..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'Six Disciplines Execution Revolution', 'Gary Harpst', 'Six Disciplines Publishing',
	'0981641105', 7.12, 'As a follow-up to the success of Six Disciplines for Excellence, Harpst new book, Six Disciplines® Execution Revolution, details the elements of a complete strategy execution program, clarifies how it could only have happened now, and explains why such a program will soon become a mainstream requirement for your business..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'The Gone Fishin Portfolio', 'Alexander Green', 'Wiley',
	'0470112670', 16.77, 'Outperform the vast majority of investment professionals while paying nothing in sales charges, brokerage fees, or commissions by modifying your investment strategy. Learn how to make your investment dreams come true with the advice in The Gone Fishin Portfolio: Get Wise, Get Wealthy...and Get on With Your Life, a guide that’s based on a Nobel Prize-winning investment strategy yet takes just 20 minutes to implement. Gain an understanding of the fundamental relationship between risk and reward in the financial markets and get an insider view of how the investment industry really works..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'The Attractor Factor', 'Joe Vitale', 'Wiley',
	'0470286423', 13.77, 'Discover the secret to lifelong wealth and happiness! Now in an expanded paperback second edition that includes an Attractor Factor IQ test, exercises for putting lessons into practice, new stories, and more, Dr. Joe Vitale presents his even more powerful and effective five-step plan for attracting wealth, happiness, and success to your life..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'Money, and the Law of Attraction', 'Esther Hicks', 'Hay House',
	'1401918816', 10.17, 'This Leading Edge work by Esther and Jerry Hicks, who present the teachings of the Non-Physical consciousness Abraham, explains that the two subjects most chronically affected by the powerful Law of Attraction are financial and physical well-being. This book will shine a spotlight on each of the most significant aspects of your life experience and then guide you to the conscious creative control of every aspect of your life, and also goes right to the heart of what most of you are probably troubled by: money and physical health..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'The Snowball', 'Alice Schroeder', 'Bantam',
	'0553805096', 21.00, 'Here is THE book recounting the life and times of one of the most respected men in the world, Warren Buffett. The legendary Omaha investor has never written a memoir, but now he has allowed one writer, Alice Schroeder, unprecedented access to explore directly with him and with those closest to him his work, opinions, struggles, triumphs, follies, and wisdom. The result is the personally revealing and complete biography of the man known everywhere.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'The Shock Doctrine', 'Naomi Klein', 'Picador',
	'0312427999', 10.88, 'Naomi Klein The Shock Doctrine advances a truly unnerving argument: historically, while people were reeling from natural disasters, wars and economic upheavals, savvy politicians and industry leaders nefariously implemented policies that would never have passed during less muddled times. As Klein demonstrates, this reprehensible game of bait-and-switch is not just some relic from the bad old days. Its alive and well in contemporary society, and coming soon to a disaster area near you..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'The Truth About You', 'Marcus Buckingham', 'Thomas Nelson',
	'1400202264', 19.79, 'Perfect for high school and college students, young professionals, and people simply wanting to revitalize their career, The Truth About You helps you develop the kind of clarity and passion that drives a successful and satisfying future. Marcus Buckingham will help you discover the real truth, the truth about you . . . it will be your secret to success..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'The Numerati (Hardcover)', 'Stephen Baker', 'Houghton Mifflin',
	'0618784608', 17.16, 'Starred Review. In this captivating exploration of digital nosiness, business reporter Baker spotlights a new breed of entrepreneurial mathematicians (the numerati) engaged in harnessing the avalanche of private data individuals provide when they use a credit card, donate to a cause, surf the Internet—or even make a phone call..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (2, 'A Sense of Urgency ', ' John P. Kotter', 'Harvard Business School Press',
	'1422179710', 14.96, 'Most organizational change initiatives fail spectacularly (at worst) or deliver lukewarm results (at best). In his international bestseller Leading Change, John Kotter revealed why change is so hard, and provided an actionable, eight-step process for implementing successful transformations. The book became the change bible for managers worldwide..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (3, 'The Adobe Photoshop Lightroom 2 Book for Digital Photographers', 'Scott Kelby', 'New Riders Press',
	'0321555562', 29.69, 'Written in concert with Adobe development of the Photoshop Lightroom 2 Beta, The Adobe Photoshop Lightroom 2 Book for Digital Photographers - by #1 bestselling computer and technology author, Scott Kelby - is the most complete and concise Lightroom "how-to" book for digital photographers of all skill levels..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (3, 'Star Wars: The Force Unleashed Prima Official Game Guide', 'Fernando Bueno', 'Prima Games',
	'0761559167', 13.59, 'Walkthrough: Extensive walkthrough of every level for the Xbox 360, PS3, and Wii!.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (3, 'iPhone: The Missing Manual: Covers the iPhone 3G', 'David Pogue', 'Pogue Press',
	'0596521677', 16.49, 'he new iPhone 3G is here, and New York Times tech columnist David Pogue is on top of it with a thoroughly updated edition of iPhone: The Missing Manual. With its faster downloads, touch-screen iPod, and best-ever mobile Web browser, the new affordable iPhone is packed with possibilities. But without an objective guide like this one, you will never unlock all it can do for you.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (3, 'Click: What Millions of People Are Doing Online and Why it Matters', 'Bill Tancer', 'Hyperion',
	'1401323049', 15.61, 'What time of year do teenage girls search for prom dresses online? How does the quick adoption of technology affect business success (and how is that related to corn farmers in Iowa)? How do time and money affect the gender of visitors to online dating sites? And how is the Internet itself affecting the way we experience the world? In Click, Bill Tancer takes us behind the scenes into the massive database of online intelligence to reveal the naked truth about how we use the Web, navigate to sites, and search for information--and what all of that says about who we are..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (3, 'Spore: Prima Official Game Guide', 'David Hodgson', 'Prima Games',
	'0761557806', 15.61, 'Your actions in earlier stages affect your starting points in later stages. For example, if you’re an aggressive race in the Tribal Stage, you will begin the Civilization Stage as a military society. If you win over other tribes by performing songs or giving them gifts, you will begin the Civilization Stage as a religious or economic society, respectively..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (4, 'The War Within: A Secret White House History 2006-2008', 'Bob Woodward', 'Simon',
	'1416558977', 17.60, 'Bob Woodward fourth book about the Bush presidency at war declassifies the secrets of America political and military involvement in Iraq. It will be essential reading for all citizens -- and candidates -- in this election year..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (4, 'Angler: The Cheney Vice Presidency', 'Barton Gellman', 'Penguin Press HC',
	'1594201862', 15.37, 'Pulitzer Prize-winning journalist Barton Gellman’s newsbreaking investigative journalism documents how Vice President Dick Cheney redefined the role of the American vice presidency, assuming unprecedented responsibilities and making it a post of historic power..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (4, 'The Forever War', 'Dexter Filkins', 'Knopf',
	'0307266397', 15.00, 'Starred Review. Filkins, a New York Times prize–winning reporter, is widely regarded as among the finest war correspondents of this generation. His richly textured book is based on his work in Afghanistan and Iraq since 1998. It begins with a Taliban-staged execution in Kabul. It ends with Filkins musing on the names in a WWI British cemetery in Baghdad..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (4, 'The House at Sugar Beach', 'Helene Cooper', 'Simon',
	'0743266242', 16.50, 'Journalist Cooper has a compelling story to tell: born into a wealthy, powerful, dynastic Liberian family descended from freed American slaves, she came of age in the 1980s when her homeland slipped into civil war. On Cooper 14th birthday, her mother gives her a diamond pendant and sends her to school. Cooper is convinced that somehow our world would right itself..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (4, 'The Shock Doctrine', 'Naomi Klein', 'kkkkkk',
	'1596680822', 10.88, 'Naomi Klein The Shock Doctrine advances a truly unnerving argument: historically, while people were reeling from natural disasters, wars and economic upheavals, savvy politicians and industry leaders nefariously implemented policies that would never have passed during less muddled times. As Klein demonstrates, this reprehensible game of bait-and-switch is just some relic from the bad old days. It alive and well in contemporary society, and coming soon to a disaster area near you..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (5, 'The Given Day', ' Dennis Lehane', 'William Morrow',
	'0688163181', 18.05, 'Starred Review. In a splendid flowering of the talent previously demonstrated in his crime fiction (Gone, Baby, Gone; Mystic River), Lehane combines 20th-century American history, a gripping story of a family torn by pride and the strictures of the Catholic Church, and the plot of a multifaceted thriller.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (5, 'The Guernsey Literary and Potato Peel Pie Society', 'Mary Ann Shaffer', 'The Dial Press',
	'0385340990', 15.61, 'The letters comprising this small charming novel begin in 1946, when single, 30-something author Juliet Ashton (nom de plume Izzy Bickerstaff) writes to her publisher to say she is tired of covering the sunny side of war and its aftermath. When Guernsey farmer Dawsey Adams finds Juliet name in a used book and invites articulate—and not-so-articulate—neighbors to write Juliet with their stories, the book epistolary circle widens, putting Juliet back in the path of war stories.')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (5, 'The Shack', 'William P. Young', 'Windblown Media',
	'B001B8Z2S0', 8.24, 'Mackenzie Allen Philips youngest daughter, Missy, has been abducted during a family vacation and evidence that she may have been brutally murdered is found in an abandoned shack deep in the Oregon wilderness. Four years later in the midst of his Great Sadness, Mack receives a suspicious note, apparently from God, inviting him back to that shack for a weekend. Against his better judgment he arrives at the shack on a wintry afternoon and walks back into his darkest nightmare..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (5, 'Anathem', 'Neal Stephenson', 'William Morrow',
	'0061474096', 17.47, 'In this follow-up to his historical Baroque Cycle trilogy, which fictionalized the early-18th century scientific revolution, Stephenson (Cryptonomicon) conjures a far-future Earth-like planet, Arbre, where scientists, philosophers and mathematicians—a religious order unto themselves—have been cloistered behind concent (convent) walls..')
GO

INSERT INTO BookDetails (CategoryID, BookTitle, Author, Publisher,
			ISBN, Price, Description)
VALUES (5, 'The Other Queen', 'Philippa Gregory', 'Touchstone',
	'1416549129', 15.57, 'This dazzling novel from the #1 New York Times bestselling author Philippa Gregory presents a new and unique view of one of history most intriguing, romantic, and maddening heroines. Biographers often neglect the captive years of Mary, Queen of Scots, who trusted Queen Elizabeth promise of sanctuary when she fled from rebels in Scotland and then found herself imprisoned as the "guest" of George Talbot, Earl of Shrewsbury, and his indomitable wife, Bess of Hardwick..')
GO

CREATE TABLE Currency
(
	Code varchar(5) PRIMARY KEY,
	ExchangeRate float NOT NULL
)
GO

INSERT INTO Currency VALUES ('AUD', 1.01)
INSERT INTO Currency VALUES ('CAD', 0.95)
INSERT INTO Currency VALUES ('CHF', 0.99)
INSERT INTO Currency VALUES ('EUR', 0.61)
INSERT INTO Currency VALUES ('HKD', 7.47)
INSERT INTO Currency VALUES ('JPY', 101.58)
INSERT INTO Currency VALUES ('SGD', 1.31)
INSERT INTO Currency VALUES ('USD', 1.00)