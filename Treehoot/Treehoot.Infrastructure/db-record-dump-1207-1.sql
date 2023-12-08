-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               PostgreSQL 16.1 (Debian 16.1-1.pgdg120+1) on x86_64-pc-linux-gnu, compiled by gcc (Debian 12.2.0-14) 12.2.0, 64-bit
-- Server OS:                    
-- HeidiSQL Version:             12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping data for table public.Quiz: 3 rows
/*!40000 ALTER TABLE "Quiz" DISABLE KEYS */;
INSERT INTO "Quiz" ("Id", "Name", "Description") VALUES
	(1, 'quiz 1', 'first quiz'),
	(2, 'quiz 2', 'second quiz'),
	(3, 'quiz 3', 'third quiz');
/*!40000 ALTER TABLE "Quiz" ENABLE KEYS */;

-- Dumping data for table public.Stage: 4 rows
/*!40000 ALTER TABLE "Stage" DISABLE KEYS */;
INSERT INTO "Stage" ("Id", "Name", "QuizId") VALUES
	(11, 'stage 1', 1),
	(12, 'stage 2', 1),
	(13, 'stage 3', 1),
	(21, 'stage 1', 2);
/*!40000 ALTER TABLE "Stage" ENABLE KEYS */;

-- Dumping data for table public.Question: 8 rows
/*!40000 ALTER TABLE "Question" DISABLE KEYS */;
INSERT INTO "Question" ("Id", "StageId", "Topic", "QuestionText") VALUES
	(112, 11, 'topic', 'Which is the second answer'),
	(121, 12, 'topic', 'Which is the third answer'),
	(122, 12, 'topic', 'Which is the fourth answer'),
	(131, 13, 'topic', 'Which is the first answer'),
	(132, 13, 'topic', 'Which is the second answer'),
	(211, 21, 'topic', 'Which is the first answer?'),
	(212, 21, 'topic', 'Which is the second answer'),
	(111, 11, 'ayyooo', 'Which is the first answer');
/*!40000 ALTER TABLE "Question" ENABLE KEYS */;

-- Dumping data for table public.Answer: 24 rows
/*!40000 ALTER TABLE "Answer" DISABLE KEYS */;
INSERT INTO "Answer" ("Id", "QuestionId", "IsCorrect", "Text") VALUES
	(1111, 111, 'true', 'This is the first answer'),
	(1112, 111, 'false', 'This is the first answer'),
	(1113, 111, 'false', 'This is the first answer'),
	(1114, 111, 'false', 'This is the first answer'),
	(1121, 112, 'false', 'This is the second answer'),
	(1122, 112, 'true', 'This is the second answer'),
	(1123, 112, 'false', 'This is the second answer'),
	(1124, 112, 'false', 'This is the second answer'),
	(1211, 121, 'false', 'This is the third answer'),
	(1212, 121, 'false', 'This is the third answer'),
	(1213, 121, 'true', 'This is the third answer'),
	(1214, 121, 'false', 'This is the third answer'),
	(1221, 122, 'false', 'This is the fourth answer'),
	(1222, 122, 'false', 'This is the fourth answer'),
	(1223, 122, 'false', 'This is the fourth answer'),
	(1224, 122, 'true', 'This is the fourth answer'),
	(1311, 131, 'true', 'This is the first answer'),
	(1312, 131, 'false', 'This is the first answer'),
	(1321, 132, 'false', 'This is the second answer'),
	(1322, 132, 'true', 'This is the second answer'),
	(2111, 211, 'true', 'This is the first answer'),
	(2112, 211, 'false', 'This is the first answer'),
	(2121, 212, 'false', 'This is the second answer'),
	(2122, 212, 'true', 'This is the second answer');
/*!40000 ALTER TABLE "Answer" ENABLE KEYS */;






-- Dumping data for table public.User: -1 rows
/*!40000 ALTER TABLE "User" DISABLE KEYS */;
/*!40000 ALTER TABLE "User" ENABLE KEYS */;

-- Dumping data for table public.__EFMigrationsHistory: -1 rows
/*!40000 ALTER TABLE "__EFMigrationsHistory" DISABLE KEYS */;
INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES
	('20231121085218_init_postgre', '7.0.14'),
	('20231121234409_add_relationships', '7.0.14'),
	('20231122120040_rytis-test', '7.0.14'),
	('20231124003046_testnoinfra2', '7.0.14'),
	('20231124004656_change-api-call-result-datetime-to-string', '7.0.14'),
	('20231201070024_remove-api-call-table', '7.0.14');
/*!40000 ALTER TABLE "__EFMigrationsHistory" ENABLE KEYS */;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
